using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeFollow : MonoBehaviour
{

    public Transform target; //put the chef player in the editor
    public float speed = 3f;

    Rigidbody2D body;

    public GameObject spawner;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");

        body = GetComponent<Rigidbody2D>();

        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // slime position changes. transform is slime. target is chef. speed is speed

    }

    // This one keeps slime movement but prevents them from pushing the player out of the map
    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(body.position, target.position, speed * Time.fixedDeltaTime);
        body.MovePosition(newPos);
    }

    //this version kills the slimes when touching player, change this to touching the sword
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("weapon")) //change to sword name
        {
            SlimeSpawn spawnRef = spawner.GetComponentInChildren<SlimeSpawn>();
            spawnRef.decreaseNum();
            gameObject.SetActive(false);
        }
    }
}
