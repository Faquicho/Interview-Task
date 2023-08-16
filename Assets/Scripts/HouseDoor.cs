using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoor : MonoBehaviour
{
    private int currentSceneIndex;

    private void Awake()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentSceneIndex);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (currentSceneIndex == 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            { SceneManager.LoadScene(0);}
        }
    }
}
