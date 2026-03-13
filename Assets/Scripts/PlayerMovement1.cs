using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer characterSprite;
    private Animator anim;

    [SerializeField] private Transform groundCheck;
    private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private float jumpForce = 12f;

    
    // Tää SerializeField laittaa speed homman näkymään unityssä liukukytkimenä niin voi testailla nopeutta helpommin
    [SerializeField]
    private float speed = 20f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        characterSprite = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    void OnDrawGizmosSelected()
{
    if (groundCheck == null) return;
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
}
    //Pupun koko
    // protected float xScale = 3.9f;
    // protected float yScale = 3.9f;
    // protected float zScale = 0f;

    // Update is called once per frame

        // pupun liikkumisrajat (sivurajat)
    [SerializeField] float minX = -1000;
    [SerializeField] float maxX = 1000;
    private void Update()
    {
        // Liikkuminen sivuille
        float horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log(horizontalInput);
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        
        if(horizontalInput != 0)
        {
            anim.SetBool("isMoving", true);
        }
        else {
            anim.SetBool("isMoving", false);
        }

        // Ground check
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }

        // Sprite flip
        if (horizontalInput > 0.01f){
            characterSprite.flipX = true;
        }
        else if (horizontalInput < -0.01f)
        {
            characterSprite.flipX = false;
        }

        // Estä menemästä ruudun ulkopuolelle
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    
