using UnityEngine;

[CreateAssetMenu(fileName = "NewMultiDialog", menuName = "ScriptableObjects/NewsMultiDialog", order = 1)]
public class multiDialog : ScriptableObject
{
    public Dialog[] multiDialogList;
}

[System.Serializable]
public class Dialog
{
    [TextArea] public string text = "Hello World";
    public Sprite SpeakerImage;
    public float duration = 1f;
}