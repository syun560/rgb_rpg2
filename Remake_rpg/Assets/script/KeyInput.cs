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
            return Input.GetMouseButtonUp(0)&& !isDrawing;
        }
    }
    bool isDrawing = false;
    float L_MouseBtnClickTime = 0;
    [SerializeField] float max_L_MouseBtnClickTime;

    public bool input_Drawing
    {
        get
        {
            return Input.GetMouseButton(0) && CheckKey(Drawing_SubKeyCodes);
        }
    }
    private KeyCode[] Drawing_SubKeyCodes = { KeyCode.LeftShift, KeyCode.RightShift };
    private void Update()
    {
        //L_MouseBtnClick();
    }

    private void L_MouseBtnClick()
    {
        if (Input.GetMouseButton(0))
        {
            L_MouseBtnClickTime += Time.deltaTime;
            if(L_MouseBtnClickTime > max_L_MouseBtnClickTime)
            {
                isDrawing = true;
            }
        }
        else
        {
            L_MouseBtnClickTime = 0;
            isDrawing = false;
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
