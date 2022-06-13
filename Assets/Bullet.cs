using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40;

    void start()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
    }

    void update()
    {
        Destroy(gameObject, 3);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     Destroy(gameObject);
    // }
}
