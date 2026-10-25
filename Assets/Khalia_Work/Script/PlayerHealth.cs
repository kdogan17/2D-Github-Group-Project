using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 100)] public float health = 100;
    public float currentHealth;
    Animator animator;

    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float num)
    {
        currentHealth -= num;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
