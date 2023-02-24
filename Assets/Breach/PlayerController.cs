using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public PlayerInputActions pia;
    public DefaultInputActions dia;
    public float moveSpeed;
    private InputAction move;

    private Rigidbody rb;

    // private Vector2 moveDirection;
    Vector2 moveDirection = Vector2.zero;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
    }
    
    void Awake(){
        pia = new PlayerInputActions();
        dia = new DefaultInputActions();
    }

    private void OnEnable(){
        move = dia.Player.Move;
        move.Enable();
    }

    private void OnDisable(){
        move.Disable();
    }

    void Update(){
        moveDirection = move.ReadValue<Vector2>();
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }



}
