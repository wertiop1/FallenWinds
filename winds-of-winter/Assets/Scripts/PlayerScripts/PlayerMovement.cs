using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput p_input;
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;

    public float speed = 1.00f;


    // Start is called before the first frame update
    void Start()
    {
        p_input = new PlayerInput();
    }

    private void OnEnable()
    {
        p_input.Movement.Enable();
    }
    
    private void OnDisable()
    {
        p_input.Disable();
    }

    private void FixedUpdate() {

    }
    // Update is called once per frame
    void Update()
    {
        if(p_input.Movement.Up.WasPressedThisFrame) {
            Debug.Log("Up");
        }
    }
}
