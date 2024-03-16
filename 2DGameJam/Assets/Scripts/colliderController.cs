using UnityEngine;

public class colliderController : MonoBehaviour
{
    public BoxCollider2D runCollider;
    public BoxCollider2D idleCollider;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al

        runCollider.enabled = false; // Başlangıçta sadece idle collider'ı aktif olsun
        idleCollider.enabled = true;
    }

    void Update()
    {
        float yatayHareket = Input.GetAxis("Horizontal"); // Sağ-sol tuşlarına karşılık gelen girişi al

        // Run animasyonunu kontrol et
        if (yatayHareket != 0f)
        {
            animator.SetBool("Run", true); // Hareket ediliyorsa Run'u true yap
            animator.SetBool("Idle", false); // Idle animasyonunu kapat

            if (yatayHareket < 0f)
            {
                spriteRenderer.flipX = true; // Sol tarafa hareket ediliyorsa sprite'ı çevir
            }
            else
            {
                spriteRenderer.flipX = false; // Sağ tarafa hareket ediliyorsa sprite'ı çevirme
            }

            // Collider'ları ayarla
            runCollider.enabled = true;
            idleCollider.enabled = false;
        }
        else
        {
            animator.SetBool("Run", false); // Hareket edilmiyorsa Run'u false yap
            animator.SetBool("Idle", true); // Idle animasyonunu aç

            // Collider'ları ayarla
            runCollider.enabled = false;
            idleCollider.enabled = true;
        }
    }
}
