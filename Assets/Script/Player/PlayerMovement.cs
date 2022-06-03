using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Const
    private Vector3 moveInputs;
    private Vector3 charVelocity;
    private Vector3 hitNormal;
    private CharacterController charController;
    private bool isSlope;


    //Movementspeed
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float castOffSet = 2f;
    [SerializeField] private float playerTurnSpeed = 0.3f;
    [SerializeField] private float playerGravityScale = -80f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float playerFriction = 0.5f;

    //Camera settings
    [SerializeField] private Transform playerMainCam;

    //Reset point of the player
    [SerializeField] private Transform playerResetPoint;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    public void Move(Vector2 playerInputs)
    {
        Ray downRay = new Ray(transform.position + transform.forward * castOffSet, Vector3.down);

        //Camera variables;
        Vector3 camForward = playerMainCam.forward;
        Vector3 camRight = playerMainCam.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        //SLOPE and SLIDE

        //Move based on camera
        moveInputs = new Vector3(playerInputs.x, 0, playerInputs.y);
        moveInputs = moveInputs.z * camForward + moveInputs.x * camRight;
        moveInputs = Vector3.ClampMagnitude(moveInputs, 1);

        // |IF NEEDED| Rotation of player
        if (charVelocity.magnitude > 0.01f && moveInputs != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveInputs);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, playerTurnSpeed);
        }

        //Gravity and Falling Velocity
        Vector3 movement = moveInputs * movementSpeed;
        // charVelocity.y = playerGravityScale;

        isSlope = (Vector3.Angle(hitNormal, Vector3.up) <= charController.slopeLimit);
        if (!isSlope)
        {
            movement.x += ((1f - hitNormal.y) * hitNormal.x) * playerFriction;
            movement.z += ((1f - hitNormal.y) * hitNormal.z) * playerFriction;
        }


        movement.y = charVelocity.y;

        charController.Move(movement * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

    public void Jump(bool isJumping)
    {
        if (isJumping == true)
        {
            // charVelocity.y += jumpPower * Time.deltaTime;
            charVelocity.y = jumpPower;
        }
        else
        {
            charVelocity.y = 0;
            charVelocity.y = playerGravityScale;
            Debug.Log("CANCEL JUMP");
        }
    }

    // public void Looking(Vector2 mouseInput)
    // {
    //     Ray lookRay = Camera.main.ScreenPointToRay(mouseInput);
    //     Plane plane = new Plane(Vector3.up, Vector3.zero);
    //     float distance;
    //     if (plane.Raycast(lookRay, out distance))
    //     {
    //         Vector3 target = lookRay.GetPoint(distance);
    //         Vector3 direction = target - transform.position;
    //         float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    //         transform.rotation = Quaternion.Euler(0, rotation, 0);
    //     }

    // }


}
