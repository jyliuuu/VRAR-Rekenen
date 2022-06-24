using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class collision_trigger : MonoBehaviour
{    
    MathGen mathgen; //1st name is the script name & the 2nd one is the defined name
    public GameObject question;

    void Awake()
    {
        mathgen = question.GetComponent<MathGen>();
    }

    void Update()
    {
    }

    public void OnTriggerEnter(Collider cube)
    {
        if (cube.gameObject.name == GameObject.FindWithTag("target-1").name)
        {
            mathgen.answer1_bool = true;
        }
        else if (cube.gameObject.name == GameObject.FindWithTag("target-2").name)
        {
            mathgen.answer2_bool = true;
        }
        else if (cube.gameObject.name == GameObject.FindWithTag("target-3").name)
        {
            mathgen.answer3_bool = true;
        }
        else
        {

        }
    }

    //void DefineTargets()
    //{
    //    public GameObject Collider1 = GameObject.Find("collider1");
    //    public GameObject Collider2 = GameObject.Find("collider2");
    //    public GameObject Collider3 = GameObject.Find("collider3");

    //    public GameObject Target1 = GameObject.Find("target1");
    //    public GameObject Target2 = GameObject.Find("target2");
    //    public GameObject Target3 = GameObject.Find("target3");
    //}

    // Use this for initialization  
    void Start() { }
    // Update is called once per frame  
}
