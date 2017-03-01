using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestrictor : MonoBehaviour 
{
    public Transform target1;
    public Transform target2;

    private Vector3 target1Size;
    private Vector3 target2Size;
    public float leftClamp;
    public float rightClamp;

	void Start () 
    {
        //Get screen clamp values (prevents players from going off screen towards left/right)
        float targetZDistance = (target1.transform.position - Camera.main.transform.position).z;
        target1Size = target1.GetComponent<CapsuleCollider2D>().bounds.size;
        leftClamp = Camera.main.ViewportToWorldPoint(new Vector3(0.05f, 0f, targetZDistance)).x + (target1Size.x / 2) - 0.6f;
        rightClamp = Camera.main.ViewportToWorldPoint(new Vector3(0.95f, 0f, targetZDistance)).x - (target1Size.x / 2) + 0.6f;
	}
	
	void Update () 
    {
        //Clamp Player 1 and Player 2 so they cannot pass the left/right clamps
        target1.transform.position = new Vector3(Mathf.Clamp(target1.transform.position.x, leftClamp, rightClamp),
            target1.transform.position.y,
            target1.transform.position.z);
        
        target2.transform.position = new Vector3(Mathf.Clamp(target2.transform.position.x, leftClamp, rightClamp),
            target2.transform.position.y,
            target2.transform.position.z);	
    }
}
