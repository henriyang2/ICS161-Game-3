using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour 
{
    //Transform added through inspector, basically the spawning point
    public Transform platformGenerationPoint;

    //The min and max amount of time for Random.Range it takes to spawn a platform
    public float spawnMin = 2.75f;
    public float spawnMax = 3.5f;

    //Just rough platform sizes for playtesting purposes, can tune this if needed
    private float[] platformSizes = new float[] {2f, 2.5f, 3.5f};

	void Start () 
    {
        //Kick everything off with a spawn immediately
        Spawn();
	}
	
    void Spawn ()
    {
        //Attempt to get a platform from the platform pool
        GameObject obj = ObjectPooler.current.GetPooledObject();

        //If a platform could not be found in the pool, try again to get one as fast as possible 
        if (obj == null)
        {
            Spawn();
            return;
        }

        //Setting up platform location and size
        //Random.Range(-0.5f, 0.5f) offset to make platforms not spawn right on top of each other (hopefully)
        //Change size based on the three platform sizes initiated, can tune this if needed
        obj.transform.position = new Vector3(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y, transform.position.z);
        obj.transform.rotation = transform.rotation;
        obj.transform.localScale = new Vector3(platformSizes[Random.Range(0, platformSizes.GetLength(0))], obj.transform.localScale.y, obj.transform.localScale.z);

        //Enable the object
        obj.SetActive(true);

        //Kick off another spawn after a certain time between spawnMin and spawnMax
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
