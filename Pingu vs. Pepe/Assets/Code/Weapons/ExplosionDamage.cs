using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals damage to all things within a certain radius
/// </summary>
/// Explosion damage falls off exponentially such that someone near the explosion recieves max damage, and someone 
/// standing just on the edge of the explosion recieves no damage
[AddComponentMenu("Weapons/Explosion Damage")]
public class ExplosionDamage : MonoBehaviour {
    /// <summary>
    /// The size of the sphere near the explosion where you'll receive max damage
    /// </summary>
    [SerializeField]
    private float maxDamageRadius;

    /// <summary>
    /// The radius within which things will recieve damage
    /// </summary>
    [SerializeField]
    private float radius;

    /// <summary>
    /// How much damage this explosion does
    /// </summary>
    [SerializeField]
    private float damage;
    
	void Start () {
        float falloffDamageDistance = radius - maxDamageRadius;
        float damageAtMaxRadius = damage / (falloffDamageDistance * falloffDamageDistance);

        Collider[] thingsWithinRange = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider c in thingsWithinRange) {
            DamageTaker damageTaker = c.gameObject.GetComponent<DamageTaker>();
            if(damageTaker != null) {
                dealDamage(damageTaker, falloffDamageDistance, damageAtMaxRadius);
            }
        }
	}

    private void dealDamage(DamageTaker damageTaker, float falloffDamageDistance, float damageAtMaxRadius) {
        float distFromExplosion = Vector3.Distance(damageTaker.transform.position, transform.position);
        if(distFromExplosion < maxDamageRadius) {
            damageTaker.takeDamage(damage);

        } else {
            float distFromMaxDamage = (distFromExplosion - maxDamageRadius);
            float damageDealt = damage / (distFromMaxDamage * distFromMaxDamage);
            float closenessToMaxDist = distFromMaxDamage / falloffDamageDistance;
            damageDealt -= damageAtMaxRadius * closenessToMaxDist;

            damageTaker.takeDamage(damageDealt);
        }
    }

    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, maxDamageRadius);
    }
}
