using UnityEngine;
using System.Collections;

public class movement2 : MonoBehaviour {
    Rigidbody rBody = null;
	Vector3 moveVector;
    Quaternion rotateQuaternion;

    public float moveSpeed = 5.0f;
    public float rotateSpeed = 90.0f;

	// START:
	void Start () {
        rBody = GetComponent<Rigidbody>();
	}
	
	// UPDATE:
	void Update () {
		moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rBody.MovePosition(rBody.position + moveVector * moveSpeed * Time.deltaTime);

        rotateQuaternion = new Quaternion(0, Input.GetAxisRaw("Horizontal"), 0, 1);
        rBody.MoveRotation(rotateQuaternion * Quaternion.Euler(transform.localRotation.eulerAngles));
        //rBody.MoveRotation(rotateQuaternion);
    }
}