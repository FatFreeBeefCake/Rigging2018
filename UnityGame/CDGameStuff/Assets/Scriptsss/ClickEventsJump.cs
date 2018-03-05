using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventsJump : MonoBehaviour {

    public Animator Animations;

    void Start()
    {
    }
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("Jump"))
        {
            Animations.SetBool("Jump", true);
        }
    }

}
