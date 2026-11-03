using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite openChest;
    private SpriteRenderer spriteRenderer;
    public int random;
    [Range(0, 100)] public int damage = 20;
    public GameObject prefab;
    public Transform spawn;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && openChest != null)
        {
            random = Random.Range(1,10); // creates random chance for player to take damage or get a potion
            
            if(spriteRenderer != null)
            {
                spriteRenderer.sprite = openChest; //changes sprite when player touches it
            }

            if (random <= 6)
            {
                if (prefab != null & spawn != null)
                {
                    Instantiate(prefab, spawn.position, spawn.rotation); //spawn potion where chest is
                }
            }

            else
            {
                PlayerHealth player = collision.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                    Debug.Log("Took damage!");
                }
            }   

            Destroy(gameObject, 0.5f);
        }
    }
}