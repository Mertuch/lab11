using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{
    public GameObject prefab;
    public float fireRate = 1;
    private float nextFire = 0.0F;
    public float speed = 30;

    private int ammo = 5;

    void Start()
    {

      
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && ammo >0)
        {
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(prefab) as GameObject;
            projectile.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward * 50;
            ammo -= 1;

        }
        if (Input.GetMouseButtonDown(1)){
            ammo = 5;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
