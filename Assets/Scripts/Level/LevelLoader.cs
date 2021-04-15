using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    //public GameObject yourGameObj;
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        //yourGameObj = GameObject.Find("GameOver");
    }

    private void OnClick()
    {
        if(LevelName == "Lobby")
        {
            this.enabled = false;
            //yourGameObj.SetActive(false);
            SceneManager.LoadScene("Lobby");
        }
        else
        {
            SceneManager.LoadScene(LevelName);
        }
        //SceneManager.LoadScene(LevelName);
    }
}