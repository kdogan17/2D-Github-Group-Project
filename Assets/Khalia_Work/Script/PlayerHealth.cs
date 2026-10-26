using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Range(0, 100)] public float health = 100;
    public float currentHealth;
    Animator animator;

    // Sets timer for immunity
    public float hitCooldown = 0.5f;
    public float currentTimer = 0f;

    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(1f);
        }
        if (collision.CompareTag("Boss"))
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float num)
    {
        // Wait for immunity before registering next hit
        if (Time.time < currentTimer) return;


        currentTimer = Time.time + hitCooldown;

        // Does damage and kills player if dead
        currentHealth -= num;
        Debug.Log("You took damage.");
        Debug.Log("Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            FindAnyObjectByType<SoundsManager>().PlaySong("1_dying");
            FindAnyObjectByType<GameManager>().LoseGame(); //searches scene for LoseGame()
            Destroy(gameObject);
        }
    }
}
