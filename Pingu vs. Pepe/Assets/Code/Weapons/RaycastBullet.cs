using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class RaycastBullet : Bullet {
    public override void fire(Vector3 startPos, Vector3 direction) {
        RaycastHit hit;
        if(Physics.Raycast(startPos, direction, out hit, range)) {
            DamageTaker hitDamageTaker = hit.collider.gameObject.GetComponent<DamageTaker>();
            if(hitDamageTaker != null) {
                hitDamageTaker.takeDamage(damage);
            }


        }
    }
}