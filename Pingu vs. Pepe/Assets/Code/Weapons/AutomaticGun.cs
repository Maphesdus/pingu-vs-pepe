using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles firing bullets
/// </summary>
/// Bullets are their own script, which is called by this one
[AddComponentMenu("Guns/Automatic Gun")]
[RequireComponent(typeof(Bullet))]
public class AutomaticGun : MonoBehaviour {
    /// <summary>
    /// How many bullets this gun fires in one second
    /// </summary>
    [SerializeField]
    private float bulletsPerSecond;

    /// <summary>
    /// When the player has may ammo for this gun, how many bullets do they have?
    /// </summary>
    [SerializeField]
    private int numBulletsTotal;

    /// <summary>
    /// How many bullets are stored in one clip of this gun
    /// </summary>
    [SerializeField]
    private int bulletsPerClip;

    /// <summary>
    /// The Transform that bullets should start from. Should be located a little bit in front of the gun's muzzle
    /// </summary>
    [SerializeField]
    private Transform bulletSpawnTransform;

    private float lastBulletTime = 0;
    private Bullet bullet;
    private int curBulletsInClip;
    private int curBulletsNotInClip;
    
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
            int bulletsToAdd = Mathf.Max(curBulletsNotInClip, bulletsNeededForFullClip);    // Can't add more bullets than we have!

            curBulletsInClip += bulletsToAdd;
            curBulletsNotInClip -= bulletsToAdd;
        }
    }

	private void Update() {
        bool isTimeForAnotherBullet = Time.time > lastBulletTime + secondsBetweenBullets;
        bool areBulletsInClip = curBulletsInClip > 0;

        if(firing && isTimeForAnotherBullet && areBulletsInClip) {
            bullet.fire(bulletSpawnTransform.position, bulletSpawnTransform.forward);
            lastBulletTime = Time.time;
            curBulletsInClip--;
        }
    }
}
