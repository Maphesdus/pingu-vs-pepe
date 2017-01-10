using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles firing bullets
/// </summary>
/// Bullets are their own script, which is called by this one
[AddComponentMenu("Weapons/Automatic Gun")]
public class AutomaticGun : Gun {
    /// <summary>
    /// How many bullets this gun fires in one second
    /// </summary>
    [SerializeField]
    private float bulletsPerSecond;

    private float lastBulletTime = 0;
        
    private float secondsBetweenBullets;

    private bool firing = false;

    private new void Start() {
        base.Start();
        secondsBetweenBullets = 1.0f / bulletsPerSecond;
        curBulletsInClip = bulletsPerClip;
        curBulletsNotInClip = numBulletsTotal - curBulletsInClip;
        if(bullet == null) {
            Debug.LogError("There is no bullet component attached to this gun. Please attach a bullet component");
        }
    }

    private void startFiring() {
        firing = true;
    }

    private void stopFiring() {
        firing = false;
    }

	private void Update() {
        bool isTimeForAnotherBullet = Time.time > lastBulletTime + secondsBetweenBullets;
        bool areBulletsInClip = curBulletsInClip > 0;

        if(!areBulletsInClip) {
            firing = false;
        }

        if(firing && isTimeForAnotherBullet && areBulletsInClip) {
            bullet.fire(bulletSpawnTransform.position, bulletSpawnTransform.forward);
            lastBulletTime = Time.time;
            curBulletsInClip--;
        }
    }
}
