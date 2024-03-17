using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefabı
    public Transform firePoint; // Mermi çıkış noktası
    public float bulletSpeed = 20f; // Mermi hızı

    private bool isFiring = false; // Ateş durumu
    private GameObject currentBullet; // Oluşturulan mermi

    void Update()
    {
        // 'F' tuşuna basılırsa ve ateş durumu false ise
        if (Input.GetKeyDown(KeyCode.F) && !isFiring)
        {
            // Mermiyi oluştur ve ateş durumunu true yap
            currentBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            isFiring = true;
        }

        // 'F' tuşu basılı değilse ve ateş durumu true ise
        if (Input.GetKeyUp(KeyCode.F) && isFiring)
        {
            // Mermiyi hareket ettir ve ateş durumunu false yap
            Rigidbody2D rb = currentBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(bulletSpeed, -3); // X ekseninde ileri doğru hareket
            isFiring = false;
        }
    }
}



