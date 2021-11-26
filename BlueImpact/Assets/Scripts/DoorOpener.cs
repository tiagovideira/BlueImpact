using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField]
    private int doorHealth = 3;
    [SerializeField]
    private int doorHits = 0;
    [SerializeField]
    public EnemyDetection KickRange;
    [SerializeField]
    private GameObject DoorTrigger;
    public void OpenDoor()
    {
        foreach (GameObject Door in KickRange.DoorList)
        {
            doorHits++;
            if (doorHits >= doorHealth)
            {
                DoorTrigger.SetActive(false);
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

}
