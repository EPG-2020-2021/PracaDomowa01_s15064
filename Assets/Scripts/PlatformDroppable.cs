using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDroppable : MonoBehaviour
{
    //Drop timing
    [SerializeField] float dropTime = 1f;

    //Object & Component cache

    //Platforms
    private PlatformEffector2D platformEffector;
    private BoxCollider2D platformCollider;
    GameObject playerGO;
    Rigidbody2D playerRigidbody;
    BoxCollider2D bodyCollider;
    BoxCollider2D feetCollider;


    //Initialization
    void Start()
    {

        platformEffector = GetComponent<PlatformEffector2D>();
        platformCollider = GetComponent<BoxCollider2D>();
        playerGO = GameObject.Find("Player");
        playerRigidbody = playerGO.GetComponent<Rigidbody2D>();
        bodyCollider = playerGO.transform.Find("Body").gameObject.GetComponent<BoxCollider2D>();
        feetCollider = playerGO.transform.Find("Feet").gameObject.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, bodyCollider, true);


    }


    void Update()
    {

        if (Input.GetAxis("Vertical") < 0)
        {
            StartCoroutine(FallTimer());
        }

    }

    IEnumerator FallTimer()
    {
        Physics2D.IgnoreCollision(platformCollider, feetCollider, true);
        Physics2D.IgnoreCollision(platformCollider, bodyCollider, true);
        yield return new WaitForSeconds(dropTime);
        Physics2D.IgnoreCollision(platformCollider, feetCollider, false);
    }
}
