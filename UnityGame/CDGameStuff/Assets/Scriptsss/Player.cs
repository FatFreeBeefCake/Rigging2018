using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "New Player") ]
public class Player : ScriptableObject {

    public new string name;

    public int Speed;
    public int JumpSpeed;
    public int RotSpeed;
    public int PushForce;

    public int Health;
    public int Power;

    public void Print()
    {
        Debug.Log("Hello");
    }



}
