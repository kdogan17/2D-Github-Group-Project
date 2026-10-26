using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemy : MonoBehaviour
{
    public Transform target; //put the chef player in the editor
    public float speed = 3f;

    Rigidbody2D body;

    public GameObject spawner;

    public int bossHealth; //unsure how many hits this guy takes, change accordingly

    public bool isInvincible;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        
        body = GetComponent<Rigidbody2D>();

        bossHealth = 5; //can change health to whatever. might not collide perfectly with sword, so troubleshoot as needed
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (bossHealth == 0) //for some reason it kills him with one health left but. whatever. can work around this
        {
            Destroy(gameObject);
            //this is the win condition, add win UI
            SceneManager.LoadScene("Win_UI");
        }
    }

    // This one keeps slime movement but prevents them from pushing the player out of the map
    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(body.position, target.position, speed * Time.fixedDeltaTime);
        body.MovePosition(newPos);
    }

    private void OnCollisionEnter2D(Collision2D collision) //THIS IS FOR ENEMY HEALTH
    {
        if (collision.gameObject.name.Equals("weapon") && !isInvincible) //same as slimes, change this to when touching sword
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
