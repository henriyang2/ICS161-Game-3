using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    PlayerController player;
    private float currentRange;
    public float bulletRange;
    public float rangeDecrease;
    public float rangeRecharge;
    public string PLAYER_INPUT_FIRE;
    public bool faceRight;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    private void Start()
    {
        currentRange = bulletRange;
    }

    void Update()
    {
        if (Input.GetButtonDown(PLAYER_INPUT_FIRE))
        {
            if (currentRange < 0)
                currentRange = 0;
            if (currentRange > rangeDecrease)
                Fire();
        }
        if (currentRange < bulletRange)
            currentRange += rangeRecharge * Time.fixedDeltaTime;
        faceRight = player.GetDirection();
    }
    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        if (faceRight)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 25;

        }
        else if (!faceRight)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = -bullet.transform.right * 25;
        }

        Destroy(bullet, currentRange);
        currentRange -= rangeDecrease;
    }
}
