using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("CAMERAS")]
    [SerializeField]
    private CinemachineVirtualCamera[] CamList;

    [Header("PLAYER")]
    [SerializeField]
    private Transform Player;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerTest>().transform;
        }
        GameState.changeState(state.play);
        ChangeCamera(cameraType.GameplayCamera, Player, Vector3.zero);
    }

    public void ChangeCamera(cameraType type, Transform target, Vector3 pos)
    {
        int cam = (int)type;
        for (int i = 0; i < CamList.Length; i++)
        {
            if (i == cam) { continue; }
            CamList[i].gameObject.SetActive(false);
            CamList[i].Priority = 10;
        }
        CamList[cam].Priority = 1;
        CamList[cam].gameObject.SetActive(true);
        switch (type)
        {
            case cameraType.GameplayCamera:
                CamList[cam].Follow = target.transform;
                break;
            case cameraType.DailogCamera:
                CamList[cam].Follow = target.transform;
                break;
            case cameraType.StaticCamera:
                CamList[cam].Follow = null;
                CamList[cam].transform.position = pos;
                break;
        }
    }
}


public enum cameraType { GameplayCamera, DailogCamera, StaticCamera }

