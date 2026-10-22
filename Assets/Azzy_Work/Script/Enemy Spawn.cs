using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    public bool wave1Start = true;
    public bool wave2Start = false;
    public bool wave3Start = false;

    public GameObject enemyPrefab;

    public int randomX = Random.Range(0, 50);
    public int randomY = Random.Range(0, 50);

    public int waveNum; //start game with 20 enemies (wave 1)

    //[SerializeField] private SlimeFollow enemyScript;

    //THIS IS A TEST
    //public GameObject AngySlime; // drag and drop the object in the inspector.
    //SlimeFollow script;

    //script = AngySlime.GetComponent<SlimeFollow>(); //ok so this is broken but let's try get component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Vector3 randomizePosition = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (wave1Start) //add more waves
        {
            waveNum = 20;
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

    //making a decrease wavenum script. hopefully this works
    public void decreaseNum()
    {
        waveNum -= 1;
        Debug.Log(waveNum);
    }
}
