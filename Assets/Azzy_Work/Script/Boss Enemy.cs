using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public Transform target; //put the chef player in the editor
    public float speed = 3f;

    Rigidbody2D body;

    public GameObject spawner = GameObject.FindWithTag("Spawner");

    public int bossHealth; //unsure how many hits this guy takes, change accordingly

    public bool isInvincible;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        bossHealth = 5; //can change health to whatever. might not collide perfectly with sword, so troubleshoot as needed
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (bossHealth == 0) //for some reason it kills him with one health left but. whatever. can work around this
        {
            Destroy(gameObject);
            //this is the win condition, add win UI
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //THIS IS FOR ENEMY HEALTH
    {
        if (collision.gameObject.name.Equals("Square") && !isInvincible) //same as slimes, change this to when touching sword
        {                                                                //this is also a little broken so troubleshoot sword collisions
            Debug.Log("boss ouchie " + bossHealth);
            bossHealth -= 1;

            isInvincible = true;
            Invoke("ResetInvincibility", 2); //invokes the invisibility function after 2 seconds
        }
    }

    public void ResetInvincibility()
    {
        isInvincible = false;
    }
}
