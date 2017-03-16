using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour 
{
    //Transform added through inspector, basically the spawning point
    public Transform platformGenerationPoint;

    //The min and max amount of time for Random.Range it takes to spawn a platform
    public float spawnMin = 4f;
    public float spawnMax = 5f;
    //public float spawnTime = 5f;

    //Just rough platform sizes for playtesting purposes, can tune this if needed
    public float[] platformSizes = new float[] {2f, 2.5f, 3.5f};

    private int PLATFORMS_TO_SPAWN = 3;

	void Start () 
    {
        //Kick everything off by spawning two platforms immediately so platform generator doesn't fall behind
        //SpawnFirstTwoPlatforms();
        SpawnFirstTwoPlatforms();
        //Spawn();
	}
       
    void Spawn ()
    {

        for (int i = 0; i < PLATFORMS_TO_SPAWN; i++)
        {
            //Get a platform from the platform pool
            GameObject obj = ObjectPooler.current.GetPooledObject();

            //Setting up platform location and size
            //Random.Range(-0.5f, 0.5f) offset to make platforms not spawn right on top of each other (hopefully)
            //Change size based on the three platform sizes initiated, can tune this if needed
            obj.transform.position = new Vector3(transform.position.x + Random.Range(-5.3f, 5.3f), transform.position.y + Random.Range(-2f, 2f), transform.position.z);
            obj.transform.rotation = transform.rotation;
            obj.transform.localScale = new Vector3(platformSizes[Random.Range(0, platformSizes.Length)], obj.transform.localScale.y, obj.transform.localScale.z);

            //Enable the object
            obj.SetActive(true);
        }

        //Kick off another spawn after spawnTime
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
        
    void SpawnFirstTwoPlatforms ()
    {
        //Spawn the first two set of platforms and then invoke the normal spawn method
        for (int i = 0; i < 2; i++)
        {

            for (int j = 0; j < PLATFORMS_TO_SPAWN; j++)
            {
                //Get a platform from the platform pool
                GameObject obj = ObjectPooler.current.GetPooledObject();

                //Setting up platform location and size
                //Random.Range(-0.5f, 0.5f) offset to make platforms not spawn right on top of each other (hopefully)
                //Change size based on the three platform sizes initiated, can tune this if needed
                obj.transform.position = new Vector3(transform.position.x + Random.Range(-5.3f, 5.3f), 0f + (Random.Range(5, 6f) * (i + 1)), transform.position.z);
                obj.transform.rotation = transform.rotation;
                obj.transform.localScale = new Vector3(platformSizes[Random.Range(0, platformSizes.Length)], obj.transform.localScale.y, obj.transform.localScale.z);

                //Enable the object
                obj.SetActive(true);
            }
        }

        //Kick off another spawn after spawnTime
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
