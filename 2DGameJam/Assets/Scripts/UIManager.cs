using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("MAIN MENU")]
    [SerializeField] Button _Play;


    [Space]
    [Header("IN GAME UI")]
    [SerializeField] Slider _HealthSlider;
    [SerializeField] Button _Pause;
    [SerializeField] Button _SoundOnOff;

    [Space]
    [Header("IN GAME MENU")]
    [SerializeField] Button _Continue;
    [SerializeField] Button _Exit;

    [Header("SETTINGS")]
    [SerializeField] Slider _SoundSlider;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _Continue.onClick.AddListener(btn_Continue);
        _Pause.onClick.AddListener(btn_Pause);
        _Exit.onClick.AddListener(btn_Exit);
        _SoundSlider.onValueChanged.AddListener(delegate { UpdateSoundLevel(); });
        _SoundOnOff.onClick.AddListener(SoundOnOff);
    }

    private void btn_Exit()
    {
        Application.Quit();
    }

    private void btn_Pause()
    {
        GameState.changeState(state.pause);
        Time.timeScale = 0f;
    }

    private void btn_Continue()
    {
        GameState.changeState(state.play);
        Time.timeScale = 1f;
    }

    public void UpdateHealthBar(float health)
    {
        _HealthSlider.value = health;
    }
    public void UpdateArrowCount()
    {

    }
    private void SoundOnOff()
    {
        SoundManager.instance.MuteOnOff();
    }
    private void UpdateSoundLevel()
    {
        SoundManager.instance.changeVolume(_SoundSlider.value);
    }
}
