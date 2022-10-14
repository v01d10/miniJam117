using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public static Shotgun instance;
    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVel;
    private float LifeSpan = 6;
    public Transform BarrelExit;
    List<Quaternion> pellets;

[Header("Pelllet Pool")]
    public List<GameObject> PelletPool = new List<GameObject>();
    public GameObject pellet;
    public int pelletsToPool;


    void Awake()
    {
        instance = this;
        pellets = new List<Quaternion>(new Quaternion[pelletCount]);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject p = new GameObject();
        for (int i = 0; i < pellets.Count; i++)
        {
            pellets[i] = Random.rotation;
            p = (GameObject)Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            Destroy(p, LifeSpan);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVel);
            i++;
        }

        // for (int i = 0; i < pelletCount; i++)
        // {
        //     GameObject pellet = GetPellet(); 
        //     if (pellet != null)
        //     {
        //         pellet.transform.position = BarrelExit.position;
        //         pellet.transform.rotation = Random.rotation;
        //         pellet.SetActive(true);
        //         pellet.transform.rotation = Quaternion.RotateTowards(pellet.transform.rotation, Random.rotation, spreadAngle);
        //         pellet.GetComponent<Rigidbody>().AddForce(pellet.transform.forward * pelletFireVel);
        //     }           
        // }

    }

    public GameObject GetPellet()
    {
        for (int i = 0; i < pelletsToPool; i++)
        {
            if(!PelletPool[i].activeInHierarchy)
            {
                return(PelletPool[i]);
            }
        }

        return null;
    }
}
