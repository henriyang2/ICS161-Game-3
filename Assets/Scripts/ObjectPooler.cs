using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour 
{
    public static ObjectPooler current;
    public GameObject pooledObj;
    public int poolAmount = 15;

    List<GameObject> pooledObjs;

    void Awake ()
    {
        //Keep a static reference so that other objects can access it
        current = this;

        //Create a list to store the object to be pooled
        pooledObjs = new List<GameObject>();

        //Create poolAmount number of objects and store them
        for (int i = 0; i < poolAmount; i++)
        {
            createNewPoolObject();
        }
    }

    public GameObject GetPooledObject ()
    {
        //Try to find a object that can be used within the pool
        for (int i = 0; i < pooledObjs.Count; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }

        //No object was usable in the pool, so create a new one
        return createNewPoolObject();
    }

    /*
     * Creates a new pooledObj and adds it to the pool.
     * @return The newly created poolObject
     */
    private GameObject createNewPoolObject()
    {
        GameObject obj = Instantiate(pooledObj);
        obj.SetActive(false);
        pooledObjs.Add(obj);
        return obj;
    }
}
