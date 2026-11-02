using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Range(0, 100)] public int damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        //applies to anything with Player tag
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(damage);
            }            
        }

    }
}
