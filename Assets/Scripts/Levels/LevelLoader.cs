using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(Button))] 
public class LevelLoader : MonoBehaviour
{
    private Button Button;
    public string levelName;
    private void Awake()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(Onclick);
    }

    private void Onclick()
    {
        SceneManager.LoadScene(levelName);
    }
}
