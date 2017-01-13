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

	public void throwGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, Quaternion.identity);
        Rigidbody grenadeRigidbody = grenade.GetComponent<Rigidbody>();
        grenadeRigidbody.AddForce(throwForce * transform.forward, ForceMode.Impulse);
    }
}
