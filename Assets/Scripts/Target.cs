using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public GameObject destroyedVersion;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
