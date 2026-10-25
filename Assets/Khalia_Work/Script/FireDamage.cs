using UnityEngine;

public class FireDamage : MonoBehaviour
{
    //make player take periodic damage ever few seconds whenever they stay in collider
    [Range(0, 100)] public float damage = 5;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage * Time.deltaTime);
            }            
        }

    }
}