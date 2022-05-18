using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShoot : MonoBehaviour {

    public int gunDamage = 1;
    public float fireRate = 0.05f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    public ParticleSystem shotParticle;

    //public Slider EnemyHealthBar;

    public Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.05f);

    private LineRenderer laserLine;
    private float nextFire;


    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            InvokeRepeating("Shoot", 0, 0.1f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
        }

    }


    void Shoot()
    {
        StartCoroutine(ShotEffect());

        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;

        laserLine.SetPosition(0, gunEnd.position);

        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        {
            laserLine.SetPosition(1, hit.point);
            Instantiate(shotParticle, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);

            EnemyDmg health = hit.collider.GetComponent<EnemyDmg>();

            if (health != null)
            {
                health.Damage(gunDamage);
                //EnemyHealthBar.value -= .50f;
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }
            else
            {
                //EnemyHealthBar.value = 1.0f;
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
        }
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }
}
