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
    private Vector2 currentPlayerPosition;
    private void Start()
    {
        currentPlayerPosition = Player.transform.position;
    }
    private void Update()
    {
        ChasePlayer();
    }
    private void ChasePlayer()
    {
        float diff = Player.transform.position.x - currentPlayerPosition.x;
        currentPlayerPosition = Player.transform.position;
        mainCamera.transform.position += new Vector3(diff,0,0);
    }
}
