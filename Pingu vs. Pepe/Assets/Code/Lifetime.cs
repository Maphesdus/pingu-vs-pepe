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
    
    [SerializeField]
    private GameObject replacement;

    [SerializeField]
    private Vector3 replacementOffset;

    IEnumerator Start() {
        //Debug.Break();
        yield return new WaitForSeconds(lifetime);
        die();
    }

    public void die() {
        transform.DetachChildren();
        ParticleSystem[] particles = GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in particles) {
            Lifetime lifetime = p.GetComponent<Lifetime>();
            if(lifetime != null) {
                lifetime.enabled = true;
            }
        }

        if(replacement) {
            Instantiate(replacement, transform.position + replacementOffset, transform.rotation);
        }
        Destroy(gameObject);
    }
}
