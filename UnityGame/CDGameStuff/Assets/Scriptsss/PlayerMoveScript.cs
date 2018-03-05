using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveScript : MonoBehaviour {

    CharacterController cc;

    public Player PP;

    Vector3 tempMove;

    Vector3 Fall;

    private UnityAction OnLandAction;

    public Text Name;
    public Text THealth;
    public Text TPower;

    private float gravity = 40;

    private float speed;
    private float JumpHeight;
    private float pushForce;
    private float Rotate;
    public int Health, MaxHealth;


    // Use this for initialization
    void Start()
    {

        cc = GetComponent<CharacterController>();

        Name.text = PP.name;
        THealth.text = PP.Health.ToString();
        TPower.text = PP.Power.ToString();


        speed = PP.Speed;
        JumpHeight = PP.JumpSpeed;
        Rotate = PP.RotSpeed;
        pushForce = PP.PushForce;
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Rotate") * Rotate * Time.deltaTime, 0);
        if (cc.isGrounded)
        {
            tempMove = new Vector3(0, 0, Input.GetAxis("Vertical"));
            tempMove = transform.TransformDirection(tempMove);
            tempMove *= speed;
            if (Input.GetButton("Jump"))
                tempMove.y = JumpHeight;
        }
        cc.Move(tempMove * Time.deltaTime);
        tempMove.y -= gravity * Time.deltaTime;

    }
    private void Jump ()
    {

        if (cc.isGrounded)
        {

            tempMove.y = JumpHeight;

        } 
        
    }

    // Update is called once per frame
    void Move(float _movement)
    {
        if (!cc.isGrounded)
        {
         
            if (OnLandAction == null)
            {
                OnLandAction += restGravity;
                Debug.Log("is not grounded");
            }
        }
        if (cc.isGrounded)
        {
            if(OnLandAction != null)
            {
                OnLandAction();
                OnLandAction = null;
                Debug.Log("Grounded");
            }
        }
    }

    void restGravity()
    {
        tempMove.y = -.1f;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        //checking whether rigidbody is either non-existant or kinematic
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -.3f)
            return;

        //set up push direction for object
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        //apply push force to object
        body.velocity = pushForce * pushDirection;
    }

}
