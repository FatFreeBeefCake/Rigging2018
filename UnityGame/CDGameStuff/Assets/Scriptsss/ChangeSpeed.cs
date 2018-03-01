using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeSpeed : MonoBehaviour {

    public static Action<float, float> SendSpeed;

    public StaticVar.GameSpeed speedType;
    
    void OnTriggerEnter()
    {
        switch (speedType)
        {
            case StaticVar.GameSpeed.DRAG:
                SendSpeed(StaticVar.dragSpeed, StaticVar.gravity);
                break;
            case StaticVar.GameSpeed.BOOST:
                SendSpeed(StaticVar.dragSpeed, StaticVar.boostgravity);
                break;
            case StaticVar.GameSpeed.SUPERBOOST:
                SendSpeed(StaticVar.boostSpeed * 2, StaticVar.gravity);
                break;
            case StaticVar.GameSpeed.NORMAL:
                SendSpeed(StaticVar.speed, StaticVar.gravity);
                break;
            case StaticVar.GameSpeed.ROPE:
                SendSpeed(StaticVar.speed, StaticVar.noGravity);
                break;

        }
    } 

    void OnTriggerExit()
    {
        SendSpeed(StaticVar.speed, StaticVar.gravity);
    }
}
