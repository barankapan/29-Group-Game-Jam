using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    private enum BossState { Attack, Weak, Die }
    private BossState state;
    [Header("Boss Setup")]
    [SerializeField] private int Health = 1000;
    [SerializeField] private float attackStateLenght = 15f;
    [SerializeField] private float weakStateLenght = 7f;

    private int multiplier;

    [Header("Stone Setups")]
    [SerializeField] private Transform[] stones;
    [SerializeField] private float StoneSpeed = 4;
    [SerializeField] private int Damage = 20;

    WaitForSeconds attackTimer;
    WaitForSeconds weakTimer;

    private void Start()
    {
        attackTimer = new WaitForSeconds(attackStateLenght);
        weakTimer = new WaitForSeconds(weakStateLenght);
        StartCoroutine(BossRoutine());
    }
    private void FixedUpdate()
    {
        switch (state)
        {
            case BossState.Attack:
                for (int i = 0; i < stones.Length; i++)
                {
                    stones[i].position += Vector3.left * Time.fixedDeltaTime * StoneSpeed;
                    bool hit = Physics2D.OverlapCircle(stones[i].position, 1f, LayerMask.GetMask("Player"));
                    if (hit)
                    {
                        stones[i].gameObject.SetActive(false);
                        PlayerTest.instance.getDamage(Damage);
                        resetStone(stones[i]);
                    }

                    if (stones[i].position.x < -20f)
                    {
                        resetStone(stones[i]);
                    }
                }
                break;
        }

        if (GameState.getState() == global::state.pause)
        {
            resetAllStone(false);
            this.enabled = false;
        }
    }
    IEnumerator BossRoutine()
    {
        while (state != BossState.Die)
        {
            //Saldýrý Modu
            state = BossState.Attack;
            multiplier = 1;
            resetAllStone(true);
            yield return attackTimer;

            //Zayýf mod
            state = BossState.Weak;
            resetAllStone(false);
            multiplier = 5;
            yield return weakTimer;
        }
    }
    private void resetAllStone(bool OnOff)
    {
        for (int i = 0; i < stones.Length; i++)
        {
            var pos = stones[i].transform.localPosition;
            pos.x = 0;
            stones[i].transform.localPosition = pos;
            stones[i].gameObject.SetActive(OnOff);
        }
    }
    private void resetStone(Transform stone)
    {
        var pos = stone.localPosition;
        pos.x = 0f;
        stone.localPosition = pos;
        stone.gameObject.SetActive(true);
    }
    public void getDamage(int damage)
    {
        Health -= damage * multiplier;
    }
}

