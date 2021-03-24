using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public Slider HealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        HealthSlider.maxValue = playerControllerScript.Health;
        UpdateHealthSlider();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealthSlider() {
        HealthSlider.value = playerControllerScript.Health;
    }
}
