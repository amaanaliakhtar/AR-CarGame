using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject animation;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.transform.tag == "Gem")
        {
            Destroy(collision.transform.gameObject);
            Instantiate(animation, collision.transform.position, collision.transform.rotation);
        }
    }
}
