using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] TiltPrefabs;
    public float zSpawn=0;
    public float tiltLength=5;
    public Transform playerTransform;
    public int total_game_tile= 10;

    public int sightDistance=2;

    void Start()
    {
        initspawnTile();
    }

    // Update is called once per frame
    void Update()
    {


        if(playerTransform.position.z>zSpawn-sightDistance*tiltLength && zSpawn<=tiltLength*total_game_tile+7){
            spawnTile(UnityEngine.Random.Range(2,TiltPrefabs.Length));
            Debug.Log("Hello");
        }

    }
    public void spawnTile(int index){
        Instantiate(TiltPrefabs[index],transform.forward*zSpawn,transform.rotation);
        zSpawn+=tiltLength; 
    }
    public void initspawnTile(){
        Instantiate(TiltPrefabs[0],transform.forward*zSpawn,transform.rotation);
        zSpawn+=7F; 
    }
}
