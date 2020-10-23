using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAutodestruct : MonoBehaviour
{
    [SerializeField] float dTime = 1f;
    GameObject playerGO;
    GameObject feetGO;
    BoxCollider2D feet;
    BoxCollider2D trigger;
    Color tmp;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");
        feetGO = playerGO.transform.Find("Feet").gameObject;
        feet = feetGO.GetComponent<BoxCollider2D>();
        trigger = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D trigger)
    {
        tmp = gameObject.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        Destroy(gameObject, dTime);
    }
}
