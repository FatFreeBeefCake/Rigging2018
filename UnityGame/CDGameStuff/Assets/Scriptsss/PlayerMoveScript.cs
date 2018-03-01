using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveScript : MonoBehaviour {

    CharacterController cc;

    Vector3 tempMove;
    Vector3 tempMoveZ;
    Vector3 Fall;

    private UnityAction OnLandAction;
    private Image healthbar;

    public float speed = 0.5f;
    public float gravity = 40;
    public float JumpHeight = 100;
    public float pushForce = 2.0f;
    public int Health, MaxHealth;


    // Use this for initialization
    void Start()
    {
        Health = 100;
        MaxHealth = 100;

        cc = GetComponent<CharacterController>();
        
    }
    void Update()
    {
        ActionScript.MoveActionX += Move;
        ActionScript.MoveActionZ += MoveZ;
        ActionScript.Run = Run;
        ActionScript.Walk = Walk;
        ActionScript.JumpAction = Jump;
    }

    private void MoveZ(float _movement)
    {
        tempMove.z = _movement * speed;
        cc.Move(tempMove * Time.deltaTime);
    }

    private void Walk()
    {
        speed = 0.5f;
    }

    private void Run()
    {
        speed = speed * 2;
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

      
        tempMove.x = _movement * speed;
        cc.Move(tempMove * Time.deltaTime);

        if (!cc.isGrounded)
        {
            tempMove.y -= gravity * Time.deltaTime;
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
