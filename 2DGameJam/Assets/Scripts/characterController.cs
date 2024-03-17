using UnityEngine;

public class characterController : MonoBehaviour
{
    public float hareketHizi = 5f; // Karakterin hareket hızı
    private Animator animator; // Animator bileşeni
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        HareketKontrolleri();
    }

    void HareketKontrolleri()
    {
        float yatayHareket = Input.GetAxis("Horizontal"); // Sağ-sol tuşlarına karşılık gelen girişi al

        // Yukarı-Assagı tuşlarına karşılık gelen girişi al
        // Bu kısmı space tuşuna basılma kontrolü için değiştirdik
        float dikeyHareket = Input.GetKey(KeyCode.W) ? 1f : 0f;

        Vector3 hareket = new Vector3(yatayHareket, 0f, 0f); // Hareket vektörü oluştur

        Vector3 ziplama = new Vector3(0f, dikeyHareket, 0f); // Hareket vektörü oluştur

        transform.position += hareket * hareketHizi * Time.deltaTime; // Hareketi uygula

        transform.position += ziplama * 7f * Time.deltaTime; // Zıplama hareketi uygula
        if (dikeyHareket != 0f)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

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
}

