using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobbyController : MonoBehaviour
{
    public Button PlayButton;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
