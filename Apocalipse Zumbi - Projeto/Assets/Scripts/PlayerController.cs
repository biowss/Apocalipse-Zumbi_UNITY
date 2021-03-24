using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    public float Speed = 10;
    public bool IsAlive = true;
    public int Health = 100;
    public LayerMask FloorMask;
    public GameObject TextGameOver;
    public InterfaceController interfaceControllerScript;
    public AudioClip HurtSound; 
    private Rigidbody playerRigidBody;
    private Animator playerAnimator;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerRigidBody = GetComponent<Rigidbody>();        
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {         
        // ----- Movimentação - Posição ----- //

        // Pegar Inputs = Edit -> Project Settings -> Inputs
        float AxisX = Input.GetAxis("Horizontal");
        float AxisZ = Input.GetAxis("Vertical");
        
        position = new Vector3(AxisX, 0, AxisZ);

        // ----- Movimentação - Animação ----- //
        if (position != Vector3.zero) 
        {
            playerAnimator.SetBool("Running", true);
        }
        else 
        {
            playerAnimator.SetBool("Running", false);
        }

        if(Health <= 0) 
        {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // FixedUpdate is called 50 times per second - No matter the frame rate
    void FixedUpdate()
    { 
        // ----- Movimentação Baseada na Fisica ----- //
        
        playerRigidBody.MovePosition(
            playerRigidBody.position + position * Speed * Time.deltaTime);

        // ----- Direcionando o personagem para o ponteiro ----- //

        Ray cameraFocus = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impact;

        if(Physics.Raycast(cameraFocus, out impact, 100, FloorMask)) 
        {
            Vector3 positionAimPlayer = impact.point - transform.position;


            Quaternion newRotation = Quaternion.LookRotation(positionAimPlayer);

            playerRigidBody.MoveRotation(newRotation);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        interfaceControllerScript.UpdateHealthSlider();
        AudioController.instance.PlayOneShot(HurtSound);

        if(Health <= 0)
        {            
            Time.timeScale = 0;
            TextGameOver.SetActive(true);
        }
    }
}
