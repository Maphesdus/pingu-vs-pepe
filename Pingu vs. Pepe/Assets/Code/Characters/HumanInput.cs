using UnityEngine;

/// <summary>
/// Takes input from a human player, then calls different scripts depending on the input
/// </summary>
/// The idea here is that we can have a HumanInput, a NetworkInput, an AIInput, etc to represent different things controlling characters
[AddComponentMenu("Controllers/Human Controller")]
class HumanInput : MonoBehaviour {
    [Range(5.0f, 105.0f)]
    public float look_sensitivity;

    private void Update() {
        lookAdjust();

        // Check for inputs, and translate those inputs into commands
        
        if (Input.GetButtonDown("Forward")){//Start moving forwards. Conflicts between directions are handled in the movement script.
            BroadcastMessage("moveF");
        } else if(Input.GetButtonUp("Forward")){
            BroadcastMessage("stopF");
        }

        if (Input.GetButtonDown("Backward")){
            BroadcastMessage("moveB");
        } else if (Input.GetButtonUp("Backward")){
            BroadcastMessage("stopB");
        }

        if (Input.GetButtonDown("Left")){
            BroadcastMessage("moveL");
        }else if (Input.GetButtonUp("Left")){
            BroadcastMessage("stopL");
        }

        if (Input.GetButtonDown("Right")){
            BroadcastMessage("moveR");
        }else if (Input.GetButtonUp("Right")){
            BroadcastMessage("stopR");
        }

        // Using BroadcastMessage instead of an object reference because some guns might want to respond to only one of
        // these messages, and I don't want to deal with methods which may or may not exist
        if(Input.GetButtonDown("Fire1")) {
            BroadcastMessage("startFiring", SendMessageOptions.DontRequireReceiver);
        } else if(Input.GetButtonUp("Fire1")) {
            BroadcastMessage("stopFiring", SendMessageOptions.DontRequireReceiver);
        }

        if(Input.GetButtonDown("Reload")) {
            BroadcastMessage("reload", SendMessageOptions.DontRequireReceiver);
        }

        if(Input.GetButtonDown("Grenade")) {
            BroadcastMessage("throwGrenade");
        }
    }

    void lookAdjust()
    {
        float mouseRotateX = Input.GetAxis("Mouse X") * look_sensitivity;
        transform.Rotate(Vector3.up, mouseRotateX*Time.deltaTime);
    }
}
