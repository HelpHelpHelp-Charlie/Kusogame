using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed=10;
    private float gunHeat=1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gunHeat > 0)
        {
            gunHeat -= Time.deltaTime;
        }
        if (gunHeat <= 0)
        {
        gunHeat = 0.25f;
        var bullet=Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity=bulletSpawnPoint.forward*bulletSpeed;
        }
    }
}
