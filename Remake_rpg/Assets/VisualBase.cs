/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/02
 * 全キャラクターに使用。
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualBase : MonoBehaviour
{
    [SerializeField] List<Sprite> charaWalkingImage;
    private int charaWalkingImageIndex=0;
    public bool flag_AutoChangeWalkingImage = true;
    public float Max_d_movement;//変更閾値
    [SerializeField] SpriteRenderer SR;
    private float d_movement;//移動量
    private Vector2 current_position;//1Update前の位置を保存
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag_AutoChangeWalkingImage) AutoChangeWalkingImage();//

    }
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
}