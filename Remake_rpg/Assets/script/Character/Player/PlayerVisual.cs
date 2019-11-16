/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/13
 * プレイヤーのSprite を管理する
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] List<Sprite> walking_R;
    [SerializeField] List<Sprite> walking_G;
    [SerializeField] List<Sprite> walking_B;
    [SerializeField] List<Sprite> attacking_R;
    [SerializeField] List<Sprite> attacking_G;
    [SerializeField] List<Sprite> attacking_B;
    [SerializeField] VisualBase VB;
    Dictionary<PlayerAttackColor, List<Sprite>> walking_RGB;
    Dictionary<PlayerAttackColor, List<Sprite>> attacking_RGB;
    void Start()
    {
        walking_RGB = new Dictionary<PlayerAttackColor, List<Sprite>>();
        walking_RGB[PlayerAttackColor.R] = walking_R;
        walking_RGB[PlayerAttackColor.G] = walking_G;
        walking_RGB[PlayerAttackColor.B] = walking_B;
        attacking_RGB = new Dictionary<PlayerAttackColor, List<Sprite>>();
        attacking_RGB[PlayerAttackColor.R] = attacking_R;
        attacking_RGB[PlayerAttackColor.G] = attacking_G;
        attacking_RGB[PlayerAttackColor.B] = attacking_B;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R)) SetAdaptedColorImage(PlayerAttackColor.R);
        if (Input.GetKey(KeyCode.G)) SetAdaptedColorImage(PlayerAttackColor.G);
        if (Input.GetKey(KeyCode.B)) SetAdaptedColorImage(PlayerAttackColor.B);
    }
    public void SetAdaptedColorImage(PlayerAttackColor PAC)
    {
        VB.SetCharaWalkinImage(walking_RGB[PAC]);
        VB.SetCharaAttackingImage(attacking_RGB[PAC]);
    }
}
