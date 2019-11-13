/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/12
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    /// <summary>
    /// シナリオモードであるかどうか
    /// </summary>
    public bool isUtageMode
    {
        get;
        private set;
    }
}

/// <summary>
/// キャラクターの種類
/// </summary>
enum CharaKind
{
    Player,Spider,Wolf

}
