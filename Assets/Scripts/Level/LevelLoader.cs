﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        }

    private void OnClick()
    {
        Debug.Log("LevelName:"+LevelName);
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play level without unlocked");
                SoundManager.Instance.PlayOnce(SoundsForEvents.DisableClick);
                break;
            default:
                SoundManager.Instance.PlayOnce(SoundsForEvents.ButtonEnterLevelClick);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}