using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns a GameObeject for each bullet fired
/// </summary>
[AddComponentMenu("Weapons/Bullets/Projectile Bullet ")]
public class ProjectileBullet : BulletSpawner {
    /// <summary>
    /// The prefab to spawn when this gun is fired
    /// </summary>
    [SerializeField]
    private GameObject projectile;

    public override void fire(Vector3 startPos, Vector3 direction) {
        Instantiate(projectile, startPos, Quaternion.LookRotation(direction));
        //Debug.Break();
    }
}
