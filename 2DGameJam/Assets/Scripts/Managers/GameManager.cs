using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("CAMERAS")]
    [SerializeField]
    private CinemachineVirtualCamera[] CamList;
    [SerializeField]
    private cameraType startCamera;
    public Vector3 spawnPos;

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
            spawnPos = Player.position;
        }
        GameState.changeState(state.play);
        ChangeCamera(startCamera, Player);

    }

    public void ChangeCamera(cameraType type, Transform target)
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
                break;
        }
    }

    public void ChangeScene(SceneEnum scene)
    {
        SceneLoader.Instance.LoadLevel(scene);
    }
}


public enum cameraType { GameplayCamera, DailogCamera, StaticCamera }

