using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    //CONST

    private PlayerController controls;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private PlayerMovement playerMovement;
    private ShootSpawner playerShoot;
    private bool jumpInput;

    private void Awake()
    {
        controls = new PlayerController();
        playerShoot = GetComponent<ShootSpawner>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        controls.PlayerCharacter.Move.performed += HandleMovement => moveInput = HandleMovement.ReadValue<Vector2>();
        controls.PlayerCharacter.Move.canceled += HandleMove => moveInput = Vector2.zero;
        controls.PlayerCharacter.Look.performed += HanddleLook => lookInput = HanddleLook.ReadValue<Vector2>();
        controls.PlayerCharacter.Jump.performed += HandleJump => jumpInput = true;
        controls.PlayerCharacter.Jump.canceled += HandleJump => jumpInput = false;
        controls.PlayerCharacter.Shoot.performed += HandleShoot;
        controls.Enable();
    }

    private void HandleShoot(InputAction.CallbackContext context)
    {
        playerShoot.Shoot();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.Move(moveInput);
      //  playerMovement.Looking(lookInput);



        playerMovement.Jump(jumpInput);
        Debug.Log("jump is being called");
        Debug.Log("THIS jump value  " + jumpInput);
    
        //Shader position
        Shader.SetGlobalVector("_PlayerPos", transform.position);
    }

    void OnDisable()
    {
        controls.PlayerCharacter.Move.performed -= HandleMovement => moveInput = HandleMovement.ReadValue<Vector2>();
        controls.PlayerCharacter.Move.canceled -= HandleMove => moveInput = Vector2.zero;
        controls.PlayerCharacter.Look.performed -= HanddleLook => lookInput = HanddleLook.ReadValue<Vector2>();
        controls.PlayerCharacter.Jump.performed -= HandleJump => jumpInput = true;
        controls.PlayerCharacter.Jump.canceled -= HandleJump => jumpInput = false;
        controls.Disable();
    }

}
