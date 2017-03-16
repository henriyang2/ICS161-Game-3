using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public static GameObject character;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float ammo;
    public float ammoDepletion;
    public float ammoRecharge;

    private void Awake()
    {
        character = gameObject;
    }

    private void Start()
    {
        ammo = 10;
        ammoDepletion = 1.5f;
        ammoRecharge = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            if (ammo > ammoDepletion)
            {
                Fire();
                ammo -= ammoDepletion;
            }
        }
        if (ammo < 10)
        {
            ammo = ammo + ammoRecharge * Time.fixedDeltaTime;
        }
    }
    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);


        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 25;
        bulletBack.GetComponent<Rigidbody2D>().velocity = -bullet.transform.right * 25;

        Destroy(bullet, .25f);
    }
}
