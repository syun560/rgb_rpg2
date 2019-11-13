using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGauge : MonoBehaviour
{
    [SerializeField] CharaBase playerCharaBase;
    [SerializeField] List<GameObject> lifeGauges;
    private int currentHp = 0;
    private void Update()
    {
        if (currentHp != playerCharaBase.hp) ChangeGauge(playerCharaBase.hp); 
    }
    private void ChangeGauge(int hp)
    {
        currentHp = hp;
        for(int i = 0;i<lifeGauges.Count;i++)
        {
            lifeGauges[i].SetActive(i < hp);//0からhp-1番目までtrueで表示。それ以降falseで非表示
        }
    }
}
