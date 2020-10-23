using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        int lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(lastSceneIndex);
    }
}
