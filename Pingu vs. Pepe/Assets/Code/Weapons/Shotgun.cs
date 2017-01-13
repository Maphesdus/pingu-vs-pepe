using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple shotgun. Fires as fast as you can pull the trigger
/// </summary>
[AddComponentMenu("Weapons/Shotgun")]
public class Shotgun : Gun {
    /// <summary>
    /// How many bullets are fired in a single shot
    /// </summary>
    [SerializeField]
    private float bulletsPerShot;

    /// <summary>
    /// The spread of the bullets, in degrees
    /// </summary>
    [SerializeField]
    private float weaponSpread;

    private void startFiring() {
        if(curBulletsInClip > 0) {
            float sphereSize = Mathf.Tan(weaponSpread * Mathf.Deg2Rad);

            for(int i = 0; i < bulletsPerShot; i++) {
                Vector3 offset = Random.onUnitSphere * sphereSize;
                Debug.Log("Firing bullet wirh offset " + offset);
                Vector3 bulletDirection = bulletSpawnTransform.forward + offset;
                bulletSpawner.fire(bulletSpawnTransform.position, bulletDirection);
            }

            curBulletsInClip--;
        }
    }
}
