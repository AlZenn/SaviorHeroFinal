using UnityEngine;

public class sc_PlayerController : MonoBehaviour

{
    public float moveSpeed = 5.0f; // Hareket hýzý
    public Joystick joystick; // Joystick nesnesini baðlamak için public bir deðiþken
    

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveInputHorizontal = joystick.Horizontal;
        float moveInputVertical = joystick.Vertical;

        // Yatay ve dikey hareket hesaplama
        float moveX = moveInputHorizontal * moveSpeed;
        float moveY = moveInputVertical * moveSpeed;

        // Hareketi uygula
        rb.velocity = new Vector2(moveX, moveY);
        if (rb.velocity.magnitude > 0.01f)
        {
            animator.SetTrigger("PlayerWalk");
        }
        else
        {
            animator.SetTrigger("PlayerIdle");
        }
        float lookDirection = rb.velocity.normalized.x;
        animator.SetFloat("LookDirection", lookDirection);

        // Karakteri döndür

        Vector3 rotation = transform.rotation.eulerAngles;
        if (lookDirection > 0)
        {
            rotation.y = 180f;
            
        }
        else if (lookDirection < 0)
        {
            rotation.y = 0f;
        }
        else 
        {
            //rotation.y = 180f;
        }
        
        transform.rotation = Quaternion.Euler(rotation);
    }
}