using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDesplay : MonoBehaviour {

    public Box box;

    public Transform boxSize;

    public Color boxColor;
    public Renderer boxRend;

	void Start () {
        box.Print();
        boxRend.material.color = box.color;
        boxSize.localScale = box.Size;
	}

}
