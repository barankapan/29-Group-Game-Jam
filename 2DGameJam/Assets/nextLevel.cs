using UnityEngine;

public class nextLevel : MonoBehaviour
{
    [SerializeField] private SceneEnum scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            SceneLoader.Instance.LoadLevel(scene);
        }
    }
}
