using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public HUDController hudController;
    private int playerScore = 0;
    private int keysCollected = 0;
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

    public void AddKey()
    {
        keysCollected++;
        hudController.SetKeys("Keys " + keysCollected);
        Debug.Log("Keys collected " + keysCollected);
    }

    public bool UseKey()
    {
        if (keysCollected > 0)
        {
            keysCollected--;
            return true;
        }
        return false;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Score", playerScore);
        playerScore = PlayerPrefs.GetInt("Score");
    }
}
