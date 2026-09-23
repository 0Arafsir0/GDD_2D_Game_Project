using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public int maxHealth = 3;
    private bool facingleft;
    public float attackRadius = 6f;
    public LayerMask TargetLayer;
    public Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2d;
    public GameObject FloatingText;
    public Transform EnemyDamageTextSpawnPoint;

    [Header("Attack Settings")]
    public Transform firePoint;
    public GameObject enemyArrowPrefab;
    public float arrowSpeed = 5f;

    private bool isPlayerInRange;
    public Vector3 offset;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        facingleft = true;
        isPlayerInRange = false;
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        boxCollider2d = this.GetComponent<BoxCollider2D>();
        if(player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            animator.SetBool("Attack", false);
        }

        if(player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (maxHealth <= 0)
        {
            animator.SetBool("Death", true);
            die();
            return;
        }
        Collider2D collInfo = Physics2D.OverlapCircle(transform.position + offset, attackRadius, TargetLayer);

        if (collInfo)
        {
            isPlayerInRange = true;
            animator.SetBool("Attack", true);
        }
        else
        {
            isPlayerInRange = false;
            animator.SetBool("Attack", false);
        }
        if (isPlayerInRange)
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
        }

    }

    public void FireArrow()
    {
        GameObject tempArrowPrefab = Instantiate(enemyArrowPrefab, firePoint.position, firePoint.rotation);
        tempArrowPrefab.GetComponent<Rigidbody2D>().linearVelocity = -firePoint.right * arrowSpeed;
    }


    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(firePoint.position, attackRadius);

    }

    void EnemyTookDamage(int damageamount)
    {
        if (maxHealth <= 0f)
        {
            return;
        }
        animator.SetTrigger("Hit");
        maxHealth -= damageamount;
        CameraShake.instance.ShakeCamera(1f, 0.12f);
        Instantiate(FloatingText, EnemyDamageTextSpawnPoint.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        rb.gravityScale = 0f;
        boxCollider2d.enabled = false;
        Destroy(this.gameObject, 3f);

    }
}
