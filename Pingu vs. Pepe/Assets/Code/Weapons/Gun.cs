using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a generic gun
/// </summary>
/// This class only stores information about the gun's clip size and number of total bullets. If I wanted to be modular
/// and plan properly I might make the clip information a separate component, but I'm not super into that idea
public class Gun : MonoBehaviour {
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

    protected int curBulletsInClip;
    protected int curBulletsNotInClip;

    public int getBulletsInClip() {
        return curBulletsInClip;
    }

    public int getBulletsNotInClip() {
        return curBulletsNotInClip;
    }
}
