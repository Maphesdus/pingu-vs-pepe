using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Player Movement")]
public class PlayerMovement : MonoBehaviour {
    public GameObject cam;
    public float speed = 3.0f;
    public float jumpPower = 3.0f;
    public float gravity = -9.8f;

    private CharacterController _charController;
    private Vector3 delta;
    private Vector3 movement;

    private bool forward;
    private bool strafeRight;
    private bool strafeLeft;
    private bool backtrack;

    private bool grounded = true;

    // START:
    void Start () {
        _charController = GetComponent<CharacterController>();
	} // END START

	
	// UPDATE:
	void Update () {
        delta = new Vector3(Input.GetAxis("Horizontal") * speed, gravity, Input.GetAxis("Vertical") * speed);
        movement = new Vector3(delta.x, delta.y, delta.z);

        movement = Vector3.ClampMagnitude(movement, speed); // Limit the speed of diagonal movement to be the same as that of regular movement.
        movement *= Time.deltaTime;                         // Make movement speed independent of framerate.
        movement = transform.TransformDirection(movement);  // Transform the movement vector from local to global coordinates.
        _charController.Move(movement);                     // Tell the character controller to move by the given vector.

        if (Input.GetAxis("Jump") != 0.0f) { grounded = false; }

    } // END UPDATE


    // ON COLLISION ENTER:
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") { grounded = true; }
    }

    void moveF(){
        if(!backtrack) forward = true;
        else backtrack = forward = false;
    }

    void stopF()
    {
        forward = false;
    }

    void moveB()
    {
        if (!forward) backtrack = true;
        else backtrack = forward = false;
    }

    void stopB()
    {
        backtrack = false;
    }

    void moveL()
    {
        if (!strafeRight) strafeLeft = true;
        else strafeLeft = strafeRight = false;
    }

    void stopL()
    {
        strafeLeft = false;
    }

    void moveR()
    {
        if (!strafeLeft) strafeRight = true;
        else strafeRight = strafeLeft = false;
    }

    void stopR()
    {
        strafeRight = false;
    }

    // ON COLLISION EXIT:
    //void OnCollisionExit(Collision col) {
        //if (col.gameObject.tag == "Ground") { grounded = false; }
    //}
}