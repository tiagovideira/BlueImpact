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
    public string Combo;
    public int ComboCounter;
    void Update()
    {
        AttackDelta += Time.deltaTime;

        if (AttackDelta > ComboDeltaTime)
        {
            ComboCounter = 0;
        }

        if (Input.GetMouseButtonDown(0) && ComboCounter == 0)//Punch
        {
            Invoke("Attack", PunchDelay);
            Combo = "P";
            Debug.Log(Combo);

            if (Input.GetMouseButtonDown(0) && AttackDelta <= ComboDeltaTime && Combo == "P" && ComboCounter == 1)//Punch Punch
            {
                Combo = "PP";
                Invoke("Attack", PunchDelay);
                Debug.Log(Combo);

                if (Input.GetMouseButtonDown(0) && AttackDelta <= ComboDeltaTime && Combo == "PP" && ComboCounter == 2)//Punch Punch Punch
                {
                    //QuickAttack
                    Combo = "PPP";
                    Invoke("Attack", PunchDelay);
                    Debug.Log(Combo);

                    if (Input.GetMouseButtonDown(1) && AttackDelta <= ComboDeltaTime && Combo == "PPP" && ComboCounter == 3)//Punch Punch Punch Kick
                    {
                        //Special Combo 3
                        Combo = "PPPK";
                        Invoke("Attack", PunchDelay);
                        Debug.Log(Combo);
                    }
                }
                else if (Input.GetMouseButtonDown(1) && AttackDelta <= ComboDeltaTime && Combo == "PP" && ComboCounter == 2)//Punch Punch Kick
                {
                    //Special Combo 2
                    Combo = "PPK";
                    Invoke("Attack", PunchDelay);
                    Debug.Log(Combo);

                }

            }
            else if (Input.GetMouseButtonDown(1) && AttackDelta <= ComboDeltaTime && Combo == "P" && ComboCounter == 1)//Punch Kick
            {
                //Special Combo 1
                Combo = "PK";
                Invoke("Attack", PunchDelay);
                Debug.Log(Combo);
            }

        }

        if (Input.GetMouseButtonDown(1) && ComboCounter == 0)//Pontapé básico
        {
            Combo = "K";
            Invoke("Attack", PunchDelay);
            Debug.Log(Combo);
            Invoke("Kick", KickDelay);
        }
    }

    private void Attack()
    {
        switch (Combo)
        {
            case "P":
            ComboCounter = 1;
                Punch();
                break;
            case "K":
            ComboCounter = 1;
                Kick();
                break;
            case "PP":
            ComboCounter = 2;
                break;
            case "PK":
            ComboCounter = 2;
                break;
            case "PPP":
            ComboCounter = 3;
                break;
            case "PPK":
            ComboCounter = 3;
                break;
            case "PPPK":
            ComboCounter = 4;
                break;
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