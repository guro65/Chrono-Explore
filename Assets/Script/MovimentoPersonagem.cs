using UnityEngine;

public class MovimentoPersonagemFlip : MonoBehaviour
{
    public float velocidadeAndando = 5f;
    public float velocidadeCorrendo = 8f;
    public float forcaPulo = 10f;

    [Tooltip("Tempo mínimo em segundos entre pulos")]
    public float tempoEntrePulos = 0.5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool estaNoChao = false;
    private float tempoUltimoPulo = -Mathf.Infinity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float movimento = 0f;

        // Detecta se está correndo (Shift pressionado)
        bool correndo = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float velocidadeAtual = correndo ? velocidadeCorrendo : velocidadeAndando;

        if (Input.GetKey(KeyCode.A))
        {
            movimento = -velocidadeAtual;
            spriteRenderer.flipX = true; // vira o sprite para esquerda
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movimento = velocidadeAtual;
            spriteRenderer.flipX = false; // sprite normal para direita
        }
        else
        {
            movimento = 0f;
        }

        // Move o personagem horizontalmente
        Vector2 velocidadePersonagem = rb.linearVelocity;
        velocidadePersonagem.x = movimento;
        rb.linearVelocity = velocidadePersonagem;

        // Pulo com cooldown e só se estiver no chão
        if (Input.GetKeyDown(KeyCode.Space) && estaNoChao && Time.time >= tempoUltimoPulo + tempoEntrePulos)
        {
            rb.AddForce(new Vector2(0f, forcaPulo), ForceMode2D.Impulse);
            estaNoChao = false; // já está no ar
            tempoUltimoPulo = Time.time;
        }

        // Atualiza os parâmetros do Animator
        animator.SetBool("andando", movimento != 0);
        animator.SetBool("Correndo", correndo && movimento != 0);
        animator.SetBool("Pulando", !estaNoChao);
    }

    // Detecta colisão com o chão para permitir pulo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = false;
        }
    }
}
