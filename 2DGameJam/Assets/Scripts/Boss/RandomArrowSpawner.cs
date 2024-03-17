using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomArrowSpawner : MonoBehaviour
{
    [SerializeField] Transform[] arrows;
    public float t = 7f;
    private float x;

    private void Update()
    {
        if (x > 0)
        {
            x -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < arrows.Length; i++)
            {
                arrows[i].gameObject.SetActive(true);
            }
            x = t;
        }
    }
}
