/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPulo : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    [SerializeField]private bool isGrounded;
    [SerializeField]private bool isPulo;
    private float groundCheckRadius = 0.2f;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    CodePulo();
    }

    public void CodePulo()
    {
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if(Input.GetKeyDown(KeyCode.Space)&&!isPulo)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isPulo = true;
        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chão"))
        {
            isPulo = false;
        }
    }
}
*/