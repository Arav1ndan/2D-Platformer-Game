using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        if(animator != null )
        {
            Debug.Log("animator is attached correctly");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(speed);
        }
        transform.localScale = scale;
    }
}
