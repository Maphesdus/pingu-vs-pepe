using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles firing bullets
/// </summary>
/// Bullets are their own script, which is called by this one
public class AutomaticTrigger : MonoBehaviour {
    [SerializeField]
    private float bulletsPerSecond;

    [SerializeField]
    private int bulletsPerClip;

    private float lastBulletTime;

    /// <summary>
    /// The number of seconds that should pass between bullets
    /// </summary>
    private float secondsBetweenBullets;
    
	void Start () {
        lastBulletTime = 0;
	}
	
	void Update () {
		
	}
}
