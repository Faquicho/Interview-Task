using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2d;
    Vector2 moveInput;
    [SerializeField] float moveSpeed;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {

    }


    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 playerVelocity = new Vector2((moveInput.x * moveSpeed), (moveInput.y * moveSpeed));
        rb2d.velocity = playerVelocity;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
