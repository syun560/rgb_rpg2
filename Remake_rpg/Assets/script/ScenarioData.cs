/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/16
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioData
{
    public string charaName
    {
        get;
        private set;
    }
    public string scenario
    {
        get;
        private set;
    }
    public float startDelayTime;
    public float scenarioTime;
    public ScenarioData(string name,string scenario,float startDelayTime,float scenarioTime)
    {
        charaName = name;
        this.scenario = scenario;
        this.startDelayTime = startDelayTime;
        this.scenarioTime = scenarioTime;
    }
}
