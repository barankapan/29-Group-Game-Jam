using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private Image SpeakerImage;
    [SerializeField] private TMP_Text DialogText;

    private Image panel;

    private void Awake()
    {
        instance = this;
        DialogPanel.SetActive(false);
    }
    private void DialogExecute(Dialog obj)
    {
        DialogPanel.SetActive(true);
        SpeakerImage.sprite = obj.SpeakerImage;
        DialogText.text = obj.text;
        Invoke(nameof(CloseDialog), obj.duration);
    }

    public void MultiDialog(multiDialog dialogList)
    {
        GameManager.Instance.ChangeCamera(cameraType.DailogCamera, PlayerTest.instance.transform);
        StartCoroutine(multiExecute(dialogList));
    }

    private void CloseDialog()
    {
        DialogPanel.SetActive(false);
    }

    IEnumerator multiExecute(multiDialog list)
    {
        if (list.multiDialogList.Length == 0) yield break;
        GameState.changeState(state.dialog);
        for (int i = 0; i < list.multiDialogList.Length; i++)
        {
            DialogExecute(list.multiDialogList[i]);
            yield return new WaitForSeconds(list.multiDialogList[i].duration + 0.2f);
        }
        GameState.changeState(state.play);
        GameManager.Instance.ChangeCamera(cameraType.GameplayCamera, PlayerTest.instance.transform);
    }
}
