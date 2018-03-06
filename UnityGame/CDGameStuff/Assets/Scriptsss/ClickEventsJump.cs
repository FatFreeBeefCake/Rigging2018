using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventsJump : MonoBehaviour {

    public Animator Animations;
    public Box box;

    public string anim;

    void Start()
    {
        anim = box.Animation;
    }
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("Jump"))
        {
            Animations.SetBool(anim , true);
        }
    }

}
