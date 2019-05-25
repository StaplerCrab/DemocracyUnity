using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDatabase : MonoBehaviour
{
    //could possibly used for a UI loading bar
    public int load = 0;
    public int maxLoad = 0;

    Game game;

    void Start()
    {
        //SaveLoad.DeleteAllSaves();
        game = new Game("dbCopy");

        List<string> tableNames = TableNames.TABLE_NAMES_LIST;
        maxLoad = tableNames.Count;

        for (int i = 0; i < tableNames.Count; i++)
        {
            List<string> query = new List<string>();
            query.Add("SELECT * FROM " + tableNames[i]);

            StartCoroutine(JsonDataManager.QueryCoroutine(tableNames[i], query, Next));
        }
    }

    public void Load()
    {
        load++; 

        //all coroutines done loading
        if (load >= maxLoad)
        {
            //set current Game, then save()
            SaveLoad.currentGame = game;
            SaveLoad.Save();

            //get a copy of the Game in slot "dbCopy"
            Game loaded = SaveLoad.GetGame("dbCopy");

        }

    }

    //for getting table data
    public void Next(string table, string json)
    {
        switch (table)
        {
            case TableNames.INDUSTRY:
                JsonIndustryData id = (JsonIndustryData)JsonDataManager.FromJson(TableNames.INDUSTRY, json);
                game.jsonIndustryData = id;
                break;
            case TableNames.INDUSTRY_DEMAND:
                JsonIndustryDemandData did = (JsonIndustryDemandData)JsonDataManager.FromJson(TableNames.INDUSTRY_DEMAND, json);
                game.jsonIndustryDemandData = did;
                break;
            case TableNames.SECTOR:
                JsonSectorData sd = (JsonSectorData)JsonDataManager.FromJson(TableNames.SECTOR, json);
                game.jsonSectorData = sd;
                break;
            case TableNames.G_SIMULATION:
                JsonGSimulationData gsd = (JsonGSimulationData)JsonDataManager.FromJson(TableNames.G_SIMULATION, json);
                game.jsonGSimulationData = gsd;
                break;
            case TableNames.U_SIMULATION:
                JsonUSimulationData usd = (JsonUSimulationData)JsonDataManager.FromJson(TableNames.U_SIMULATION, json);
                game.jsonUSimulationData = usd;
                break;
            case TableNames.SITUATION:
                JsonSituationData sitd = (JsonSituationData)JsonDataManager.FromJson(TableNames.SITUATION, json);
                game.jsonSituationData = sitd;
                break;
            case TableNames.STRATEGIC_MOVE:
                JsonStrategicMoveData smd = (JsonStrategicMoveData)JsonDataManager.FromJson(TableNames.STRATEGIC_MOVE, json);
                game.jsonStrategicMoveData = smd;
                break;
            case TableNames.DILEMMA:
                JsonDilemmaData dd = (JsonDilemmaData)JsonDataManager.FromJson(TableNames.DILEMMA, json);
                game.jsonDilemmaData = dd;
                break;
            case TableNames.EVENT:
                JsonEventData ed = (JsonEventData)JsonDataManager.FromJson(TableNames.EVENT, json);
                game.jsonEventData = ed;
                break;
            case TableNames.DILEMMA_EFFECT:
                JsonDilemmaEffectData ded = (JsonDilemmaEffectData)JsonDataManager.FromJson(TableNames.DILEMMA_EFFECT, json);
                game.jsonDilemmaEffectData = ded;
                break;
            case TableNames.INDICATOR:
                JsonIndicatorData ind = (JsonIndicatorData)JsonDataManager.FromJson(TableNames.INDICATOR, json);
                game.jsonIndicatorData = ind;
                break;
            case TableNames.LOCATION:
                JsonLocationData ld = (JsonLocationData)JsonDataManager.FromJson(TableNames.LOCATION, json);
                game.jsonLocationData = ld;
                break;
            case TableNames.INDUSTRY_TOTAL:
                JsonIndustryTotalData itd = (JsonIndustryTotalData)JsonDataManager.FromJson(TableNames.INDUSTRY_TOTAL, json);
                game.jsonIndustryTotalData = itd;
                break;
            case TableNames.INFLUENCE_LIST:         
                game.jsonInfluenceListData = (JsonInfluenceListData)JsonDataManager.FromJson(TableNames.INFLUENCE_LIST, json);
                break;
            default:
                Debug.Log("Next() Table not Found: " + table);
                break;
        }

        Load();
    }
}

