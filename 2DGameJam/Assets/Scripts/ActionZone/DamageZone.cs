using System;
using System.Collections;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private Vector2 ZoneSize = Vector2.one;
    [SerializeField] private int Damage = 10;
    [SerializeField] private float damageTime = 0.2f;
    bool isPlayerClose;
    bool hit;
    private LayerMask playerLayer;
    WaitForSeconds damageTimer;
    WaitForSeconds fixedUpdateSpeed;
    private void Start()
    {
        damageTimer = new WaitForSeconds(damageTime);
        fixedUpdateSpeed = new WaitForSeconds(0.04f);
        playerLayer = LayerMask.GetMask("Player");
        StartCoroutine(DamageZoneCoroutine());
    }

    private IEnumerator DamageZoneCoroutine()
    {
        while (true)
        {
            isPlayerClose = !(Vector2.SqrMagnitude(transform.position - PlayerTest.instance.getPosition()) > 25f);

            if (isPlayerClose)
            {
                hitCheck();
                yield return damageTimer;
            }
            else
            {
                yield return fixedUpdateSpeed;
            }
        }
    }

    private void hitCheck()
    {
        hit = Physics2D.OverlapBox(transform.position, ZoneSize, default, playerLayer);
        if (hit)
        {
            PlayerTest.instance.getDamage(Damage);
            Debug.Log($"Hit {Damage}");
        }
    }

    private void OnDrawGizmos()
    {
        if (isPlayerClose)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, ZoneSize);
        }

    }
}
