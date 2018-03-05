using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvents : MonoBehaviour {

    public Animator Animations;

    void Start()
    {
    }
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("Walk"))
        {
            Animations.SetBool("Walk", true);
        }
    }

}
