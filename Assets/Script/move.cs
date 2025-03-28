using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
   [SerializeField]
   private float speed = 3f;
   private Rigidbody2D rb;
   private Transform player;
   private Vector2 moveDirection;
   private SpriteRenderer sprite;
   private Animator animPlayer;
   private float horizontal;
   private float vertical;
   private bool temRoupa = false;
   private BoxCollider2D emPe;
   private CapsuleCollider2D deitada;
   public Transform groundCheck;
   public LayerMask groundLayer;
   private bool isGrounded;
   private float groundCheckRadius = 0.2f;
  [Header("Pulo")]
   private float moveSpeed = 4f;
   private int jumpForce = 5;
   public Transform groundCheckPulo;
   public LayerMask groundLayerPulo;
   [SerializeField]private bool isGroundedPulo;
   [SerializeField]private bool isPulo;
   private float groundCheckRadiusPulo = 0.2f;
   private void Awake()
   {
      rb = GetComponent<Rigidbody2D>();
      sprite = GetComponent<SpriteRenderer>();
      animPlayer = GetComponent<Animator>();
      emPe = GetComponent<BoxCollider2D>();
      deitada = GetComponent<CapsuleCollider2D>();
      deitada.enabled = false;
      emPe.enabled = true;
      groundCheckPulo = transform.GetComponent<Transform>().Find(tag);
      groundCheck = GetComponent<Transform>();
   }
   private void Update()
   {
      CodePulo();
      if (emPe.enabled)
      {
         if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
         {
            sprite.flipX = false;
            animPlayer.SetLayerWeight(2, 1);
            animPlayer.SetLayerWeight(3, 0);
            animPlayer.SetLayerWeight(4, 0);

         }
         else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
         {
            sprite.flipX = true;
            animPlayer.SetLayerWeight(2, 1);
            animPlayer.SetLayerWeight(3, 0);
            animPlayer.SetLayerWeight(4, 0);
         }
         else
         {
            animPlayer.SetLayerWeight(2, 0);
            animPlayer.SetLayerWeight(3, 1);
         }
         if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
         {
            sprite.flipX = false;
            animPlayer.SetLayerWeight(1, 1);
            animPlayer.SetLayerWeight(3, 0);
            animPlayer.SetLayerWeight(4, 0);
         }
         else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
         {
            sprite.flipX = true;
            animPlayer.SetLayerWeight(0, 1);
            animPlayer.SetLayerWeight(1, 0);
            animPlayer.SetLayerWeight(3, 0);
            animPlayer.SetLayerWeight(4, 0);
         }
      }
      /*if(horizontal == 0 && vertical == 0)
      {
         animPlayer.SetLayerWeight(1, 0);
         animPlayer.SetLayerWeight(2, 0);
         animPlayer.SetLayerWeight(3, 1);
      }*/
      if (Input.GetKeyDown(KeyCode.C))
      {
         emPe.enabled = false;
         deitada.enabled = true;
         animPlayer.SetLayerWeight(4, 1);
         
      }
      else if (Input.GetKeyUp(KeyCode.C))
      {
         emPe.enabled = true;
         deitada.enabled = false;
         animPlayer.SetLayerWeight(4, 0);
      }
      /*if (horizontal == 0 && vertical == 1)
      {
         animPlayer.SetLayerWeight(4,0);
         animPlayer.SetLayerWeight(0,1);
      }
      else if (horizontal == 0 && vertical == 1)
       {
         animPlayer.SetLayerWeight(4,0);
         animPlayer.SetLayerWeight(1,1);
      }*/
   }
   private void FixedUpdate()
   {
      horizontal = Input.GetAxis("Horizontal");
      vertical = Input.GetAxis("Vertical");
      transform.position += new Vector3(speed * Time.fixedDeltaTime * horizontal, speed * Time.fixedDeltaTime * vertical, 0);
      /*isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
      if (isGrounded && Input.GetKey(KeyCode.Space) && emPe.enabled)
      {
         rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
      }*/
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
   if(collision.gameObject.CompareTag("Chão"))
         {
            isPulo = false;
         }
   }

   private void OnCollisionStay2D(Collision2D collision)
   {

   }

   private void OnCollisionExit2D(Collision2D collision)
   {

   }

   public void ColocaRoupa()
   {
      temRoupa = true;
   }

   public bool VerificaSeEstaComRoupa()
   {
      return temRoupa;
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
}