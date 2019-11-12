/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/13
 * 図形描画処理
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFigure : MonoBehaviour
{
    List<Vector2> Points;
    [SerializeField] KeyInput keyInput;
    [SerializeField] float d_length;
    /// <summary>
    /// 尖った場所と認識する閾値。単位は弧度法
    /// </summary>
    [SerializeField] float maxAngle;
    bool isDrawing = false;
    private void Start()
    {
        Points = new List<Vector2>();
    }
    private void Update()
    {
        if (keyInput.input_Drawing)
        {
            AddPoints();
        }
        else if(!isDrawing)
        {
            Points = new List<Vector2>();
        }
        else
        {
            GenerateFigure();
        }
    }
    private void AddPoints()
    {
        isDrawing = true;
        Vector2 mousePos = Input.mousePosition;
        float length = 0;
        if (Points != null&Points.Count>1)
        {
            length = Vector2.Distance(Points[Points.Count - 1], mousePos);
        }
        else
        {
            Points.Add(mousePos);
        }
        if( length > d_length)
        {
            Points.Add(mousePos);
        }
    }
    private void GenerateFigure()
    {
        if(Points.Count > 4)
        {
            List<Vector2> pointedPlace = new List<Vector2>();//閾値以上に尖った場所
            for(int i = 1;i<Points.Count - 1; ++i)
            {
                Vector2 vec0 = Points[i - 1] - Points[i];
                Vector2 vec1 = Points[i] - Points[i + 1];
                float angle = Vector2.Angle(vec0, vec1);//に直線間の角度を計算
                if(angle > maxAngle)
                {
                    pointedPlace.Add(Points[i]);
                }
            }
            if(pointedPlace.Count == 3)
            {
                //サン脚気い
                Debug.Log("三角形");
            }
            if(pointedPlace.Count == 4)
            {
                //四角形
                Debug.Log("四角形");
            }
            if(pointedPlace.Count > 4||pointedPlace.Count<3)
            {
                //円
                Debug.Log("円");
            }

        }


        isDrawing = false;
    }
}
