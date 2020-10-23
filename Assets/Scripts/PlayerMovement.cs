using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Vars
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float playerRunMultiplier = 2f;
    [SerializeField] public float jumpSpeed = 5f;
    private bool mOverride = false;
    //Cache
    GameObject playerGO;
    GameObject bodyGO;
    GameObject feetGO;

    Rigidbody2D rbody;
    BoxCollider2D body;
    BoxCollider2D feet;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");
        bodyGO = playerGO.transform.Find("Body").gameObject;
        feetGO = playerGO.transform.Find("Feet").gameObject;

        rbody = GetComponent<Rigidbody2D>();
        body = bodyGO.GetComponent<BoxCollider2D>();
        feet = feetGO.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!mOverride)
        {
            Move();
        }
        Jump();
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector2 playerVelocity;

        if (Input.GetKey("space") && body.IsTouchingLayers(LayerMask.GetMask("Walls", "MovablePlatforms", "DestructiblePlatforms")))

        {
            playerVelocity = new Vector2(0, rbody.velocity.y);
        }
        else

        {
            if (Input.GetKey("left shift"))
            {
                inputX = inputX * playerRunMultiplier;
            }
            playerVelocity = new Vector2(inputX * playerSpeed, rbody.velocity.y);
        }

        rbody.velocity = playerVelocity;
    }

    void Jump()
    {
        if (Input.GetKey("space") && feet.IsTouchingLayers(LayerMask.GetMask("Ground", "MovablePlatforms", "DestructiblePlatforms")))
        {
            Vector2 VelocityToAdd = new Vector2(0f, jumpSpeed);
            rbody.velocity += VelocityToAdd;
        }
    }

    public void MoveOverride(bool o)
    {
        if (o)
        {
            mOverride = true;
        } else
        {
            mOverride = false;
        }
    }

}
