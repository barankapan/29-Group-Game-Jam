using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Düşmanın hareket hızı
    public float moveDistance = 2f; // Düşmanın ne kadar mesafe gideceği7

    private Animator animator;
    float attackTime;

    private bool moveRight = true; // Düşmanın hareket yönü
    private Vector3 startPosition; // Düşmanın başlangıç pozisyonu
    private SpriteRenderer spriteRenderer; // Düşmanın sprite'ını çevirmek için


    void Start()
    {
        startPosition = transform.position; // Düşmanın başlangıç pozisyonunu kaydet
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // SpriteRenderer bileşenini al
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        var playerPos = PlayerTest.instance.transform.position;
        if (Vector3.SqrMagnitude(transform.position - playerPos) < 4f)
        {
            spriteRenderer.flipX = (transform.position.x > playerPos.x);
            if (attackTime > 0)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                //Attack
                animator.SetTrigger("Attack");
                Invoke(nameof(DamageHero), 0.1f);
                attackTime = 3f;
            }
            animator.SetBool("Move", false);
            return;
        }

        animator.SetBool("Move", true);
        attackTime = .3f;
        // Düşman sağa doğru hareket ederken belirli bir mesafeye ulaştıysa dönüş yap
        if (transform.position.x >= startPosition.x + moveDistance)
        {
            moveRight = false;
        }

        // Düşman sola doğru hareket ederken belirli bir mesafeye ulaştıysa dönüş yap
        if (transform.position.x <= startPosition.x - moveDistance)
        {
            moveRight = true;
        }

        // Düşmanın hareket yönüne göre hareket ettir
        if (moveRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = false; // Sağa doğru hareket ederken sprite'ı çevirme
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            spriteRenderer.flipX = true; // Sola doğru hareket ederken sprite'ı çevirme
        }
    }

    private void DamageHero()
    {
        PlayerTest.instance.getDamage(10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer düşman, "Bullet" tag'ine sahip bir obje ile temas ederse
        if (other.CompareTag("Bullet"))
        {
            // Düşmanı yok et
            this.gameObject.SetActive(false);
            // Ve ayrıca oku da yok et
            other.gameObject.SetActive(false);
        }
    }
}
