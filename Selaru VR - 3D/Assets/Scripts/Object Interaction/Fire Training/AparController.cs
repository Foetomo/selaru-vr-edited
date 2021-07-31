using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparController : MonoBehaviour
{

    [SerializeField] private Transform attachPosition;
    [SerializeField] private GameObject bullet;

    [SerializeField, Tooltip("Apar is Taken or not")] private bool isTaken;

    [SerializeField, Tooltip("Water particle")] private GameObject waterParticle;

    [Header("Bullet")]
    [SerializeField, Tooltip("Bullet Spawn")] private Transform bulletSpawn;
    [SerializeField, Tooltip("Bullet Speed")] private float bulletSpeed = 10f;
    [SerializeField, Tooltip("Interval each bullet out")]private float shootInterval = 0;
    [SerializeField, Tooltip("Shooting speed")]private float firingSpeed = 0;

    private float time = 0;
    private bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            time = 0;
            canShoot = true;
            waterParticle.SetActive(false);
        }
    }

    public void Take()
    {
        if (!isTaken)
        {
            transform.position = attachPosition.position;
            transform.SetParent(attachPosition);
            transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
            isTaken = true;
        }
    }

    void Shoot()
    {
        if (isTaken)
        {
            waterParticle.SetActive(true);
            if (time >= shootInterval)
            {
                canShoot = true;
                time = 0;
            }
            else
            {
                time += firingSpeed * Time.deltaTime;
            }

            if (canShoot)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed);
                canShoot = false;
            }
        }
    }
}
