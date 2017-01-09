using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour {
    [SerializeField]
    protected float damage;

    [SerializeField]
    protected float range;

    public abstract void fire(Vector3 startPos, Vector3 direction);
}
