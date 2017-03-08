using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPermutation : MonoBehaviour 
{	
    //*****************JUST A TEMPORARY CLASS******************
    //Class for deleting the platform permutation object if all
    //of the actual platform objects have been destroyed, will
    //remove this when we decide how to do object pooling with
    //multiple platform permutations

	void Update () 
    {
        if (transform.childCount == 0)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
