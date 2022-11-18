using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Shotgun : MonoBehaviour
{
    public static Shotgun instance;

    public int pelletCount;
    public float spreadAngle;
    public float pelletFireVel;

    public Transform BarrelExit;
    List<Quaternion> pellets;
    public VisualEffect SmokePoof;
    public GameObject pellet;

[Header("Reloading")]
    public float ReloadTime;
    public float ReloadTimer;
    public float reloadPerc;
    public bool Reloading;
    public float Clip;
    public Image reloadBar;
    public GameObject ReloadCanvas;

[Header("Hit")]
    public GameObject HitColl;
    bool Hitting;

    void Awake()
    {
        instance = this;
        pellets = new List<Quaternion>(new Quaternion[pelletCount]);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !Reloading && !Hitting)
        {
            Fire();
        }
        else if(Input.GetMouseButtonDown(1) && !Reloading && !Hitting)
        {
            StartCoroutine("Hit");
        }

        if(ReloadTimer >= 0)
        {
            ReloadTimer -= Time.deltaTime;
            reloadPerc = ReloadTimer / ReloadTime;
            reloadBar.fillAmount = reloadPerc;
        }

    }

    public void Fire()
    {
            if(Clip >= 1)
            {
                ResourceManager.instance.Bullets -= 1;
                Clip -= 1;

                for (int i = 0; i < pellets.Count; i++)
                {
                    GameObject p;
                    CharacterMovement.instance.animator.SetTrigger("Shot");
                    pellets[i] = Random.rotation;
                    p = (GameObject)Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
                    p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
                    p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVel);
                    CamShaker.instance.ShotShake();
                    SmokePoof.Play();
                }
            }
            else
                StartCoroutine("Reload");
    }

    public IEnumerator Hit()
    {
        CharacterMovement.instance.animator.SetTrigger("Hit");
        Hitting = true;
        HitColl.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        HitColl.SetActive(false);
        Hitting=false;
        yield return null;
    }

    public IEnumerator Reload()
    {
        if(ResourceManager.instance.Bullets >= 2)
        {
            Clip = 0;
            Reloading = true;
            ReloadTimer = ReloadTime;
            ReloadCanvas.SetActive(true);

            yield return new WaitForSeconds(ReloadTime);

            ReloadCanvas.SetActive(false);
            Reloading = false;
            Clip = 2;
            yield return null;
        }
        else
            yield return null;
    }
}
