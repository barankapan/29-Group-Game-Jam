using System.Collections;
using UnityEngine;

public class Stone : MonoBehaviour
{
    Vector3 startPOs;

    private void Awake()
    {
        startPOs = transform.position;
    }
    public void Execute(Vector3 direction)
    {
        transform.position = startPOs;
        StartCoroutine(throwStone(direction));
    }

    IEnumerator throwStone(Vector3 direction)
    {
        float t = 0;
        while (t < 10)
        {
            transform.position += Time.deltaTime * direction * 10f;
            t += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerTest.instance.getDamage(10);
            StopCoroutine(throwStone(Vector3.zero));
            gameObject.SetActive(false);
        }
    }
}
