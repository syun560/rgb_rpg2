using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST_Scenario : MonoBehaviour
{
    [SerializeField] ScenarioPanel SP;
    [SerializeField] List<ScenarioData> sd = new List<ScenarioData>();
    [SerializeField] Transform player;
    bool flag_nearSwitch = false;
    bool flag_nearWolf = false;
    bool flag_killWolf = false;
    // Start is called before the first frame update
    void Start()
    {
        /*
        SP.SetNewScenario(new ScenarioData("絵里","おっぱい",0.3f,2));
        SP.SetNewScenario(new ScenarioData("絵里", "ぷるぷる", 0.3f, 2));
        SP.SetNewScenario(new ScenarioData("絵里", "ｯｧｱｰｰｰｰ!!!!!!", 0.6f, 3));
        */
        SP.SetNewScenario(new ScenarioData("", "", 0f, 3));
    }

    // Update is called once per frame
    void Update()
    {
        if (!flag_nearSwitch&&player.position.x > 37)
        {
            SP.SetNewScenario(new ScenarioData("絵里", "これはスイッチなのかな", 0.3f, 3));
            flag_nearSwitch = true;
        }
        if (!flag_nearWolf && player.position.x > 82)
        {
            SP.SetNewScenario(new ScenarioData("アリス", "あそこにいるのって狼かな？", 0.1f, 2));
            SP.SetNewScenario(new ScenarioData("アリス", "でもあんな真っ黒な狼見たことない……", 0.1f, 3));
            SP.SetNewScenario(new ScenarioData("オオカミ", "グルルルル！", 0.4f, 1));
            SP.SetNewScenario(new ScenarioData("アリス", "…！まずい、気づかれたみたい…！逃げなきゃ！", 0.2f, 3));
            SP.SetNewScenario(new ScenarioData("絵里", "…だめ、逃げ切れない！", 0.3f, 2));
            flag_nearWolf = true;
        }
        if(!flag_killWolf&&GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            
            flag_killWolf = true;
            //シーン遷移（ムービー）
            SceneManager.LoadScene("Taikenban2");
        }
    }
}
