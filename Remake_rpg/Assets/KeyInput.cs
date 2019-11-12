/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/02
 * Key入力統括
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour
{
    public bool input_RightMove
    {
        get
        {
            return CheckKey(RightMove_KeyCodes);
        }
    }
    private KeyCode[] RightMove_KeyCodes = { KeyCode.D, KeyCode.RightArrow };
    public bool input_LeftMove
    {
        get
        {
            return CheckKey(LeftMove_KeyCodes);
        }
    }
    private KeyCode[] LeftMove_KeyCodes = { KeyCode.A, KeyCode.LeftArrow };
    public bool input_FowardMove
    {
        get
        {
            return CheckKey(FowardMove_KeyCodes);
        }
    }
    private KeyCode[] FowardMove_KeyCodes = { KeyCode.W, KeyCode.UpArrow };
    public bool input_Jump
    {
        get
        {
            return CheckKey(Jump_KeyCodes);
        }
    }
    private KeyCode[] Jump_KeyCodes = { KeyCode.Space};

    public bool input_LeftMouseDown
    {
        get
        {
            return Input.GetMouseButtonDown(0);
        }
    }
    /// <summary>
    /// キーの中で一つでも当てはまるキーがある場合、trueを返す
    /// </summary>
    /// <param name="keys">検査するキー</param>
    /// <returns></returns>
    private bool CheckKey(KeyCode[] keys)
    {
        foreach (KeyCode k in keys)
        {
            if (Input.GetKey(k)) return true;
        }
        return false;
    }
}
