using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelController : MonoBehaviour
{
    public GameObject gameOverController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Reached the end!!..");
            LevelManager.Instance.MarkLevelComplete();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gameOverController.SetActive(true);
        }
    }
}
