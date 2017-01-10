using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updated the GUI with the player's information, such as the amount of ammo in their gun
/// </summary>
[AddComponentMenu("Characters/UI Updater")]
public class PlayerGUIUpdater : MonoBehaviour {
    [SerializeField]
    private Text clipCounter;

    [SerializeField]
    private Text ammoCounter;

    // TODO: Be sure to update this reference when the player changes their gun
    private Gun curGun;

    public void Awake() {
        curGun = GetComponentInChildren<Gun>();
    }

    public void Update() {
        clipCounter.text = curGun.getBulletsInClip().ToString();
        ammoCounter.text = curGun.getBulletsNotInClip().ToString();
    }
}
