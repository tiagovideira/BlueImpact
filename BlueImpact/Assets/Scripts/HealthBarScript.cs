using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
    public float CurrentHealth;
    private float maxHealth = 100f;
    [SerializeField]
    private PlayerHealth playerHealthScript;
    private void Start()
    {
        healthBar = this.GetComponent<Image>();
    }

    private void Update()
    {
        CurrentHealth = playerHealthScript.health;
        healthBar.fillAmount = CurrentHealth / maxHealth;
    }

}
