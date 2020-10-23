using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    GameObject playerGO;
    BoxCollider2D body;
    BoxCollider2D feet;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");
        body = playerGO.transform.Find("Body").gameObject.GetComponent<BoxCollider2D>();
        feet = playerGO.transform.Find("Feet").gameObject.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerKill();
    }

    void PlayerKill()
    {
        if (feet.IsTouchingLayers(LayerMask.GetMask("Hazards")) || body.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            int lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(lastSceneIndex);
        }
    }
}
