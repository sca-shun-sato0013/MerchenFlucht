
[System.Serializable]
public class ScenarioState
{
    public ScenarioScenePeter scenarioScenePeter;
    public ScenarioSceneHansel scenarioSceneHansel;
    public ScenarioSceneLittle scenarioSceneLittle;
    
    //ピーターパン
    public bool happyEnd = false;
    public bool trueEnd = false;
    //ヘンゼルとグレーテル
    public bool happyEndHansel = false;
    public bool trueEndHansel = false;
    //赤ずきん
    public bool happyEndLittle = false;
    public bool trueEndLittle = false;
}
