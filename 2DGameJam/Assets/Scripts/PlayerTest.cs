using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public static PlayerTest instance;
    [SerializeField] private int health = 100;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private void Awake()
    {
        instance = this;
        UIManager.Instance.UpdateHealthBar(health);
    }
    private void Update()
    {
        if (GameState.getState() != state.play) return;

        float x = Input.GetAxisRaw("Horizontal");

        if (x != 0)
        {
            var pos = transform.position;
            pos.x += x * Time.deltaTime * speed;
            transform.position = pos;
        }
    }

    public void getDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameState.changeState(state.pause);
        }
        UIManager.Instance.UpdateHealthBar(health);
    }
    public Vector3 getPosition()
    {
        return transform.position;
    }
}
