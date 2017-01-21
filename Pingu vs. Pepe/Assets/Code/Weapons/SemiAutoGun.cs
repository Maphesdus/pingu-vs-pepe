using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Weapons/Semi-auto Gun")]
public class SemiAutoGun : Gun {
    [SerializeField]
    private float bulletsPerSecond;

    private float lastShot = 0;
    private float secondsBetweenBullets;

    private new void Start() {
        base.Start();
        secondsBetweenBullets = 1.0f / bulletsPerSecond;
    }
	
	private void startFiring() {
        bool hasBullets = curBulletsInClip > 0;
        bool canFireAgain = Time.time > lastShot + secondsBetweenBullets;

        if(hasBullets && canFireAgain) {
            bulletSpawner.fire(bulletSpawnTransform.position, bulletSpawnTransform.forward);
            curBulletsInClip--;
        }
    }
}
