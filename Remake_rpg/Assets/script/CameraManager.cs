/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/12
 * Cameraの操作に使用
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameRunner GR;
    [SerializeField] GameObject Player;
    [SerializeField] float d_movementY;
    [SerializeField] GameObject FirstFloor;
    [SerializeField] PlayerMove PM;
    private float initCameraHeight;
    private Vector2 currentPlayerPosition;
    private float currentTouchingGroundPositionY;
    private void Start()
    {
        currentPlayerPosition = Player.transform.position;
        initCameraHeight = mainCamera.transform.position.y - FirstFloor.transform.position.y;//床との初期の高さを計算
    }
    private void Update()
    {
        ChasePlayerX();
        ChacePlayerY(PM.playerTouchingGroundPositionY);
    }
    private void ChasePlayerX()
    {
        float diff = Player.transform.position.x - currentPlayerPosition.x;
        currentPlayerPosition = Player.transform.position;
        mainCamera.transform.position += new Vector3(diff,0,0);
    }
    /// <summary>
    /// プレイヤーのいるステージの高さによってカメラのY座標を変更
    /// </summary>
    public void ChacePlayerY(float touchingGroundY)
    {
        if(currentTouchingGroundPositionY != touchingGroundY)
        {
            if(currentTouchingGroundPositionY > touchingGroundY)
            {
                //低いほうに移行
                if(touchingGroundY + initCameraHeight < mainCamera.transform.position.y)
                {
                    mainCamera.transform.position -= new Vector3(0, d_movementY, 0);
                }
                else
                {
                    var pos = mainCamera.transform.position;
                    mainCamera.transform.position = new Vector3(pos.x,touchingGroundY + initCameraHeight, pos.z);
                    currentTouchingGroundPositionY = touchingGroundY;
                }
            }
            else
            {
                //高い方に移行
                if (touchingGroundY + initCameraHeight > mainCamera.transform.position.y)
                {
                    mainCamera.transform.position += new Vector3(0, d_movementY, 0);
                }
                else
                {
                    var pos = mainCamera.transform.position;
                    mainCamera.transform.position = new Vector3(pos.x, touchingGroundY + initCameraHeight, pos.z);
                    currentTouchingGroundPositionY = touchingGroundY;
                }
            }
        }
    }

}
