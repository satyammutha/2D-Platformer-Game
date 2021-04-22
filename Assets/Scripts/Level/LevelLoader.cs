using UnityEngine;
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
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(SoundsForEvents.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.Completed:
                Debug.Log("Level is already completed");
                SoundManager.Instance.Play(SoundsForEvents.ButtonClick);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}