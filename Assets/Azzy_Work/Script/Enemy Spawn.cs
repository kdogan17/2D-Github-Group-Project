using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class SlimeSpawn : MonoBehaviour
{
    public bool wave1Start = true;
    public bool wave2Start = true; //ok these are poorly named but they become false once the wave is spawned
    public bool wave3Start = true; //also they are so broken for some reason idek

    public GameObject enemyPrefab;
    public GameObject bossPrefab;

    public Text dialogueText;

    float x;
    float y;
    float z;
    Vector3 pos;



    public int waveNum; //start game with 20 enemies (wave 1)

    public bool bossSpawn;

    public bool cycleComplete; //idek if this one works but whatever


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossSpawn = false;
        cycleComplete = false;
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
        else if (waveNum == 0 && !wave1Start && !wave2Start && !bossSpawn) //it's not pretty but it WORKS
        {
            Debug.Log("wave 2 start");
            waveNum = 30;
            for (int i = 0; i < 30; i++)
            {
                SpawnEnemy();
            }
            wave2Start = true;
        }
        else if (waveNum == 0 && wave2Start) //do not ask me why these else statements work bc i feel like they should be so broken
        { 
            Debug.Log("wave 3 start");
            waveNum = 50;
            bossSpawn = true;
            for (int i = 0; i < 50; i++)
            {
                SpawnEnemy();
            }
            wave2Start = false;
            wave3Start = true;
            cycleComplete = false;
        } else if ((waveNum == 0) && (wave3Start))
        {
            //Debug.Log("boss");
            SpawnBoss();
            wave3Start = false; 
            cycleComplete = true; 
        } 
    }

    public void SpawnEnemy()
    {
        Vector3 randomizePosition = new Vector3(Random.Range(0, 30), Random.Range(0, 15), 0); //change these if needed
        Quaternion Rotation = Quaternion.Euler(0, 0, 0);
        Instantiate(enemyPrefab,randomizePosition, Rotation);
        //enable the thing just instantiated
        enemyPrefab.SetActive(true);
    }

    public void SpawnBoss() 
    {
        x = Random.Range(-50, 50);
        y = Random.Range(-50, 50);
        pos = new Vector3(x, y, 0);
        transform.position = pos;

        Debug.Log("x:" + x);
        Debug.Log("y" + y); //this is just to make sure the values are random

        bossPrefab.SetActive(true);
        Debug.Log("spawn boss");
    }

    public void decreaseNum()
    {
        waveNum -= 1;
        Debug.Log(waveNum);
    }
}
