using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows a character to throw a grenade
/// </summary>
[AddComponentMenu("Weapons/Grenade Thrower")]
public class GrenadeThrower : MonoBehaviour {
    [SerializeField]
    private GameObject grenadePrefab;

    [SerializeField]
    private float throwForce;

	public void throwGrenade(Vector3 startPos, Vector3 direction) {
        GameObject grenade = Instantiate(grenadePrefab, startPos, Quaternion.identity);
        Rigidbody grenadeRigidbody = grenade.GetComponent<Rigidbody>();
        grenadeRigidbody.AddForce(throwForce * direction);
    }
}
