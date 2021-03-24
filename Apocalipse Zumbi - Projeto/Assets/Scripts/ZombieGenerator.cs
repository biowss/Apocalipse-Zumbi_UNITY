using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour
{
    public GameObject Zombie;
    public float generateZombieTimer;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= generateZombieTimer)
        {
            Instantiate(Zombie, transform.position, transform.rotation);
            timer = 0;
        }       
    }
}
