using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeFollow : MonoBehaviour
{

    public Transform target; //put the chef player in the editor
    public float speed = 3f;

    Rigidbody2D body;

    //[SerializeField] private SlimeSpawn spawnScript;



    public GameObject spawner = GameObject.FindWithTag("Spawner"); //made this public. wrong spot?



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            //spawnScript.waveNum -= 1;
            //Debug.Log(spawnScript.waveNum);

            /*Debug.Log("touch player");

            SlimeSpawn tempSpawn;
            tempSpawn = collision.gameObject.GetComponent<SlimeSpawn>();
            tempSpawn.waveNum -= 1;
            */


            SlimeSpawn spawnRef = spawner.GetComponentInChildren<SlimeSpawn>();
            spawnRef.decreaseNum();


            //this works
            Destroy(gameObject);
        }
    }
}
