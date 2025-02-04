using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Player Reached the end!!..");
            SceneManager.LoadScene("Level-2");
        }
    }
}
