using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController charControl;
    private CharacterAnimations playerAnimations;

    public float movement_speed = 3f;

    public float gravity = 0f;

    public float rotation_speed = 0.15f;
    public float rotateDegreeSecond = 180f;

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        AnimateWalk();
    }

    void Move()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charControl.Move(moveDirection * movement_speed * Time.deltaTime);

        }
        else if (Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {

            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            charControl.Move(moveDirection * movement_speed * Time.deltaTime);
        }
        else
        {
            charControl.Move(Vector3.zero);
        }

       // Rotate();
    }

        void Rotate()
        {
        Vector3 rotate_dir = Vector3.zero;
         if (Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotate_dir = transform.TransformDirection(Vector3.left);
        }
         if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotate_dir = transform.TransformDirection(Vector3.right);
        }

         if(rotate_dir != Vector3.zero) {

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, Quaternion.LookRotation(rotate_dir),
                rotateDegreeSecond * Time.deltaTime);
                }
       } //rotate

    void AnimateWalk()
    {

        if (charControl.velocity.sqrMagnitude != 0f)
        {

            playerAnimations.Walk(true);
        } else {

            playerAnimations.Walk(false);
        }
    }
   
}
