using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D Rb2D;
    public float speed = 0;
    public float jump = 0;

    public ScoreController scoreController;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        Rb2D = gameObject.GetComponent <Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovementAnimation(horizontal, vertical);
        MoveCharacter(horizontal, vertical);
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
       Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (vertical > 0)
        {
            Rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayerMovementAnimation(float horizontal,float vertical)
    {   
        animator.SetFloat("speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
    
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(horizontal);
        }
        transform.localScale = scale;
        animator.SetBool("Crouch", Input.GetKey(KeyCode.C));

        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }
    public void PickUpKey()
    {
        Debug.Log("Player picked the key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer(float dmg)
    {
        Debug.Log("player killed by enemy..");
        PlayerStats.Instance.TakeDamage(dmg);
        if(PlayerStats.Instance.Health <= 0)
        {
            Destroy(gameObject);
            ReloadLevel();
        }

    }

    private void ReloadLevel()
    {
     
        SceneManager.LoadScene(0);
    }
}
