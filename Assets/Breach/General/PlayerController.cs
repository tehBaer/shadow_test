using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    public PlayerInputActions pia;
    public float moveSpeed = 1.5f;
    private InputAction move;
    private InputAction jump;
    public float jumpSpeed = 2f;
    public bool animate = true;

    private Rigidbody rb;
    private Animator anim;

    Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        if (!animate)
        {
            anim.enabled = false;
        }
    }

    void Awake()
    {
        pia = new PlayerInputActions();
    }

    private void OnEnable()
    {
        move = pia.Player.Move;
        move.Enable();

        jump = pia.Player.Jump;
        jump.Enable();
        jump.performed += Jump;

    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        if (moveDirection != new Vector2(0, 0))
        {
            rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
            Vector3 movement = new Vector3(moveDirection.x, 0.0f, moveDirection.y);
            transform.rotation = Quaternion.LookRotation(movement);

        }
        else
        {
            if (animate)
            {
                anim.Play("Base Layer.walk", 0, 0.0f); // suboptimal solution
            }

        }
    }


    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpSpeed);
    }

}
