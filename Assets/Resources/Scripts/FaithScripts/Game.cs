using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    //identifier
    public string saveString;
    //could be used as the display name for the saved game slot
    public string slotName;

    //the database stuff
    public JsonIndustryData jsonIndustryData;
    public JsonIndustryDemandData jsonIndustryDemandData;
    public JsonGSimulationData jsonGSimulationData;
    public JsonUSimulationData jsonUSimulationData;
    public JsonSectorData jsonSectorData;
    public JsonSituationData jsonSituationData;
    public JsonStrategicMoveData jsonStrategicMoveData;
    public JsonDilemmaData jsonDilemmaData;
    public JsonEventData jsonEventData;
    public JsonDilemmaEffectData jsonDilemmaEffectData;
    public JsonIndicatorData jsonIndicatorData;
    public JsonLocationData jsonLocationData;
    public JsonIndustryTotalData jsonIndustryTotalData;
    public JsonInfluenceListData jsonInfluenceListData;

    public Game(string saveIdentifier)
    {
        saveString = saveIdentifier;
    }
}
