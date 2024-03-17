using UnityEngine;

public class characterController : MonoBehaviour
{
    public float hareketHizi = 5f; // Karakterin hareket hızı
    [SerializeField] float JumpForce = 8f;
    private Animator animator; // Animator bileşeni
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni

    [Header("Animasyon")]
    [SerializeField] AnimationClip Fall;
    [SerializeField] AnimationClip Jump;

    bool canIJump;
    Rigidbody2D rb;
    private float yatayHareket;

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        //animator = GetComponent<Animator>(); // Animator bileşenini al
        //spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        //if (GameState.getState() != state.play) return;
        HareketKontrolleri();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(yatayHareket * hareketHizi, rb.velocity.y, 0);
        animator.SetBool("Fall", !GroundCheck());
        if (rb.velocity.y < 0.02f)
        {
            rb.AddForce(Vector2.down * 5f, ForceMode2D.Force);
            animator.SetBool("Jump", false);
            if (GroundCheck())
            {
                animator.SetBool("Fall", false);
            }
        }
    }

    void HareketKontrolleri()
    {
        yatayHareket = Input.GetAxisRaw("Horizontal");
        //float dikeyHareket = 0f;

        if (Input.GetKeyDown(KeyCode.W))
        {
            //dikeyHareket = 1f;
            //Zıplama tuşuna basıldıysa
            if (GroundCheck())
            {
                rb.velocity = new Vector3(rb.velocity.x, JumpForce, 0);
                animator.SetBool("Jump", true);
            }
        }

        //dikeyHareket = (Input.GetKeyUp(KeyCode.W)) ? 1f : 0f;

        Vector3 hareket = new Vector3(yatayHareket, 0f, 0f); // Hareket vektörü oluştur

        //Vector3 ziplama = new Vector3(0f, dikeyHareket, 0f); // Hareket vektörü oluştur

        //Fixed Update içine taşıdım.
        //transform.position += hareket * hareketHizi * Time.deltaTime; // Hareketi uygula

        //transform.position += ziplama * JumpForce * Time.deltaTime; // Zıplama hareketi uygula
        //if (dikeyHareket != 0f)
        //{
        //    animator.SetBool("Jump", true);
        //}
        //else
        //{
        //    animator.SetBool("Jump", false);
        //}

        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("Archery", true);
        }
        else
        {
            animator.SetBool("Archery", false);
        }

        // Run animasyonunu kontrol et
        if (yatayHareket != 0f)
        {
            animator.SetBool("Run", true); // Hareket ediliyorsa Run'u true yap

            if (yatayHareket < 0f)
            {
                spriteRenderer.flipX = true; // Sol tarafa hareket ediliyorsa sprite'ı çevir
            }
            else
            {
                spriteRenderer.flipX = false; // Sağ tarafa hareket ediliyorsa sprite'ı çevirme
            }
        }
        else
        {
            animator.SetBool("Run", false); // Hareket edilmiyorsa Run'u false yap
        }


    }



    private bool GroundCheck()
    {
        //Zemin kontrolü işlemi
        return Physics2D.OverlapCircle(transform.position, .5f, LayerMask.GetMask("Ground"));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, .5f);
    }
}

