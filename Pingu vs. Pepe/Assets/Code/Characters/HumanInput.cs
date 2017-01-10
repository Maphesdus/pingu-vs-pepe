﻿using UnityEngine;

/// <summary>
/// Takes input from a human player, then calls different scripts depending on the input
/// </summary>
/// The idea here is that we can have a HumanInput, a NetworkInput, an AIInput, etc to represent different things controlling characters
[AddComponentMenu("Controllers/Human Controller")]
class HumanInput : MonoBehaviour {
    private void Update() {
        // Check for inputs, and translate those inputs into commands

        // Using BroadcastMessage instead of an object reference because some guns might want to respond to only one of
        // these messages, and I don't want to deal with methods which may or may not exist
        if(Input.GetButtonDown("Fire1")) {
            BroadcastMessage("startFiring");
        } else if(Input.GetButtonDown("Fire1")) {
            BroadcastMessage("stopFiring");
        }

        if(Input.GetButtonDown("Reload")) {
            BroadcastMessage("reload");
        }
    }
}
