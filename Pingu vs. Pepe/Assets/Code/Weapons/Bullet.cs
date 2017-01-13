using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour {
    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float range;

    public abstract void fire(Vector3 startPos, Vector3 direction);
}
