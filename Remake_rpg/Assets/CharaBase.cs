/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/02
 * 全キャラクターに使用。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBase : MonoBehaviour
{
    int hp;
    [SerializeField] int maxHP;
    [SerializeField] CharaKind charaKind;
    private void Start()
    {
        hp = maxHP;
    }
}
