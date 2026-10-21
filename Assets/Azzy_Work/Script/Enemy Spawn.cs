using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    public bool wave1Start = true;
    public bool wave2Start = false;
    public bool wave3Start = false;

    public GameObject enemyPrefab;

    public int randomX = Random.Range(0, 50);
    public int randomY = Random.Range(0, 50);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3 randomizePosition = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (wave1Start) //MAKE SLIME MANAGER FOR SPAWNING
        {
            for (int i = 0; i < 20; i++)
            {
                //Instantiate(enemyPrefab);
                SpawnEnemy();
            }
            wave1Start = false;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 randomizePosition = new Vector3(Random.Range(0, 50), Random.Range(0, 50), 0);
        Quaternion Rotation = Quaternion.Euler(0, 0, 0); //unsure if i need this? ints don't work
        Instantiate(enemyPrefab,randomizePosition, Rotation);
    }
}
