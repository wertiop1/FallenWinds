using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private InputAction move;

    public Rigidbody2D rb;
    public Animator animator;
    //public SpriteRenderer spriteRenderer;
    public PlayerInputActions PlayerControls; 
    
    public float limit = 1f;
    public float moveSpeed = 5.00f;

    Vector2 moveDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<spriteRenderer>();
    }
    private void Awake() {
        PlayerControls = new PlayerInputActions();
    }

    private void OnEnable() {
        move = PlayerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable() {
        move.Disable();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
/*

    private bool tryMove(Vector2 direction, float limit)
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction,
            limit
            );
        if (!hit)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            return true;
        } else {
            Debug.Log("hit:" + hit.collider.name);
            return false;
        }
    }
*/
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        if(moveDirection.x > 0)
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isSide", true);
            //spriteRenderer.flipX = false;
            //transform.Rotation.y = 0;
        } else if (moveDirection.x < 0) 
        {
            animator.SetBool("isMoving", true);
            animator.SetBool("isSide", true);
            //spriteRenderer.flipX = true;
            //transform.Rotation.y = -180;
        }
        
    }

}

