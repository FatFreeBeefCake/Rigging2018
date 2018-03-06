using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventsIdle : MonoBehaviour {

    public Box box;
    public Animator Animations;
    public string anim;

    void Start()
    {
        anim = box.Animation;
    }
    private void OnMouseDown()
    {
        if (GameObject.FindWithTag("Idle"))
        {
            Animations.SetBool(anim , true);
        }
    }

}
