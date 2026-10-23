using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    public bool wave1Start = true;
    public bool wave2Start = true; //ok these are poorly named but they become false once the wave is spawned
    public bool wave3Start = true; //also they are so broken for some reason idek

    public GameObject enemyPrefab;

    public int randomX = Random.Range(0, 10); //can definitely change these values
    public int randomY = Random.Range(0, 10);

    public int waveNum; //start game with 20 enemies (wave 1)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (wave1Start) 
        {
            waveNum = 20;
            for (int i = 0; i < 19; i++)
            {
                SpawnEnemy();
            }
            wave1Start = false;
        }
        else if (waveNum == 0 && !wave1Start && !wave2Start)
        {
            Debug.Log("wave 2 start");
            waveNum = 30;
            for (int i = 0; i < 30; i++)
            {
                SpawnEnemy();
            }
            wave2Start = true;
        }
        else if (waveNum == 0 && wave2Start)
        {
            Debug.Log("wave 3 start");
            waveNum = 50;
            for (int i = 0; i < 50; i++)
            {
                SpawnEnemy();
            }
            wave3Start = false;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 randomizePosition = new Vector3(Random.Range(0, 50), Random.Range(0, 50), 0);
        Quaternion Rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(enemyPrefab,randomizePosition, Rotation);
        //enable the thing just instantiated
        enemyPrefab.SetActive(true);
    }

    public void decreaseNum()
    {
        waveNum -= 1;
        Debug.Log(waveNum);
    }
}
