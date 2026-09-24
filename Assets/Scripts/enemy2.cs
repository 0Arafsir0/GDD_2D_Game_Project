using System.Dynamic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy2 : MonoBehaviour
{

    public float enemyHealth = 3f;

    public float walkspeed = 1.5f;
    public Transform groundCheckPoint;

    public float RaycastLength = 0.3f;

    public LayerMask whatIsGround;

    private bool facingleft;

    public float attackRangeRadius = 6f;
    public LayerMask TargetLayer;

    public Transform player;

    public float chaseSpeed = 2f;

    public float retrieveDistance = 3f;
    private Animator animator;

    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D;

    public GameObject FloatingText;

    public Transform EnemyDamageTextSpawnPoint;

    public Transform attackPoint;
    public float attackRadius = 1f;
    public LayerMask whatIsWater;



    void Start()
    {
        facingleft = true;
        animator = this.gameObject.GetComponent<Animator>();
        Rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        BoxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();
        
    }


    void Update()
    {
        if ((player==null))
        {
            animator.SetBool("Attack", false);
        }
        if (enemyHealth <= 0f)
        {
            die();
            
        }
        else
        {
            Collider2D collInfo = Physics2D.OverlapCircle(transform.position, attackRangeRadius, TargetLayer);

            if (collInfo)
            {
                if (player.position.x > transform.position.x && facingleft)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    facingleft = false;
                }
                else if (player.position.x < transform.position.x && facingleft == false)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    facingleft = true;
                }

                Vector2 targetPos = new Vector2(player.position.x, transform.position.y);

                if (Vector2.Distance(transform.position, targetPos) > retrieveDistance)
                {
                    animator.SetBool("Attack", false);
                    transform.position = Vector2.MoveTowards(transform.position, targetPos, chaseSpeed * Time.deltaTime);
                }
                else
                {
                    animator.SetBool("Attack", true);
                }
            }
            else
            {
                transform.Translate(Vector2.left * walkspeed * Time.deltaTime);

                RaycastHit2D hitInfo = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, RaycastLength, whatIsGround);

                if (hitInfo.collider == false)
                {
                    if (facingleft == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        facingleft = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        facingleft = true;
                    }
                }
            }
        }

    }

    public void Attack()
    {
        Collider2D collInfo = Physics2D.OverlapCircle(attackPoint.position, attackRadius, TargetLayer);

        if (collInfo)
        {
            if(collInfo.gameObject.GetComponent<Player>() != null)
            {
                Player.instance.PlayerTookDamage(1);
            }
        }

    }
        

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRangeRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);

        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(groundCheckPoint.position, groundCheckPoint.position + Vector3.down * RaycastLength);
        }

    }

    void EnemyTookDamage(int damageamount)
    {
        if (enemyHealth<=0f)
        {
            return;
        }
        animator.SetTrigger("Hit");
        enemyHealth -= damageamount;
        CameraShake.instance.ShakeCamera(1f, 0.12f);
        Instantiate(FloatingText, EnemyDamageTextSpawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            die();
            return;
        }
        if (other.gameObject.CompareTag("Arrow"))
        {
            EnemyTookDamage(1);
            Destroy(other.gameObject);
            
        }
    }
    
    public void ShakeCamera()
    {
        CameraShake.instance.ShakeCamera(3f, .15f);
    }  


    void die()
    {
        animator.SetBool("Death", true);
        Rigidbody2D.gravityScale = 0f;
        BoxCollider2D.enabled = false;
        Destroy(this.gameObject, 3f);

    }
}
            