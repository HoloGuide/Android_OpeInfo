using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{

    float TimeCount = 5;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        TimeCount -= Time.deltaTime;

        if(TimeCount <= 0)
        {

                Application.LoadLevel("Smartphone_UI_2_Unity");

        }

	}

}
