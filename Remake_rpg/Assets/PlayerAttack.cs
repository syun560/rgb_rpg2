﻿/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/13
 * プレイヤーの攻撃処理
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] VisualBase VB;
    [SerializeField] KeyInput keyInput;
    private CharaBase touchingEnemyCharaBase;
    private Collision2D touchingEnemyCollison;
    [SerializeField] int attackPower;
    [SerializeField] float maxAttackDelayTime;
    private float attackDelayTime = 0;
    private bool isAttacking = false;
    private void Update()
    {

        if (keyInput.input_LeftMouseDown)
        {
            VB.StartAttackingMotion();
            isAttacking = true;
        }
        if (isAttacking) WaitingAttack();

    }
    private void WaitingAttack()
    {
        attackDelayTime += Time.deltaTime;
        if (maxAttackDelayTime < attackDelayTime)
        {
            if(touchingEnemyCharaBase != null)
            {
                touchingEnemyCharaBase.OnDamage(attackPower);
            }
            attackDelayTime = 0;
            isAttacking = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            touchingEnemyCharaBase = collision.gameObject.GetComponent<CharaBase>();
            touchingEnemyCollison = collision;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision == touchingEnemyCollison)
        {
            touchingEnemyCollison = null;
            touchingEnemyCharaBase = null;
        }
    }

}
public enum PlayerAttackColor
{
    R,G,B
}