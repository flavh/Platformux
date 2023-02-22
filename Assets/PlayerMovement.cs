using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    private bool jump;
    private bool canJump = true;
    private bool dead;
    private Rigidbody2D rigidBody;
    private Animator anim;
    private SpriteRenderer sr;

    [SerializeField] private float speed;

    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        direction = new Vector2(0, 0);
        if (Input.GetKeyDown(KeyCode.Z)) jump = true;
        if (Input.GetKeyUp(KeyCode.Z)) jump = false;
        if (Input.GetKey(KeyCode.Q)) direction.x -= 1;
        if (Input.GetKey(KeyCode.D)) direction.x += 1;
    }

    private void FixedUpdate()
    {
        var pos = transform.position;
        if (jump && canJump)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }

        anim.SetBool("isJumping", !canJump);
        sr.flipX = direction.x < 0;

        transform.position = new Vector2(pos.x + direction.x * speed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) canJump = true;
        if (col.gameObject.CompareTag("Enemy"))
        {
            dead = true;
            anim.SetBool("isDead", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) canJump = false;
    }
}