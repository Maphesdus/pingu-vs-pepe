using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuFunctions : MonoBehaviour {
    bool paused;
    bool gameStart = false;
    public GameObject pauseMenu;

    void Start()
    {
        //Game begins paused.
        Time.timeScale = 0;
        paused = true;
        gameStart = false;
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }

    public void startGame()
    {
        unPauseGame();
        gameStart = true;
    }

    public void endGame()
    {
        paused = true;
        Time.timeScale = 0;
        gameStart = false;
    }

    public void pauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void unPauseGame()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    
	// Update is called once per frame
	void Update () {
        if (gameStart && Input.GetKeyDown(KeyCode.P))
        {
            if (paused) unPauseGame();
            else pauseGame();
        }
	}
}
