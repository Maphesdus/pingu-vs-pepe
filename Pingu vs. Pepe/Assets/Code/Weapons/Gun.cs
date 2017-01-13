using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a generic gun
/// </summary>
/// This class only stores information about the gun's clip size and number of total bullets. If I wanted to be modular
/// and plan properly I might make the clip information a separate component, but I'm not super into that idea
[RequireComponent(typeof(BulletSpawner))]
public abstract class Gun : MonoBehaviour {
    /// <summary>
    /// When the player has may ammo for this gun, how many bullets do they have?
    /// </summary>
    [SerializeField]
    protected int numBulletsTotal;

    /// <summary>
    /// How many bullets are stored in one clip of this gun
    /// </summary>
    [SerializeField]
    protected int bulletsPerClip;

    /// <summary>
    /// The Transform that bullets should start from. Should be located a little bit in front of the gun's muzzle
    /// </summary>
    [SerializeField]
    protected Transform bulletSpawnTransform;

    protected int curBulletsInClip;
    protected int curBulletsNotInClip;
    protected BulletSpawner bulletSpawner;

    public void Start() {
        curBulletsInClip = bulletsPerClip;
        curBulletsNotInClip = numBulletsTotal - curBulletsInClip;

        bulletSpawner = GetComponent<BulletSpawner>();
        if(bulletSpawner == null) {
            Debug.LogError("There is no bullet component attached to this gun. Please attach a bullet component");
        }
    }

    public int getBulletsInClip() {
        return curBulletsInClip;
    }

    public int getBulletsNotInClip() {
        return curBulletsNotInClip;
    }

    private void reload() {
        if(curBulletsNotInClip > 0) {
            int bulletsNeededForFullClip = bulletsPerClip - curBulletsInClip;
            int bulletsToAdd = Mathf.Min(curBulletsNotInClip, bulletsNeededForFullClip);    // Can't add more bullets than we have!

            curBulletsInClip += bulletsToAdd;
            curBulletsNotInClip -= bulletsToAdd;
        }
    }
}
