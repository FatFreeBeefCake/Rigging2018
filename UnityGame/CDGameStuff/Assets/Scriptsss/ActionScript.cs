using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class ActionScript : MonoBehaviour {

    public static UnityAction<float> MoveActionZ;
    public static UnityAction JumpAction;

	// Update is called once per frame
	void Update () {
        if (MoveActionZ != null)
        {
            MoveActionZ(Input.GetAxis("Vertical"));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpAction();
        }

	}
}
