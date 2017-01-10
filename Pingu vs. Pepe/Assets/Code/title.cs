using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {
    public GUISkin skin;

    // ON GUI:
    void OnGUI() {
        GUI.skin = skin;
        if (GUI.Button(new Rect((Screen.width / 2) - 75, Screen.height / 2 + 50, 150, 50), "Play!")) {
            Debug.Log("Play");
            SceneManager.LoadScene(1);
        } // END IF

        if (GUI.Button(new Rect((Screen.width / 2) - 75, (Screen.height / 2) + 103, 150, 50), "Quit")) {
            Debug.Log("Quit");
            Application.Quit();
        } // END IF
    }
}
