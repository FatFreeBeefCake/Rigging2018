using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class ActionScript : MonoBehaviour {

    public static UnityAction<float> MoveActionX;
    public static UnityAction<float> MoveActionZ;
    public static UnityAction ClimbAction;
    public static UnityAction JumpAction;
    public static UnityAction Crouch;
    public static UnityAction Stand;
    public static UnityAction Run;
    public static UnityAction Walk;
    public static UnityAction<float> BearAction;
    public static UnityAction Pause;

	// Update is called once per frame
	void Update () {
        if (MoveActionX != null)
        {
            MoveActionX(Input.GetAxis("Horizontal"));
        }
        if (MoveActionZ != null)
        {
            MoveActionZ(Input.GetAxis("Vertical"));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpAction();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Walk();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

	}
}
