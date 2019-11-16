/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/13
 * 図形描画処理
 * 製作者(続き):松本陸(AL18108)
 * 製作日:2019/11/13
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DrawFigure : MonoBehaviour
{
    public GameObject PointsforDebugPreafab;
    public GameObject pointedPlaceDebugPrefab;
    List<Vector2> Points;
    [SerializeField] KeyInput keyInput;
    [SerializeField] float d_length = 4;
    ///<summary>
    /// どれくらい離れて入れば別の角とするか
    ///</summay>
    [SerializeField] float duplicateCheck = 8;
    /// <summary>
    /// 尖った場所と認識する閾値。単位は弧度法
    /// </summary>
    [SerializeField] float maxAngle = 140;
    ///<summary>
    ///デバグモードか否か
    ///Points,後に宣言されていいるpointedPlaceに対応する点を描画+描画後一時停止
    ///</summary>
    [SerializeField] bool DebugFlag = false;
    bool isDrawing = false;
    [SerializeField] GameObject maru_pref;
    [SerializeField] GameObject shikaku_pref;
    [SerializeField] GameObject sankaku_pref;
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
        else if (!isDrawing)
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
        if (Points != null & Points.Count > 1)
        {
            length = Vector2.Distance(Points[Points.Count - 1], mousePos);
        }
        else
        {
            Points.Add(mousePos);
        }
        if (length > d_length)
        {
            Points.Add(mousePos);
        }
    }

    private void GenerateFigure()
    {
        if (Points.Count > 4)
        {
            List<Vector2> pointedPlace = new List<Vector2>();//閾値以上に尖った場所
            for (int i = 1; i < Points.Count - 1; ++i)
            {
                Vector2 vec0 = Points[i - 1] - Points[i];
                Vector2 vec1 = Points[i + 1] - Points[i];
                float angle = Vector2.Angle(vec0, vec1);//に直線間の角度を計算
                if (angle < maxAngle)
                {
                    pointedPlace.Add(Points[i]);
                }
            }
            DeleteDuplicated(pointedPlace);

            if (DebugFlag) VisualizePoints(pointedPlace, Points);

            if (pointedPlace.Count == 3)
            {
                //サン脚気い
                Debug.Log("三角形");
                GenerateSankaku(pointedPlace);
            }
            if (pointedPlace.Count == 4)
            {
                //四角形
                Debug.Log("四角形");
                GenerateShikaku(pointedPlace);
            }
            if (pointedPlace.Count > 4 || pointedPlace.Count < 3)
            {
                //円
                Debug.Log("円");
                GenerateMaru(pointedPlace);
            }
            Debug.Log(Points.Count);
        }


        isDrawing = false;
    }

//pointedPraceとPointsを可視化して一時停止
    private void VisualizePoints(List<Vector2> pPlaces, List<Vector2> Points)
    {
        List<GameObject> PointsforDebug = new List<GameObject>();
        for (int i = 0; i < Points.Count; ++i)
        {
            PointsforDebug.Add(Instantiate(PointsforDebugPreafab) as GameObject);
            Vector3 temp = Camera.main.ScreenToWorldPoint(Points[i]);
            //PointsforDebug[i].transfrom.position = temp;
        }
        List<GameObject> pointedPlaceDebug = new List<GameObject>();
        for (int i = 0; i < pPlaces.Count; ++i)
        {
            pointedPlaceDebug.Add(Instantiate(pointedPlaceDebugPrefab) as GameObject);
            Vector3 temp = Camera.main.ScreenToWorldPoint(pPlaces[i]);
            pointedPlaceDebug[i].transform.position = temp;
        }
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPaused = true;
#endif
    }

    //pointedPlace同士があまりにも近くなるようなら削除する
    private void DeleteDuplicated(List<Vector2> pPlaces)
    {
        for (int i = 0; i < pPlaces.Count; ++i)
        {
            for (int j = 0; j < pPlaces.Count; ++j)
            {
                if (i == j) continue;
                if ((pPlaces[i] - pPlaces[j]).magnitude < duplicateCheck)
                    pPlaces.RemoveAt(j);
            }
        }
    }
    /// <summary>
    /// 要素点群から中心位置を求める
    /// </summary>
    /// <param name="points">要素点群</param>
    /// <returns></returns>
    private Vector2 CalcCenterPosition(List<Vector2> points)
    {
        Vector2 rtn=new Vector2();
        foreach(Vector2 p in points) rtn += p;
        return rtn/points.Count;
    }

    private void GenerateMaru(List<Vector2> pointedPlace)
    {
        var maru = Instantiate(maru_pref);
        maru.transform.position = Camera.main.ScreenToWorldPoint(CalcCenterPosition(pointedPlace));
        maru.transform.position = new Vector3(maru.transform.position.x, maru.transform.position.y, 0);
    }

    private void GenerateShikaku(List<Vector2> pointedPlace)
    {
        var maru = Instantiate(shikaku_pref);
        maru.transform.position = Camera.main.ScreenToWorldPoint(CalcCenterPosition(pointedPlace));
        maru.transform.position = new Vector3(maru.transform.position.x, maru.transform.position.y, 0);
    }

    private void GenerateSankaku(List<Vector2> pointedPlace)
    {
        var maru = Instantiate(sankaku_pref);
        maru.transform.position = Camera.main.ScreenToWorldPoint(CalcCenterPosition(pointedPlace));
        maru.transform.position = new Vector3(maru.transform.position.x, maru.transform.position.y, 0);
    }

}