using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torreta : MonoBehaviour
{
    public GameObject bulletObjet;
    public Transform player;
    public float shootingCoolDown = 0.5f;
    public float shootSpeed = 40f;
    public Transform bulletSpawnPoint;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootingCoolDown )
        {
            ShootPlayer();
            timer = 0f;

        }
    }

    void ShootPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletObjet, bulletSpawnPoint.position, Quaternion.identity);
        Rigidbody rb = bulletObjet.GetComponent<Rigidbody>();
        //rb.velocity = direction * shootSpeed;
        bullet.GetComponent<Rigidbody>().velocity = direction * shootSpeed;
        Destroy(bullet, 4f);
    }

   
    

   
         
   
}
