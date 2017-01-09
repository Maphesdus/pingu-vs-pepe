using UnityEngine;
using System.Collections;

public class followTarget : MonoBehaviour {
    public GameObject target;
    private Vector3 targetPos;
    private Quaternion targetRot;
    public Vector3 offset;

    public bool rotateWithTarget = false;

    // START:
    void Start () {

    }
	
	// UPDATE:
	void Update () {
        targetPos = target.transform.position;
        targetRot = target.transform.rotation;

        this.transform.position = target.transform.position - offset;

        if (rotateWithTarget) this.transform.rotation = targetRot;
	}
}
