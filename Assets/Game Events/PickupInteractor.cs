using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickupInteractor : MonoBehaviour
{
    public static event Action onPickUp;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            onPickUp?.Invoke();
    }
}
