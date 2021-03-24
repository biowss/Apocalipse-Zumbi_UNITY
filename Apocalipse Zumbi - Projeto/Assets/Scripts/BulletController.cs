using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour 
{    
    public float Speed = 30;
    public AudioClip DeathSound;
    private Rigidbody bulletRigidBody;    

    // Start is called before the first frame update
    void Start() 
    {
        bulletRigidBody = GetComponent<Rigidbody>();   
    }

    // FixedUpdate is called 50 times per second - No matter the frame rate
    void FixedUpdate() 
    {
        bulletRigidBody.MovePosition(
            bulletRigidBody.position + transform.forward * Speed * Time.deltaTime
        );
    }   

    // Collider have "Is Trigger" On.
    void OnTriggerEnter(Collider colliderObject) 
    {
        if(colliderObject.tag == "Inimigo") 
        {
            Destroy(colliderObject.gameObject);
            AudioController.instance.PlayOneShot(DeathSound);
        }

        Destroy(gameObject);
    }
}
