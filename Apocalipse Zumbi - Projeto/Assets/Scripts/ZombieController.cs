using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour 
{
    public GameObject Player;
    public float Speed = 3;
    private Rigidbody zombieRigidBody;
    private Animator zombieAnimator;

    void Start() 
    {
        Player = GameObject.FindWithTag("Player");
        int zombieType = Random.Range(1, 28);
        transform.GetChild(zombieType).gameObject.SetActive(true);
        zombieRigidBody = GetComponent<Rigidbody>();        
        zombieAnimator = GetComponent<Animator>();
    }
    void FixedUpdate() 
    {        
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        // Pega a direção do jogador em relação a posição do zumbi
        Vector3 direction = Player.transform.position - transform.position;

        // Rotação do zumbi
        Quaternion newRotation = Quaternion.LookRotation(direction);
        zombieRigidBody.MoveRotation(newRotation);

        if(distance > 2.4) 
        {
            // Movimentação do zumbi até o jogador (direção normalizada para andar igual ao jogador)
            zombieRigidBody.MovePosition(
                zombieRigidBody.position + direction.normalized * Speed * Time.deltaTime);

            zombieAnimator.SetBool("Attacking", false);
        }
        else
        {
            zombieAnimator.SetBool("Attacking", true);
        }
    }

    // Event of animation trigger the method AttackPlayer
    void AttackPlayer() 
    {
        int damage = Random.Range(20, 30);
        Player.GetComponent<PlayerController>().TakeDamage(damage);
    }
}
