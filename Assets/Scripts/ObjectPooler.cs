using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour 
{
    public static ObjectPooler current;
    public GameObject[] pooledObj;
    public int poolAmount = 5;

    List<List<GameObject>> pooledObjs;

    void Awake ()
    {
        pooledObjs = new List<List<GameObject>>();

        //Keep a static reference so that other objects can access it
        current = this;

        //Create a list to store the object to be pooled
        for(int i = 0; i < pooledObj.Length; i++)
        {
            pooledObjs.Add(new List<GameObject>());

            //Create poolAmount number of objects and store them
            for (int n = 0; n < poolAmount; n++)
            {
                createNewPoolObject(i);
            }
        }
        
        
    }

    public GameObject GetPooledObject (int idx)
    {
        //Try to find a object that can be used within the pool
        for (int i = 0; i < pooledObjs[idx].Count; i++)
        {
            if (!pooledObjs[idx][i].activeInHierarchy)
            {
                return pooledObjs[idx][i];
            }
        }

        //No object was usable in the pool, so create a new one
        return createNewPoolObject(idx);
    }

    /*
     * Creates a new pooledObj and adds it to the pool.
     * @param The index of the poolObj to create
     * @return The newly created poolObject
     */
    private GameObject createNewPoolObject(int idx)
    {
        GameObject obj = Instantiate(pooledObj[idx]);
        obj.SetActive(false);
        pooledObjs[idx].Add(obj);
        return obj;
    }
}
