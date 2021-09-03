using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth=10.0f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = PlayerMovementScript.hitPoints + 1.0f;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
