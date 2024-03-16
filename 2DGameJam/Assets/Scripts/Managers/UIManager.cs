using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Main Menu")]
    [SerializeField] bool mainMenu;
    [SerializeField] Button _Play;

    [Space]
    [Header("GamePlayUI")]
    [SerializeField] bool InGame;
    [SerializeField] Slider _HealthSlider;
    [SerializeField] TMP_Text _ArrowText;
    [SerializeField] Button _Pause;
    [SerializeField] Button _SoundOnOff;

    [Space]
    [Header("Pause Menu")]
    [SerializeField] Button _Continue;
    [SerializeField] Button _Exit;

    [Header("Settings")]
    [SerializeField] Slider _SoundSlider;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        if (InGame)
        {
            _Continue.onClick.AddListener(btn_Continue);
            _Pause.onClick.AddListener(btn_Pause);
            _SoundOnOff.onClick.AddListener(SoundOnOff);
        }

        if (mainMenu)
        {
            _Play.onClick.AddListener(btn_Play);
        }
        _Exit.onClick.AddListener(btn_Exit);
        _SoundSlider.onValueChanged.AddListener(delegate { UpdateSoundLevel(); });
    }

    private void btn_Play()
    {
        //LoadScene Gameplay
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
    public void UpdateArrowCount(int value)
    {
        _ArrowText.text = value.ToString();
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
