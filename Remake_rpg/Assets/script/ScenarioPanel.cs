/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/16
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioPanel : MonoBehaviour
{
    [SerializeField] Text scenarioText;
    [SerializeField] Text nameText;
    private List<ScenarioData> scenarioDatas = new List<ScenarioData>();
    private int scenarioIndex = 0;
    private float startDelayTime = 0;
    private bool isEndPlaying = true;
    private bool isShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEndPlaying) PlayScenario();
        
    }

    private void PlayScenario()
    {
        scenarioDatas[scenarioIndex].startDelayTime -= Time.deltaTime;
        if (scenarioDatas[scenarioIndex].startDelayTime < 0 && !isShowing)
        {
            //表示開始
            scenarioText.text = scenarioDatas[scenarioIndex].scenario;
            nameText.text = scenarioDatas[scenarioIndex].charaName;
            isShowing = true;
        }
        if (isShowing)
        {
            //表示中
            scenarioDatas[scenarioIndex].scenarioTime -= Time.deltaTime;
        }
        if (isShowing && scenarioDatas[scenarioIndex].scenarioTime < 0)
        {
            isShowing = false;
            scenarioText.text = "";
            nameText.text = "";
            if (scenarioDatas.Count - 1 > scenarioIndex)
            {
                //まだシナリオがある
                scenarioIndex++;
            }
            else
            {
                //現状もうシナリオはない
                isEndPlaying = true;
            }
        }
    }
    

    public void SetNewScenario(ScenarioData sd)
    {
        scenarioDatas.Add(sd);
        isEndPlaying = false;
    }
}
