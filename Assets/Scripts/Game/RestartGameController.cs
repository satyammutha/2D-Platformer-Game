using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RestartGameController : MonoBehaviour
{
    [SerializeField] private Button button;

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
