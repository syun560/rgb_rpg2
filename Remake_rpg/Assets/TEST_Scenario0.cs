using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST_Scenario0 : MonoBehaviour
{
    [SerializeField] ScenarioPanel SP;
    [SerializeField] List<ScenarioData> sd = new List<ScenarioData>();
    [SerializeField] Transform player;
    [SerializeField] CharaBase playerCharaBase;
    [SerializeField] VisualBase playerVisualBase;
    [SerializeField] PlayerVisual playerVisual;
    float time = 0;
    bool flag_givePen = false;
    bool flag_draw = false;
    bool flag_nagiExit = false;
    // Start is called before the first frame update
    void Start()
    {
        SP.SetNewScenario(new ScenarioData("絵里", "アリスとはぐれちゃった……。ここはどこだろう？", 1f, 3));
        SP.SetNewScenario(new ScenarioData("製作者", "ヤッホー！エリ！", 0.6f, 1));
        SP.SetNewScenario(new ScenarioData("製作者", "私はこのゲームの製作者の一人だよ！", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "早速だけどこれをプレゼント！", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("絵里", "何これ？筆？", 0.3f, 3));
        SP.SetNewScenario(new ScenarioData("製作者", "そうそう！この筆でこの世界をめいいっぱい楽しんでね！", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "まず←→キーかA,Dキーで移動ができるよ", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "ジャンプはスペース、ジャンプ中も移動できるよ", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "筆を振るのはマウスクリック！これで邪魔な奴はやっつけよう！", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "じゃあ最後に図形を書いてみよう。", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "この世界では書いた図形を使うことができるよ", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "図形を書くにはShiftキーを押し、マウスクリックしながら", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "作りたい図形を描けばできるよ。", 0.1f, 2));
        SP.SetNewScenario(new ScenarioData("製作者", "試しにやってみよう", 0.1f, 2));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>7.8 && !flag_givePen)
        {
            playerVisual.SetAdaptedColorImage(PlayerAttackColor.R);
            flag_givePen = true;
        }
        if (!flag_draw && GameObject.FindGameObjectsWithTag("Figure").Length > 0)
        {
            SP.SetNewScenario(new ScenarioData("製作者", "そうそう！そんな感じ！", 0.1f, 2));
            SP.SetNewScenario(new ScenarioData("製作者", "じゃあ僕はこれで失礼するよ", 1f, 2));
            time = 0;
            flag_draw = true;
        }
        if (time > 5 && flag_draw)
        {
            //シーン遷移
            SceneManager.LoadScene("Taikenban1");
        }
    }
}
