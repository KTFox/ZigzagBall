using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaftformSpawner : MonoBehaviour
{
    //Variables
    public static PlaftformSpawner instance;

    [SerializeField] GameObject plaftform;
    [SerializeField] GameObject diamond;
    public bool gameOver;
    bool gameStarted;

    Vector3 lastPos;
    float size;

    //Event functions
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        lastPos = transform.position;
        size = plaftform.transform.localScale.x;
    }

    //Methods   
    public void StopSpawn()
    {
        CancelInvoke("SpawnPlatform");
    }
    public void StartSpawn()
    {
        InvokeRepeating("SpawnPlatform", 0, 0.2f);
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0)
        {
            SpawnX();
        }
        else if (rand == 1)
        {
            SpawnZ();
        }
    }
    
    void SpawnX()
    {
        //Spawn platform
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;

        Instantiate(plaftform, pos, Quaternion.identity);

        //Spawn diamond
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        //Spawn platform
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;

        Instantiate(plaftform, pos, Quaternion.identity);

        //Spawn diamond
        int rand = Random.Range(0, 4);

        if (rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
}
