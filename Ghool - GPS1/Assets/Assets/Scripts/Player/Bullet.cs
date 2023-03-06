using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

//done by: Danial / Alisa
public class Bullet : MonoBehaviour
{
    public BuffSystem buffSystem; //needed to transfer stat value to BuffSystem Script

    Vector3 mousePos;
    private Camera mainCam;

    //default
    public float dbulletSpeed = 10.0f;
    public float dbulletDamage = 5.0f;

    //copy to alter
    public float bulletSpeed = 10.0f;
    public float bulletDamage = 5.0f;

    public GameObject healball;

    private Rigidbody2D rb;
    // Method to set the direction of the bullet
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);
        buffSystem = new BuffSystem();
        buffSystem.GetAtk(bulletDamage);

        Destroy(gameObject, 3f);
    }

    public void setAtk(float bD) //to recieve from buffSystem
    {
        bulletDamage = bD;
    }

    public void resetStat() //happens after death
    {
        //resetting values
        bulletSpeed = dbulletSpeed;
        bulletDamage = dbulletDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(healball, transform.position, Quaternion.identity);
        }
        // Handle collision with other objects
        
        DemonSoilder demonSoldier = collision.gameObject.GetComponent<DemonSoilder>();
        DemonArcherHP demonArcher = collision.gameObject.GetComponent<DemonArcherHP>();
        if (demonSoldier != null)
        {
            demonSoldier.TakeDamage(bulletDamage);
        }

        if (demonArcher!= null)
        {
            demonArcher.TakeDamage(bulletDamage);
        }
    }
}
