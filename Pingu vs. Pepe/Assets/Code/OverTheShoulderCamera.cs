using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTheShoulderCamera : MonoBehaviour {
    //The target of the camera's focus.
    public Transform camAnchor;

    //Adjust camera left or right.
    [Range(-5, 5)]
    public float camXShift = 0;

    //Adjust camera up or down.
    [Range(-5, 5)]
    public float camYShift = 0;

    //Adjust camera closer or further.
    [Range(0, 5)]
    public float camZShift = 0;

    //The actual point being looked at by the camera. Subject to
    //mouse control.
    Transform camTarget;

    void Start () {
        transform.position = camAnchor.position;
        Vector3 zAxis = camAnchor.rotation * Vector3.forward;
        Vector3 yAxis = Vector3.up;
        Vector3 xAxis = Vector3.Cross(zAxis, yAxis);
        xAxis.Normalize();
        yAxis.Normalize();
        zAxis.Normalize();

        transform.position += xAxis * camXShift + yAxis * camYShift + zAxis * -1 * camZShift;
        transform.rotation = camAnchor.rotation;
    }
	
	void FixedUpdate () {
        Vector3 zAxis = camAnchor.rotation * Vector3.forward;
        Vector3 yAxis = Vector3.up;
        Vector3 xAxis = Vector3.Cross(zAxis, yAxis);
        xAxis.Normalize();
        yAxis.Normalize();
        zAxis.Normalize();

        Vector3 newCamPosition = camAnchor.position;
        newCamPosition += xAxis * camXShift + yAxis * camYShift + zAxis * -1 * camZShift;
        
        //This LERP keeps the camera following behind the target laterally.
        transform.position = Vector3.Lerp(transform.position, newCamPosition, 20.0f * Time.deltaTime);

        transform.rotation = camAnchor.rotation;
    }
}