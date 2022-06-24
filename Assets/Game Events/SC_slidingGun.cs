//Make an empty GameObject and call it "SlidingDoor"
//Drag and drop your Door model into Scene and rename it to "Body"
//Move the "Body" Object inside "SlidingDoor"
//Add a Collider (preferably SphereCollider) to "SlidingDoor" Object and make it bigger then the "Body" model
//Assign this script to a "SlidingDoor" Object (the one with a Trigger Collider)
//Make sure the main Character is tagged "Player"
//Upon walking into trigger area the door should Open automatically

using UnityEngine;
using System;

public class SC_slidingGun : MonoBehaviour
{
    // Sliding door
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); //Contols the open speed at a specific time (ex. the door opens fast at the start then slows down at the end)
    public enum OpenDirection { x, y, z }
    public OpenDirection direction = OpenDirection.y;
    public float openDistance = 3f; //How far should door slide (change direction by entering either a positive or a negative value)
    public float openSpeedMultiplier = 2.0f; //Increasing this value will make the door open faster
    public Transform gunBody; //Door body Transform

    bool open = false;

    //public static event Action onPhysicalButtonPressed;
    Vector3 defaultDoorPosition;
    Vector3 currentDoorPosition;
    float openTime = 0;

    void Start()
    {

        //gunBody.localPosition = currentPos;

        if (!gunBody)
        {
            defaultDoorPosition = gunBody.localPosition;
        }

        //Set Collider as trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Main function
    //void Update()
    //{
    //    if (!gunBody)
    //        return;

    //    if (openTime < 1)
    //    {
    //        openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
    //    }

    //    if (direction == OpenDirection.x)
    //    {
    //        gunBody.localPosition = new Vector3(Mathf.Lerp(currentDoorPosition.x, defaultDoorPosition.x + (open ? openDistance : 0), openTime), gunBody.localPosition.y, gunBody.localPosition.z);
    //    }
    //    else if (direction == OpenDirection.y)
    //    {
    //        gunBody.localPosition = new Vector3(gunBody.localPosition.x, Mathf.Lerp(currentDoorPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), openTime), gunBody.localPosition.z);
    //    }
    //    else if (direction == OpenDirection.z)
    //    {
    //        gunBody.localPosition = new Vector3(gunBody.localPosition.x, gunBody.localPosition.y, Mathf.Lerp(currentDoorPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), openTime));
    //    }
    //}

    // Activate the Main function when Player enter the trigger area

    
    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag ("Button"))
            if (other.CompareTag("Player")) 
            {
                
                open = true;
                currentDoorPosition = gunBody.localPosition;
                openTime = 0;
            }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("Player"))
       {
           open = false;
           currentDoorPosition = gunBody.localPosition;
           openTime = 0;
       }
   }

//private void OnEnable()
//    {
//        PickupInteractor.onPickUp += IsTrue;
//    }

private void IsTrue()
    {
        if (!gunBody)
            return;

        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }

        if (direction == OpenDirection.x)
        {
            gunBody.localPosition = new Vector3(Mathf.Lerp(currentDoorPosition.x, defaultDoorPosition.x + (open ? openDistance : 0), openTime), gunBody.localPosition.y, gunBody.localPosition.z);
        }
        else if (direction == OpenDirection.y)
        {
            gunBody.localPosition = new Vector3(gunBody.localPosition.x, Mathf.Lerp(currentDoorPosition.y, defaultDoorPosition.y + (open ? openDistance : 0), openTime), gunBody.localPosition.z);
        }
        else if (direction == OpenDirection.z)
        {
            gunBody.localPosition = new Vector3(gunBody.localPosition.x, gunBody.localPosition.y, Mathf.Lerp(currentDoorPosition.z, defaultDoorPosition.z + (open ? openDistance : 0), openTime));
        }

    }
}