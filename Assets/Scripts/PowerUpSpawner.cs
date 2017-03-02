using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    GameObject target;
    float spawnTime = 7f; //seconds between spawning a new power-up
    int IndexNum;
    GameObject[] generators;

    int powerUpCount = 1; //change this according to how many power up types are in the game
	
    // Use this for initialization
	void Start () {
        //Get the list of platform generators
        generators = GameObject.FindGameObjectsWithTag("PlatformGenerator");
        Debug.Log(generators);
    }
	
	// Update is called once per frame
	void Update () {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = 7f;
            IndexNum = Random.Range(0, 2);
            target = generators[IndexNum];
            GameObject clone = Instantiate(    GameObject.FindGameObjectsWithTag("PowerUp")[Random.Range(0, powerUpCount - 1)]);
            clone.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 1, target.transform.position.z);
            
            //Make an instance of a powerup slightly above a platform generator, which would end up above the platform it makes
               
        }



	}

}
