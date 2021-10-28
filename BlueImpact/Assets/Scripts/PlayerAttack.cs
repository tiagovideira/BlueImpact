using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float PunchDamage;
    public float KickDamage;

    public float PunchDelay;
    public float KickDelay;

    public EnemyDetection PunchRange;
    public EnemyDetection KickRange;

    public float AttackDelta = 0;
    public float ComboDeltaTime;
    public bool InCombo = false;
    void Update()
    {
        AttackDelta += Time.deltaTime;

        if (AttackDelta > ComboDeltaTime)
        {
            InCombo = false;
        }

        if (Input.GetMouseButtonDown(0))//Punch
        {
            Invoke("Punch", PunchDelay);
            Debug.Log("Punch");
            InCombo = true;

            if (Input.GetMouseButtonDown(0) && AttackDelta <= ComboDeltaTime)//Punch Punch
            {
                Invoke("Punch", PunchDelay);
                Debug.Log("Punch Punch");

                if (Input.GetMouseButtonDown(0) && AttackDelta <= ComboDeltaTime)//Punch Punch Punch
                {
                    //QuickAttack
                    Debug.Log("QuickAttack");
                    if (Input.GetMouseButtonDown(1) && AttackDelta <= ComboDeltaTime)//Punch Punch Punch Kick
                    {
                        //Special Combo 3
                        Debug.Log("Combo 3");
                    }
                }
                else if (Input.GetMouseButtonDown(1) && AttackDelta <= ComboDeltaTime)//Punch Punch Kick
                {
                    //Special Combo 2
                    Debug.Log("Combo 2");
                }

            }
            else if (Input.GetMouseButtonDown(1) && AttackDelta <= ComboDeltaTime)//Punch Kick
            {
                //Special Combo 1
                Debug.Log("Combo 1");
            }

        }

        if (Input.GetMouseButtonDown(1))//Pontapé básico
        {
            Invoke("Kick", KickDelay);
            InCombo = true;
        }
    }

    private void Punch()
    {
        AttackDelta = 0;
        foreach (GameObject Enemy in PunchRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(PunchDamage);
        }
    }

    private void Kick()
    {
        AttackDelta = 0;
        foreach (GameObject Enemy in KickRange.EnemyList)
        {
            Enemy.GetComponent<EnemyHealth>().TakeDamage(KickDamage);
        }
    }
}