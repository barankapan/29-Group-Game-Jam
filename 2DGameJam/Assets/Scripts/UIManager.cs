using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button _Play;
    [SerializeField] Button _Pause;
    [SerializeField] Button _Exit;
    [SerializeField] Button _Continue;

    private void Start()
    {
        _Continue.onClick.AddListener(btn_Continue);
        _Pause.onClick.AddListener(btn_Pause);
    }

    private void btn_Pause()
    {
        GameState.changeState(state.pause);
    }

    private void btn_Continue()
    {
        GameState.changeState(state.play);
    }
}
