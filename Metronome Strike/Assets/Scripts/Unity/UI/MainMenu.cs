using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;

    // Update is called once per frame
    void Update()
    {
      
    }

    public void LoadGame()
    {
        Debug.Log("Loading Game...");
 
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("QUITING GAME!");
        Application.Quit();
    }
}
