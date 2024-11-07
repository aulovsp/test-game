using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public int maxAmmo;
    public int maxMagAmmo;
    public Text ammoText;

    private int ammo;
    private int magAmmo;
    private AudioSource audioSource;

    void Start()
    {
        ammo = maxAmmo - maxMagAmmo;
        magAmmo = maxMagAmmo;

        audioSource = GetComponent<AudioSource>();

        ammoText.text = $"{ammo}/{magAmmo}";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && magAmmo > 0)
        {
            Shoot();
            ammoText.text = $"{ammo}/{magAmmo}";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            ammoText.text = $"{ammo}/{magAmmo}";
        }
    }

    private void Shoot()
    {
        if (magAmmo == 0)
        {
            audioSource.Play();
            return;
        }
        
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Health health = hit.collider.GetComponent<Health>();

            if (health != null)
            {
                health.Damage(10);
            }
        }

        magAmmo--;

    }

    private void Reload()
    {
        if (magAmmo == maxMagAmmo)
        {
            audioSource.Play();
            return;
        }

        if (ammo == 0)
        {
            return;
        }

        int ammoToReload = maxMagAmmo - magAmmo;

        if (ammoToReload > ammo)
        {
            ammoToReload = ammo;
        }

        magAmmo = magAmmo + ammoToReload;
        ammo -= ammoToReload;
    }
}
