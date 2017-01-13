﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[AddComponentMenu("Weapons/Bullets/Raycast Bullet")]
class RaycastBullet : BulletSpawner {
    /// <summary>
    /// The particle effect to show when the bullet hits something
    /// </summary>
    [SerializeField]
    private GameObject hitParticles;

    public override void fire(Vector3 startPos, Vector3 direction) {
        RaycastHit hit;
        if(Physics.Raycast(startPos, direction, out hit, range)) {
            DamageTaker hitDamageTaker = hit.collider.gameObject.GetComponent<DamageTaker>();
            if(hitDamageTaker != null) {
                hitDamageTaker.takeDamage(damage);
            }

            Debug.DrawLine(startPos, hit.point);

            Instantiate(hitParticles, hit.point, Quaternion.Euler(hit.normal));
        }
    }
}