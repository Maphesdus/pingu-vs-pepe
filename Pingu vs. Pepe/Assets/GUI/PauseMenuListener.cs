using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuListener : MonoBehaviour {

    void pauseGame()
    {
        Debug.Log("Got it");
        gameObject.SetActive(true);
    }

    void unPauseGame()
    {
        gameObject.SetActive(false);
    }

}
