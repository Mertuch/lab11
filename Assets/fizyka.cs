using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fizyka : MonoBehaviour
{
    Rigidbody fiz;
    public float speed;
    float inputX, inputZ;
    bool skok = false;
    bool strzal = false;
    public GameObject kulka;
    public Transform pozycjakulki;
    void Awake()
    {
        fiz = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //fiz.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Jump"))
        {
            skok = true;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            strzal = true;
        }
    }

    void FixedUpdate()
    {
        fiz.velocity = new Vector3(inputX*speed, fiz.velocity.y, inputZ*speed);
        if(skok==true)
        {
            Skok();
            skok = false;
        }
        if(strzal==true)
        {
            Strzal();
            strzal = false;
        }
    }

    void Skok()
    {
        fiz.AddForce(0, 400, 0);
    }

    void Strzal()
    {
        GameObject nowaKulka = Instantiate(kulka, pozycjakulki.position, Quaternion.identity);
        nowaKulka.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 20);
    }
}
