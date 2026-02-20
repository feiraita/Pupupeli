using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private Rigidbody2D body;
    private SpriteRenderer characterSprite;

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
    private void Update()
    {
        // Liikkuminen sivuille
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        // Hyppääminen (like a jetpack kunnes kehitetään paremmaksi)
        // Ground check
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }

        // if-else if - Flippaa pupun siihen suuntaan mihin liikutaan
        if (horizontalInput > 0.01f){
            characterSprite.flipX = true;
        }
        else if (horizontalInput < -0.01f)
        {
            characterSprite.flipX = false;
        }

    }
}
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    
