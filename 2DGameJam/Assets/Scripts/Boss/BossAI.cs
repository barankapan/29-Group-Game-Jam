using System.Collections;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    [SerializeField] Stone[] stoneList;
    [SerializeField] Animator bossAnimator;
    [SerializeField] multiDialog BossDialog;
    int currentIndex = 0;

    [SerializeField] bool isWeak;
    [SerializeField] float bossHealth = 100;

    [SerializeField] Vector2 upStone;
    [SerializeField] Vector2 downStone;
    [SerializeField] Vector2 midStone;
    [SerializeField] Vector2 topStone;

    public GameObject winScreen;
    private void Awake()
    {
        StartCoroutine(boss());

    }
    IEnumerator boss()
    {

        WaitForSeconds sec = new WaitForSeconds(1.5f);
        //Animasyon Idle
        bossAnimator.SetBool("Idle", true);
        yield return new WaitForSeconds(3f);
        //Konuþma
        DialogManager.instance.MultiDialog(BossDialog, cameraType.StaticCamera);
        yield return new WaitForSeconds(5f);
        //Döngü
        while (bossHealth > 0)
        {
            bossAnimator.SetBool("Idle", true);
            isWeak = false;
            bossAnimator.SetTrigger("Up");
            yield return sec;
            ThrowStone(upStone);
            bossAnimator.ResetTrigger("Up");
            yield return sec;
            bossAnimator.SetTrigger("Mid");
            yield return sec;
            bossAnimator.ResetTrigger("Mid");
            ThrowStone(midStone);
            yield return sec;
            bossAnimator.SetTrigger("Down");
            yield return sec;
            bossAnimator.ResetTrigger("Down");
            ThrowStone(downStone);
            yield return sec;
            isWeak = true;
            bossAnimator.SetBool("Idle", false);
            yield return new WaitForSeconds(5f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            bossHealth -= (isWeak ? 20 : 10);
            collision.gameObject.SetActive(false);
            if (bossHealth < 0)
            {
                gameObject.SetActive(false);
                winScreen.SetActive(true);
            }
        }
    }
    void ThrowStone(Vector2 pos)
    {
        stoneList[currentIndex].gameObject.SetActive(true);
        stoneList[currentIndex].Execute(Vector3.left);
        currentIndex++;
        if (currentIndex >= stoneList.LongLength)
        {
            currentIndex = 0;
        }
    }


}

