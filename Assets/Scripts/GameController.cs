using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public HUDController hudController;
    private int playerScore = 0;
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // already have a Game Controller
        }
        else
        {
            Instance = this;
            // If you move to a new scene keep this game object loaded
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore()
    {
        // add some score
        Debug.Log("Score added!");

        hudController.SetScore("Score " + playerScore);
    }
}
