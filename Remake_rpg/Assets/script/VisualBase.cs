/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/12
 * 全キャラクターに使用。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBase : MonoBehaviour
{
    [SerializeField] List<Sprite> charaWalkingImage;
    private int charaWalkingImageIndex = 0;
    [SerializeField] List<Sprite> charaAttackingImage;
    private int charaAttackingImageIndex = -1;//-1の時にはAttackingじゃないとき
    private float attackingTime = 0;
    [SerializeField] float maxAttackingTime;//攻撃時のスプライト変更時間閾値
    public bool flag_AutoChangeWalkingImage = true;
    public float Max_d_movement;//変更閾値
    [SerializeField] SpriteRenderer SR;
    private float d_movement;//移動量
    private Vector2 current_position;//1Update前の位置を保存
    void Update()
    {
        if (flag_AutoChangeWalkingImage) AutoChangeWalkingImage();//
        if (charaAttackingImageIndex != -1) ChangeAttackingImage();
    }
    /// <summary>
    /// 移動量に対してcharaWalkingImageの画像を順番にキャラクターに適用する
    /// </summary>
    private void AutoChangeWalkingImage()
    {
        d_movement += Vector2.Distance(transform.position, current_position);//移動量を保存
        current_position = transform.position;
        if (d_movement > Max_d_movement)
        {
            d_movement = 0;
            ++charaWalkingImageIndex;
            if (charaWalkingImageIndex == charaWalkingImage.Count) charaWalkingImageIndex = 0;
            SR.sprite = charaWalkingImage[charaWalkingImageIndex];
        }
    }
    /// <summary>
    /// 攻撃のモーション開始をしたいときに呼び出す
    /// </summary>
    public void StartAttackingMotion()
    {
        charaAttackingImageIndex = 0;
        flag_AutoChangeWalkingImage = false;
    }
    /// <summary>
    /// 一定時間(maxAttackingTime)ごとにスプライトを変更して攻撃のモーションをする
    /// </summary>
    private void ChangeAttackingImage()
    {
        attackingTime += Time.deltaTime;
        if (attackingTime > maxAttackingTime)
        {
            attackingTime = 0;
            if (charaAttackingImageIndex == charaWalkingImage.Count)
            {
                charaAttackingImageIndex = -1;
                flag_AutoChangeWalkingImage = true;
            }
            else
            {
                SR.sprite = charaAttackingImage[charaAttackingImageIndex];
                ++charaAttackingImageIndex;
            }
        }
    }
    /// <summary>
    /// (非推奨)キャラクターのスプライトを直接指定(基本使用しないと)
    /// </summary>
    /// <param name="s"></param>
    public void SetCharaSprite(Sprite s)
    {
        SR.sprite = s;
    }
    /// <summary>
    /// キャラクターの歩行時のスプライトを変更
    /// </summary>
    /// <param name="SpriteList">変更するスプライト</param>
    public void SetCharaWalkinImage(List<Sprite> SpriteList)
    {
        charaWalkingImage = SpriteList;
        SR.sprite = charaWalkingImage[charaWalkingImageIndex];
    }
    /// <summary>
    /// キャラクターの攻撃時のスプライトを変更
    /// </summary>
    /// <param name="SpriteList">変更するスプライト</param>
    public void SetCharaAttackingImage(List<Sprite> SpriteList)
    {
        charaAttackingImage = SpriteList;
    }
}