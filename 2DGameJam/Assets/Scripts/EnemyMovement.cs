using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Düşmanın hareket hızı
    public float moveDistance = 2f; // Düşmanın ne kadar mesafe gideceği

    private bool moveRight = true; // Düşmanın hareket yönü
    private Vector3 startPosition; // Düşmanın başlangıç pozisyonu
    private SpriteRenderer spriteRenderer; // Düşmanın sprite'ını çevirmek için

    void Start()
    {
        startPosition = transform.position; // Düşmanın başlangıç pozisyonunu kaydet
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
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

    void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer düşman, "Bullet" tag'ine sahip bir obje ile temas ederse
        if (other.CompareTag("Bullet"))
        {
            // Düşmanı yok et
            Destroy(gameObject);
            // Ve ayrıca oku da yok et
            Destroy(other.gameObject);
        }
    }
}
