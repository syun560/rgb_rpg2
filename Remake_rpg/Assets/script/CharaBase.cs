/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/12
 * 全キャラクターに使用。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBase : MonoBehaviour
{
    public int hp
    {
        get;
        private set;
    }
    [SerializeField] int maxHP;
    [SerializeField] CharaKind charaKind;
    [SerializeField] VisualBase VB;
    private void Start()
    {
        hp = maxHP;
    }
    public void OnDamage(int attackPower)
    {
        hp -= attackPower;
        VB.StartDamagedMotion();
        if(hp <= 0)Destroy(gameObject);
    }
}
