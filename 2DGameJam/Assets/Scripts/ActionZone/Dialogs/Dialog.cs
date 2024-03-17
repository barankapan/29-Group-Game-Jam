using UnityEngine;

[CreateAssetMenu(fileName = "NewMultiDialog", menuName = "ScriptableObjects/NewsMultiDialog", order = 1)]
public class multiDialog : ScriptableObject
{
    public Dialog[] multiDialogList;

}

[System.Serializable]
public struct Dialog
{
    [TextArea] public string text;
    public Sprite SpeakerImage;
    public float duration;
}