using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lobbyController : MonoBehaviour
{
    public Button PlayButton;
    public GameObject LevelSelection;

    private void Awake()
    {
        PlayButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        //SceneManager.LoadScene(1);
        LevelSelection.SetActive(true);
    }
}
