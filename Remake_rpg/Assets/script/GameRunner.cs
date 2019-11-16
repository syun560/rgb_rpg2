/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/12
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunner : MonoBehaviour
{
    float time = 0;
    public bool isGameOver = false;
    [SerializeField] GameObject gameOverText;
    /// <summary>
    /// シナリオモードであるかどうか
    /// </summary>
    public bool isUtageMode
    {
        get;
        private set;
    }
    public void StartGameOver()
    {
        isGameOver = true;
    }
    private void Update()
    {
        if (isGameOver)
        {
            time += Time.deltaTime;
            gameOverText.SetActive(true);
            if (time > 3) SceneManager.LoadScene("title");
        }
    }
}

/// <summary>
/// キャラクターの種類
/// </summary>
enum CharaKind
{
    Player,Spider,Wolf

}
