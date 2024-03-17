using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameManager.Instance.spawnPos;
            collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
}
