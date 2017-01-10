using UnityEngine;

[AddComponentMenu("Characters/Damage Taker")]
class DamageTaker : MonoBehaviour {
    [SerializeField]
    private float maxHealth;

    private float currentHealth;

    public void takeDamage(float damage) {
        currentHealth -= damage;
        if(currentHealth < 0) {
            Debug.Log("Health less than 0, I am dead");
        }
    }
}