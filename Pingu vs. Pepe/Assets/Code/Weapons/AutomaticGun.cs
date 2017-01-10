﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles firing bullets
/// </summary>
/// Bullets are their own script, which is called by this one
[AddComponentMenu("Guns/Automatic Gun")]
[RequireComponent(typeof(Bullet))]
public class AutomaticGun : Gun {
    /// <summary>
    /// How many bullets this gun fires in one second
    /// </summary>
    [SerializeField]
    private float bulletsPerSecond;

    /// <summary>
    /// The Transform that bullets should start from. Should be located a little bit in front of the gun's muzzle
    /// </summary>
    [SerializeField]
    private Transform bulletSpawnTransform;

    private float lastBulletTime = 0;
    private Bullet bullet;
        
    private float secondsBetweenBullets;

    private bool firing = false;
    
	private void Awake() {
        // I just like Awake more than Start, idk

        secondsBetweenBullets = 1.0f / bulletsPerSecond;
        bullet = GetComponent<Bullet>();
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

    private void reload() {
        if(curBulletsNotInClip > 0) {
            int bulletsNeededForFullClip = bulletsPerClip - curBulletsInClip;
            int bulletsToAdd = Mathf.Min(curBulletsNotInClip, bulletsNeededForFullClip);    // Can't add more bullets than we have!

            curBulletsInClip += bulletsToAdd;
            curBulletsNotInClip -= bulletsToAdd;
        }
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
