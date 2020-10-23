using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashTime = 1f;
    [SerializeField] float dashTimeLeft = 0;
    [SerializeField] float keyStrokeDelay = 0.5f;
    float timeLeftArrow;
    float timeRightArrow;
    bool ladt = false;
    bool radt = false;
    PlayerMovement pmScript;
    Rigidbody2D rBody;
    BoxCollider2D body; 


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        GameObject playerGO = GameObject.Find("Player");
        GameObject bodyGO = playerGO.transform.Find("Body").gameObject;
        body = bodyGO.GetComponent<BoxCollider2D>();
        pmScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        DoubleTap();
        if (dashTimeLeft > 0f)
        {
            if (ladt)
            {
                rBody.velocity = new Vector2(-dashSpeed, 0);
            }
            if (radt)
            {
                rBody.velocity = new Vector2(dashSpeed, 0);
            }
        }
        dashTimeLeft -= Time.deltaTime;
        if(dashTimeLeft <= 0f)
        {
            dashTimeLeft = 0f;
            pmScript.MoveOverride(false);
        }
        Crash();
    }

    void DoubleTap()
    {

        ladt = false;
        radt = false;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Time.time < timeLeftArrow + keyStrokeDelay)
            {
                ladt = true;
                pmScript.MoveOverride(true);
                dashTimeLeft = dashTime;    
            }
            timeLeftArrow = Time.time;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Time.time < timeRightArrow + keyStrokeDelay)
            {
                radt = true;
                pmScript.MoveOverride(true);
                dashTimeLeft = dashTime;
            }
            timeRightArrow = Time.time;
        }

    }
    void Crash()
    {
        if (body.IsTouchingLayers(LayerMask.GetMask("Walls", "MovablePlatforms", "DestructiblePlatforms")))
        {
            dashTimeLeft = 0f;
        }
    }

}
