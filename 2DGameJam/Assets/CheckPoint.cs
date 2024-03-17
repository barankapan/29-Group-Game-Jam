using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.spawnPos = transform.position + Vector3.up * 2;
            PlayerTest.instance.getDamage(-40);
        }
    }
}
