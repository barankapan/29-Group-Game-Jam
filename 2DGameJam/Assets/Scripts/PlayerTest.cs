using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public static PlayerTest instance;
    [SerializeField] private int health = 100;
    [SerializeField] private int arrowCount = 20;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        UIManager.Instance.UpdateHealthBar(health);
        UIManager.Instance.UpdateArrowCount(arrowCount);
    }

    public void getDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameState.changeState(state.pause);
            SceneLoader.Instance.LoadCurrentScene();
        }
        health = Mathf.Clamp(health, 0, 100);
        UIManager.Instance.UpdateHealthBar(health);
    }
    public void UpdateArrowCount(int count)
    {
        arrowCount += count;
        UIManager.Instance.UpdateArrowCount(arrowCount);
    }
    public int getArrowCount()
    {
        return arrowCount;
    }
    public Vector3 getPosition()
    {
        return transform.position;
    }
}
