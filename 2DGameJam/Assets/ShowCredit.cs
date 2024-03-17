using UnityEngine;

public class ShowCredit : MonoBehaviour
{
    public void Exectute()
    {
        Invoke(nameof(loadCredit), 3f);
    }

    private void loadCredit()
    {
        SceneLoader.Instance.LoadLevel(SceneEnum.creditScene);
    }
}
