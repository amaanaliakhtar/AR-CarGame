using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject animation;
    public GameObject objectToSpawn;
    public GameObject score;
    Vector3 position;
    Quaternion rotation;
    public float timer = 3.0f;
    bool isCollision = false;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.transform.tag == "Gem" && isCollision == false)
        {
            Destroy(collision.transform.gameObject);
            Scoring.scoreValue += 5;

            isCollision = true;

            position = collision.transform.position;
            rotation = collision.transform.rotation;

            StartCoroutine(SpawnGem());

            Destroy(Instantiate(animation, collision.transform.position, collision.transform.rotation), timer);  //instantiate then destroy after 3s
            Destroy(Instantiate(score, collision.transform.position, collision.transform.rotation), timer);  //instantiate then destroy after 3s

        }
    }

    IEnumerator SpawnGem()
    {
        yield return new WaitForSeconds(timer);
        Instantiate(objectToSpawn, position, rotation);
        isCollision = false;
    }
}
