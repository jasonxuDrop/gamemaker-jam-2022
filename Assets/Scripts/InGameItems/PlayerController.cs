using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public float lookSpeed = 10f;
    public float rotationOffsetY = 7f;
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public Transform modelTransform;
    public Transform camTransform;
    public Animator anim;

    CharacterController characterController;
    float rotationPlayer = 0;
    Vector3 moveDirection = Vector3.zero;



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

	private void Update()
	{
        float moveForward = Input.GetAxis("Vertical");
        float moveRight = Input.GetAxis("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;

        // rotate based on camera's y rotation
        //rotationPlayer += mouseX;
        //transform.rotation = Quaternion.Euler(0, rotationPlayer, 0);

        Vector3 camRotation = new Vector3(0, camTransform.rotation.eulerAngles.y + rotationOffsetY, 0);
        modelTransform.DORotate(camRotation, 0);

        // move based on input
        Vector3 forwardDirection = transform.TransformDirection(modelTransform.forward);
        Vector3 rightDirection = transform.TransformDirection(modelTransform.right);

        // check for shift key for move
        if (isRunning) // +
            moveDirection *= runningSpeed;
        else
            moveDirection *= walkingSpeed;

        // animator stuff
        anim.SetBool("isMoving", (moveForward != 0 || moveRight != 0));

        moveDirection = moveForward * forwardDirection + moveRight * rightDirection;
        moveDirection *= walkingSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
