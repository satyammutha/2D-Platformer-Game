using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RestartGameController : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.BackButton);
        SceneManager.LoadScene(0);
    }
}
