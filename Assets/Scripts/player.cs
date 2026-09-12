using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator animator;
    public float jumpForce = 7f;
    private float movement;
    public float movespeed = 5f;
    private bool isGrounded;

    private bool facingRight;

    public Transform groundCheckPoint;
    public float groundCheckRadius = .2f;
    public LayerMask whatIsGround;
    
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed = 7f;

    void Start()
     {
          isGrounded = true;
          facingRight = true;
          animator = this.gameObject.GetComponent<Animator>();

    }

    void Update()
    {
        movement = 0f;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            movement = -1f;
            

        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            movement = 1f;

        if (Keyboard.current.spaceKey.isPressed)
            jump();

        Collider2D collInfo = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround); 
       
        if (collInfo)
        {
            isGrounded = true;
        }
        PlayRunAnimation();
        Flip();

        if(Input.GetMouseButtonDown(0))
        {
           animator.SetTrigger("fire");
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement*movespeed, 0f, 0f) * Time.fixedDeltaTime;
    }

    public void FireArrow()
    {
        GameObject tempArrowPrefab =Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        tempArrowPrefab.GetComponent<Rigidbody2D>().linearVelocity = arrowSpawnPoint.right * arrowSpeed; 
    }
    private void PlayRunAnimation()
    {
        if(movement != 0f)
        {
            animator.SetFloat("Run",1);
        }
        else
        {
            animator.SetFloat("Run", 0);
        }
    }
    private void Flip() {
        if (movement < 0f && facingRight==true)
        {
            facingRight = false;
            transform.eulerAngles = new Vector3(0f, -180f, 0f);

        }
        else
        {
            if (movement > 0f && facingRight == false)
            {
                facingRight = true;
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
    }

    private void jump()
    {
        if (isGrounded)
        {
            Vector2 velocity = rb.linearVelocity;
            velocity.y = jumpForce;
            rb.linearVelocity = velocity;
            isGrounded = false;
            animator.SetBool("jump", true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("jump", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        if(groundCheckPoint == null) {
            return; 
        }
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        
    }
}