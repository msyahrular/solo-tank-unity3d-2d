using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak : MonoBehaviour
{

    public float moveSpeed = 2;
    public float bulletspeed = 10;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    
    // Start is called before the first frame update
    void Update()
    {
        Movement();
        Shooting();
    }

    // Update is called once per frame
    void Movement()
    {

    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    
    if (h != 0)
    {
        transform.position += new Vector3(h * moveSpeed * Time.deltaTime,0,0);
        transform.rotation = Quaternion.Euler(0,0, -90 * h);
    } 
    else if(v != 0)
    {
        transform.position += new Vector3(0, v * moveSpeed * Time.deltaTime,0);
        transform.rotation = Quaternion.Euler(0, 0, 90 - 90 * v);
    }

    }

    void Shooting(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletspeed;
        }
        
    }
}
