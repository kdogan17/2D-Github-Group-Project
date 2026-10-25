using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeFollow : MonoBehaviour
{

    public Transform target; //put the chef player in the editor
    public float speed = 3f;

    Rigidbody2D body;

    public GameObject spawner = GameObject.FindWithTag("Spawner"); 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // slime position changes. transform is slime. target is chef. speed is speed

    }
    

    //this version kills the slimes when touching player, change this to touching the sword
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name.Equals("Square")) //change to sword name
        {
            SlimeSpawn spawnRef = spawner.GetComponentInChildren<SlimeSpawn>();
            spawnRef.decreaseNum();
            gameObject.SetActive(false);
        }
    }
}
