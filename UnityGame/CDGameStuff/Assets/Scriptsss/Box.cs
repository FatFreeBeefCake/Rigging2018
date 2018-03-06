using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Box", menuName = "Box")]
public class Box : ScriptableObject {

    public Vector3 Size;
    public new string name;

    public string Animation;

    public Color color;

    public int health;
    public int power;

    public void Print()
    {
        Debug.Log(name + " Health: " + health + " " + "Power: " + power);
    }

}
