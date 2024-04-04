using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform gamePad;
    public float moveSpeed = 0.5f;

    GameObject arObject;
    Vector3 movement;

    bool moving;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);

        movement = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized; // no movement in y axis, car cannot move upwards

        if (!moving)
        {
            moving = true;
            //add wheel animation code here
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(ObjectMovement());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero; //joystick default position
        movement = Vector3.zero;
        StopCoroutine(ObjectMovement());

        moving = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        arObject = GameObject.FindGameObjectWithTag("Car");
    }

    IEnumerator ObjectMovement()
    {
        while (true)
        {
            arObject.transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

            if(movement != Vector3.zero)
            {
                arObject.transform.rotation = Quaternion.Slerp(arObject.transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * 0.5f);
            }

            yield return null;
        }
    }

}
