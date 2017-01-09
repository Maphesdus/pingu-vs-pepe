using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles firing bullets
/// </summary>
/// Bullets are their own script, which is called by this one
[AddComponentMenu("Guns/Triggers/Automatic Trigger")]
[RequireComponent(typeof(Bullet))]
public class AutomaticTrigger : MonoBehaviour {
    [SerializeField]
    private float bulletsPerSecond;

    [SerializeField]
    private int bulletsPerClip;

    [SerializeField]
    private Transform bulletSpawnTransform;

    private float lastBulletTime;
    private Bullet bullet;

    /// <summary>
    /// The number of seconds that should pass between bullets
    /// </summary>
    private float secondsBetweenBullets;
    
	void Awake() {
        lastBulletTime = 0;
        secondsBetweenBullets = 1.0f / bulletsPerSecond;
        bullet = GetComponent<Bullet>();
        if(bullet == null) {
            Debug.LogError("There is no bullet component attached to this gun. Please attach a bullet component");
        }
	}
	
	void Update() {
		if(Input.GetButton("Fire1") && Time.time > lastBulletTime + secondsBetweenBullets) {
            bullet.fire(bulletSpawnTransform.position, bulletSpawnTransform.forward);
            lastBulletTime = Time.time;
        }
	}
}
