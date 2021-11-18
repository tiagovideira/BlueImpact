using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField]
    private int doorHealth = 3;
    [SerializeField]
    private int doorHits = 0;
    [SerializeField]
    public EnemyDetection KickRange;
    public void OpenDoor()
    {
        foreach (GameObject Door in KickRange.DoorList)
        {
            doorHits++;
            if (doorHits >= doorHealth)
            {
                transform.parent.gameObject.SetActive(false);
            }
        }
    }

}
