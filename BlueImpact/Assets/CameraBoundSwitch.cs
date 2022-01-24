using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBoundSwitch : MonoBehaviour
{
    public CinemachineConfiner Confiner;
    public CinemachineVirtualCamera vcam;


    public PolygonCollider2D Level0Collider;
    public PolygonCollider2D Level1Collider;
    public PolygonCollider2D Level2Collider;


    public void ChangeCameraBound(int CurrentLevel)
    {
        switch (CurrentLevel)
        {
            case 0:
                Confiner.m_BoundingShape2D = Level1Collider;
                break;

            case 1:
                Confiner.m_BoundingShape2D = Level2Collider;
                vcam.m_Lens.OrthographicSize = 7.25f;
                break;

        }
        Confiner.InvalidatePathCache();//Fix a bug de não mudar o confiner
    }

}
