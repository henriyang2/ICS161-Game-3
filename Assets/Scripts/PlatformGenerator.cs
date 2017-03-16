﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour 
{
    //Transform added through inspector, basically the spawning point
    //private float lastSpawn;
    private float nextSpawn = 0.0f;

    //The min and max amount of space between platform spawns
    public float spawnMin = 2.75f;
    public float spawnMax = 7.75f;
    //public int spawnNumMin = 1;
    //public int spawnNumMax = 3;
    //public float spawnTime = 5f;

    //Just rough platform sizes for playtesting purposes, can tune this if needed
    public float[] platformSizes = new float[] {2f, 2.5f, 3.5f};

    //private int PLATFORMS_TO_SPAWN = 3;

	void Start () 
    {
        //Kick everything off by spawning two platforms immediately so platform generator doesn't fall behind
        //SpawnFirstTwoPlatforms();
        //SpawnFirstTwoPlatforms();
        //Spawn();
	}
       
    void Spawn ()
    {
        float lowerX = -5.3f;
        float upperX = 5.3f;
        int platformsToSpawn = Random.Range(1, 3);

        int bigPlatformToSpawn = Mathf.RoundToInt(Random.value);

        if(bigPlatformToSpawn == 1)
        {
            GameObject obj = ObjectPooler.current.GetPooledObject(1); //Gets the large platform (index 1) from the object pooler
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-5.3f, 5.3f), transform.position.y + Random.Range(2f, 3.5f), transform.position.z);
            obj.transform.rotation = transform.rotation;
           
            obj.SetActive(true);
            platformsToSpawn--;
        }

        while(platformsToSpawn > 0)
        {
            //Get a platform from the platform pool
            GameObject obj = ObjectPooler.current.GetPooledObject(0);

            //Setting up platform location and size
            //Change size based on the three platform sizes initiated, can tune this if needed
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-5.3f, 5.3f), transform.position.y + Random.Range(2f, 3.5f), transform.position.z);
            obj.transform.rotation = transform.rotation;
            //obj.transform.localScale = new Vector3(platformSizes[Random.Range(0, platformSizes.Length)], obj.transform.localScale.y, obj.transform.localScale.z);

            //Enable the object
            obj.SetActive(true);
            platformsToSpawn--;
        }

        //for (int i = 0; i < platformsToSpawn; i++)
        //{
            
        //}

        //Kick off another spawn after spawnTime
        //Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }

    void Update()
    {
        if(Camera.main.transform.position.y >= nextSpawn)
        {
            Spawn();
            nextSpawn = Camera.main.transform.position.y + Random.Range(spawnMin, spawnMax);
        }
    }
        
    //void SpawnFirstTwoPlatforms ()
    //{
    //    //Spawn the first two set of platforms and then invoke the normal spawn method
    //    for (int i = 0; i < 2; i++)
    //    {

    //        for (int j = 0; j < PLATFORMS_TO_SPAWN; j++)
    //        {
    //            //Get a platform from the platform pool
    //            GameObject obj = ObjectPooler.current.GetPooledObject();

    //            //Setting up platform location and size
    //            //Random.Range(-0.5f, 0.5f) offset to make platforms not spawn right on top of each other (hopefully)
    //            //Change size based on the three platform sizes initiated, can tune this if needed
    //            obj.transform.position = new Vector3(transform.position.x + Random.Range(-5.3f, 5.3f), 0f + (Random.Range(5, 6f) * (i + 1)), transform.position.z);
    //            obj.transform.rotation = transform.rotation;
    //            obj.transform.localScale = new Vector3(platformSizes[Random.Range(0, platformSizes.Length)], obj.transform.localScale.y, obj.transform.localScale.z);

    //            //Enable the object
    //            obj.SetActive(true);
    //        }
    //    }

    //    //Kick off another spawn after spawnTime
    //    Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    //}
}
