using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script to kill things after a certain number of seconds
/// </summary>
[AddComponentMenu("Utility/Lifetime")]
public class Lifetime : MonoBehaviour {
    [SerializeField]
    private float lifetime;

	void Start () {
        Destroy(this, lifetime);
	}
}
