
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthPotion : MonoBehaviour
{
    public int potions = 3;
    public float healAmount = 25;

    private PlayerHealth playerHealth; //references player health

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void Heal(InputAction.CallbackContext context)
    {
        if (context.performed && potions > 0)
        {
            if (playerHealth.currentHealth < playerHealth.health)
            {
                playerHealth.currentHealth += healAmount;

                if (playerHealth.currentHealth > playerHealth.health)
                {
                    playerHealth.currentHealth = playerHealth.health;
                }

                potions--;

            }
        }
    }
    public void AddPotion()
{
    if (potions < 3) {
    potions++;
    }
}
}