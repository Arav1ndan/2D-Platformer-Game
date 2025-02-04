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
        levelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case levelStatus.Locked:
                Debug.Log("Can't play this level yet...");
                break;
            case levelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(levelName);
                
                
                break;
            case levelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(levelName);
                
                break;
             
        }
        
    }
}
