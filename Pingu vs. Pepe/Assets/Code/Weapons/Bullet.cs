using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletSpawner : MonoBehaviour {
    public abstract void fire(Vector3 startPos, Vector3 direction);
}
