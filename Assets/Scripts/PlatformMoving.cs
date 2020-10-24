using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{

    [SerializeField] float platformSpeed = 3f;
    [SerializeField] Boolean isFacingRight = true;


    private Rigidbody2D rBody;
    private Rigidbody2D pBody;
    GameObject playerGO;
    BoxCollider2D feet;
    CircleCollider2D bumper;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.isKinematic = true;
        playerGO = GameObject.Find("Player");
        pBody = playerGO.GetComponent<Rigidbody2D>();
        GameObject feetGO = playerGO.transform.Find("Feet").gameObject;
        feet = feetGO.GetComponent<BoxCollider2D>();
        this.GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction = isFacingRight ? new Vector3(1, 0, 0) : new Vector3(-1, 0, 0);
        
        //Powiązanie ruchu playera z plattformą bez parentingu, nie do końca mi się podoba moja implementacja ale działa i się player nie zssuwa.
        if (feet.IsTouchingLayers(LayerMask.GetMask("MovablePlatforms")))
        {
            if (!((Input.GetAxis("Horizontal") != 0) || Input.GetKey("space")))
            {
                rBody.MovePosition(transform.position + direction * platformSpeed * Time.fixedDeltaTime);
                pBody.MovePosition(pBody.transform.position + direction * platformSpeed * Time.fixedDeltaTime);
            }
            else
            {
                rBody.MovePosition(transform.position + direction * platformSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            rBody.MovePosition(transform.position + direction * platformSpeed * Time.fixedDeltaTime);
        }
    }

    //Odwracanie platformy (platforma automatycznie odwraca się przy zderzeniu)
    void OnTriggerEnter2D(Collider2D bumper)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(transform.localScale.x)), 1f);
        if (isFacingRight) 
        {
            isFacingRight = false;
        } else
        {
            isFacingRight = true;
        }
    }

    //sprawdzanie kierunku poruszania
    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
}
