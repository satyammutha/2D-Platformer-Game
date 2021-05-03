using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private GameObject LevelSelection;

    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        SoundManager.Instance.PlayOnce(SoundsForEvents.ButtonPlayClick);
        LevelSelection.SetActive(true);
    }
}
