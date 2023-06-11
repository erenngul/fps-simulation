using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 20f;
    public float grenadeReloadTime = 1f;
    public GameObject grenadePrefab;
    public GameObject equippedGrenade;
    public GameObject weaponHolder;

    private bool isReloading = false;

    void Update()
    {
        if (equippedGrenade.activeSelf && Input.GetMouseButtonDown(0) && !isReloading)
        {
            StartCoroutine(ThrowGrenade());
        }
    }

    IEnumerator ThrowGrenade()
    {
        equippedGrenade.SetActive(false);

        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(grenadeReloadTime);

        if (weaponHolder.GetComponent<WeaponSwitching>().selectedWeapon == 3)
        {
            equippedGrenade.SetActive(true);
        }
    }
}
