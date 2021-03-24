using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour 
{
    public GameObject Bullet;
    public GameObject WeaponBarrel;
    public AudioClip ShootSound;

    // Update is called once per frame
    void Update() {                
        // Pegar Inputs = Edit -> Project Settings -> Inputs
        if(Input.GetButtonDown("Fire1")) 
        {
            Instantiate(Bullet, WeaponBarrel.transform.position, WeaponBarrel.transform.rotation);
            AudioController.instance.PlayOneShot(ShootSound);
        }
    }
}
