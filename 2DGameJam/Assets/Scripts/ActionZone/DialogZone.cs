using Cinemachine;
using UnityEngine;

public class DialogZone : MonoBehaviour
{
    [SerializeField] private multiDialog dialog;
    [SerializeField] private float size = 1f;
    private LayerMask layerMask;
    bool isPlayerClose;

    private void Start()
    {
        layerMask = LayerMask.GetMask("Player");
        if (!dialog)
        {
            Debug.Log("Dialog is empty");
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        isPlayerClose = Vector2.SqrMagnitude(transform.position - PlayerTest.instance.transform.position) > 25f;
        if (isPlayerClose) return;

        if (Physics2D.OverlapCircle(transform.position, size, layerMask))
        {
            DialogManager.instance.MultiDialog(dialog);
            this.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (isPlayerClose) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}