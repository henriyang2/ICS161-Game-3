using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour 
{
    //Transform added through inspector, basically the spawning point
    public Transform platformGenerationPoint;

    //The min and max amount of time for Random.Range it takes to spawn a platform
    //public float spawnMin = 2.75f;
    //public float spawnMax = 3.5f;
    public float spawnTime = 9f;

    //Just rough platform sizes for playtesting purposes, can tune this if needed
    public float[] platformSizes = new float[] {2f, 2.5f, 3.5f};

    //List to hold all platform permutations
    public GameObject[] platformPermutationsList;

    //Keep track of the last platform permutation spawned to prevent back to back spawns of same permutation
    private int lastPlatformPermutationSpawned = -1;

	void Start () 
    {
        //Kick everything off by spawning two platforms immediately so platform generator doesn't fall behind
        SpawnFirstTwoPlatforms();
	}
       
    void Spawn ()
    {
        //Commented out object pooling code for now since we're using platform permutations
        //so I'm not sure how we want to do it with object pooling, can discuss this later
        /*
        //Get a platform from the platform pool
        GameObject obj = ObjectPooler.current.GetPooledObject();

        //Setting up platform location and size
        //Random.Range(-0.5f, 0.5f) offset to make platforms not spawn right on top of each other (hopefully)
        //Change size based on the three platform sizes initiated, can tune this if needed
        obj.transform.position = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y, transform.position.z);
        obj.transform.rotation = transform.rotation;
        obj.transform.localScale = new Vector3(platformSizes[Random.Range(0, platformSizes.Length)], obj.transform.localScale.y, obj.transform.localScale.z);

        //Enable the object
        obj.SetActive(true);
        */

        int platformPermutationToSpawn = -1;
        bool differentPermutation = false;

        //If a different permutation is not obtained, keep trying to get a different one
        while (!differentPermutation)
        {
            platformPermutationToSpawn = Random.Range(0, platformPermutationsList.Length);

            //If the permutation we got was not the same as the last permutation spawned, break out of while
            if (platformPermutationToSpawn != lastPlatformPermutationSpawned)
            {
                lastPlatformPermutationSpawned = platformPermutationToSpawn;
                differentPermutation = true;
            }
        }

        GameObject platformPermutationObj = (GameObject)Instantiate(platformPermutationsList[platformPermutationToSpawn]);
        platformPermutationObj.transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);

        platformPermutationObj.SetActive(true);
            

        //Kick off another spawn after spawnTime
        Invoke("Spawn", spawnTime);
    }

    void SpawnFirstTwoPlatforms ()
    {
        //Spawn the first two platforms and then invoke the normal spawn method
        for (int i = 0; i < 2; i++)
        {
            int platformPermutationToSpawn = -1;
            bool differentPermutation = false;

            while (!differentPermutation)
            {
                platformPermutationToSpawn = Random.Range(0, platformPermutationsList.Length);

                Debug.LogError(lastPlatformPermutationSpawned + " " + platformPermutationToSpawn);

                //If the permutation we got was not the same as the last permutation spawned, break out of while
                if (platformPermutationToSpawn != lastPlatformPermutationSpawned)
                {
                    lastPlatformPermutationSpawned = platformPermutationToSpawn;
                    differentPermutation = true;
                }
            }

            GameObject platformPermutationObj = (GameObject)Instantiate(platformPermutationsList[platformPermutationToSpawn]);
            platformPermutationObj.transform.position = new Vector3(transform.position.x, transform.position.y + (6f * i), transform.position.z);

            platformPermutationObj.SetActive(true);
        }

        //Kick off another spawn after spawnTime
        Invoke("Spawn", spawnTime);
    }
}
