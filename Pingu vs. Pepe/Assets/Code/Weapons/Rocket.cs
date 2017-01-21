using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Lifetime))]
[AddComponentMenu("Weapons/Rocket")]
public class Rocket : MonoBehaviour {
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float accelleration;

    private float curSpeed = 0;

    private Lifetime lifetime;

    private void Awake() {
        lifetime = GetComponent<Lifetime>();
    }

    private void Update() {
        if(curSpeed < maxSpeed) {
            curSpeed += accelleration * Time.deltaTime;
            if(curSpeed > maxSpeed) {
                curSpeed = maxSpeed;
            }
        }

        transform.Translate(transform.forward * curSpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision) {
        lifetime.die();
    }
}
