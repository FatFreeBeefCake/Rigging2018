using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventsIdle : MonoBehaviour {

    public Animator Animations;

    void Start()
    {
    }
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("Idle"))
        {
            Animations.SetBool("Idle", true);
        }
    }

}
