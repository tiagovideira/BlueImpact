using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AzuraGaugeScript : MonoBehaviour
{
    private Image azuraGauge;
    public float CurrentEnergy;
    private float maxEnergy = 100f;
    [SerializeField]
    private PlayerAttack playerAttackScript;
    private void Start()
    {
        azuraGauge = this.GetComponent<Image>();
    }

    private void Update()
    {
        CurrentEnergy = playerAttackScript.Energy;
        azuraGauge.fillAmount = CurrentEnergy / maxEnergy;
    }
    

}
