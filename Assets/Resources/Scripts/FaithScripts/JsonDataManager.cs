using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;

[System.Serializable]
public static class JsonDataManager
{ 
    //whatever the heccc the variable for the primary key in the Data class is called.
    public const string DataPrimaryKey = "id";

    static JsonDataManager()
    {
    }

    //Return value is generic JsonData so that any kind of extended class Json___Data can be returned
    public static JsonData FromJson(string table, string json)
    {
        //String table nalang (kasi obtainable thru DB sya) wag na yung TYPE shits ganun rin naman, extend options here maybe.
        //Transform from GENERIC to SPECIFIC
       // JsonData jsonData = null;

        json = RevertPrimaryKey(json, table);
        Debug.Log("getting from table..: " + table);
        try
        {

            switch (table)
            {
                case "books":
                    json = "{\"booksData\":" + json + "}";
                    JsonBookData jsonbData = JsonUtility.FromJson<JsonBookData>(json);
                    return jsonbData;
                case TableNames.INDUSTRY:
                    json = "{\"industryData\":" + json + "}";
                    JsonIndustryData jsonIndustryData = JsonUtility.FromJson<JsonIndustryData>(json);
                    return jsonIndustryData;
                case TableNames.INDUSTRY_DEMAND:
                    json = "{\"industryDemandData\":" + json + "}";
                    JsonIndustryDemandData jsonIndustryDemandData = JsonUtility.FromJson<JsonIndustryDemandData>(json);
                    return jsonIndustryDemandData;
                case TableNames.SECTOR:
                    json = "{\"sectorData\":" + json + "}";
                    JsonSectorData jsonSectorData = JsonUtility.FromJson<JsonSectorData>(json);
                    return jsonSectorData;
                case TableNames.G_SIMULATION:
                    json = "{\"gSimulationData\":" + json + "}";
                    JsonGSimulationData jsonGSimulationData = JsonUtility.FromJson<JsonGSimulationData>(json);
                    return jsonGSimulationData;
                case TableNames.U_SIMULATION:
                    json = "{\"uSimulationData\":" + json + "}";
                    JsonUSimulationData jsonUSimulationData = JsonUtility.FromJson<JsonUSimulationData>(json);
                    return jsonUSimulationData;
                case TableNames.SITUATION:
                    json = "{\"situationData\":" + json + "}";
                    JsonSituationData jsonSituationData = JsonUtility.FromJson<JsonSituationData>(json);
                    return jsonSituationData;
                case TableNames.STRATEGIC_MOVE:
                    json = "{\"strategicMoveData\":" + json + "}";
                    JsonStrategicMoveData jsonStrategicMoveData = JsonUtility.FromJson<JsonStrategicMoveData>(json);
                    return jsonStrategicMoveData;
                case TableNames.DILEMMA:
                    json = "{\"dilemmaData\":" + json + "}";
                    JsonDilemmaData jsonDilemmaData = JsonUtility.FromJson<JsonDilemmaData>(json);
                    return jsonDilemmaData;
                case TableNames.EVENT:
                    json = "{\"eventData\":" + json + "}";
                    JsonEventData jsonEventData = JsonUtility.FromJson<JsonEventData>(json);
                    return jsonEventData;
                case TableNames.DILEMMA_EFFECT:
                    json = "{\"dilemmaEffectData\":" + json + "}";
                    JsonDilemmaEffectData jsonDilemmaEffectData = JsonUtility.FromJson<JsonDilemmaEffectData>(json);
                    return jsonDilemmaEffectData;
                case TableNames.INDICATOR:
                    json = "{\"indicatorData\":" + json + "}";
                    JsonIndicatorData jsonIndicatorData = JsonUtility.FromJson<JsonIndicatorData>(json);
                    return jsonIndicatorData;
                case TableNames.LOCATION:
                    json = "{\"locationData\":" + json + "}";
                    JsonLocationData jsonLocationData = JsonUtility.FromJson<JsonLocationData>(json);
                    return jsonLocationData;
                case TableNames.INDUSTRY_TOTAL:
                    json = "{\"industryTotalData\":" + json + "}";
                    JsonIndustryTotalData jsonIndustryTotalData = JsonUtility.FromJson<JsonIndustryTotalData>(json);
                    return jsonIndustryTotalData;
                case TableNames.INFLUENCE_LIST:
                    json = "{\"influenceListData\":" + json + "}";
                    JsonInfluenceListData jsonInfluenceListData = JsonUtility.FromJson<JsonInfluenceListData>(json);
                    return jsonInfluenceListData;
                default:
                    Debug.Log("Table not Found: " + table);
                    return null;
            };
        }
        catch
        {
            Debug.Log("error during database get: " + table);
            return null;
        }

    }

    //get sum Data based on string primaryKey
    //sample code:
    //GameData gd = (GameData) JsonDataManager.GetData(gameDataList.ToList<Data>(), "0");
    //Debug.Log(gd.username);
    public static Data GetData(List<Data> dataList, string primaryKey)
    {
        for (int i = 0; i < dataList.Count; i++)
        {
            if (dataList[i].id.Equals(primaryKey))
            {
                return dataList[i];
            }

        }
        return null;
    }

    //for php purposes, since primaryKey would probably not be named "primaryKey"
    //or just use string.Replace
    //sample use: theJsonString = RevertPrimaryKey(theJsonString, "id");
    // "primaryKey" -> "id"
    public static string RenamePrimaryKey(string json, string newPrimaryKey)
    {
        json = json.Replace(DataPrimaryKey, newPrimaryKey);
        return json;
    
    }

    //for client purposes, since primaryKey would probably not be named "primaryKey"
    //or just use string.Replace
    //sample use: theJsonString = RevertPrimaryKey(theJsonString, "id");
    // "id" -> "primaryKey"
    public static string RevertPrimaryKey(string json, string table)
    {
        json = json.Replace(table + "_id", DataPrimaryKey);
        return json;
    }

    /* PENDING FIX from postgre migrate
     * 
    public static IEnumerator RecordIntoTableCoroutine(string table, string json)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("json", json));
        formData.Add(new MultipartFormDataSection("table", table));

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/ecsimwebserver/sqlconnect/record_data.php", formData);
        yield return www.SendWebRequest();

        string s = www.downloadHandler.text;

        Debug.Log("DH: " + s);
    }
    */

    public static string ToJson(object jdata, string table) 
    {
        string newJson = "";

        newJson = JsonUtility.ToJson(jdata);
        newJson = RenamePrimaryKey(newJson, table + "_id");

        return newJson;
    }

    public static string MakeSelectQuery(string table, string key, string where, string equalTo)
    {
        return ("SELECT " + key + " FROM " + table + " WHERE " + where + " = " + equalTo + ";");
    }

    public static IEnumerator QueryCoroutine(string table, List<string> queryList, Action<string, string> func)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("queryCount", queryList.Count.ToString()));

        for (int i = 0; i < queryList.Count; i++)
        {
            formData.Add(new MultipartFormDataSection("query" + i.ToString(), queryList[i]));
        }

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/ecsimwebserver/sqlconnect/pg_retrieve.php", formData);
        yield return www.SendWebRequest();

        string dh = www.downloadHandler.text; //the echoed json string

        func(table, dh);
    }

}

public static class TableNames
{
    //table names of ecsim database
    public const string INDUSTRY = "industry";
    public const string INDUSTRY_DEMAND = "industry_demand";
    public const string SECTOR = "sector";
    public const string G_SIMULATION = "g_simulation";
    public const string U_SIMULATION = "u_simulation";
    public const string SITUATION = "situation";
    public const string STRATEGIC_MOVE = "strategic_move";
    public const string EVENT = "event";
    public const string DILEMMA = "dilemma";
    public const string DILEMMA_EFFECT = "dilemma_effect";
    public const string INDICATOR = "indicator";
    public const string LOCATION = "location";
    public const string INDUSTRY_TOTAL = "industry_total";
    public const string INFLUENCE_LIST = "influence_list";

    public static readonly List<string> TABLE_NAMES_LIST = new List<string>
    {
        INDUSTRY,
        INDUSTRY_DEMAND,
        SECTOR,
        G_SIMULATION,
        U_SIMULATION,
        SITUATION,
        STRATEGIC_MOVE,
        EVENT,
        DILEMMA,
        DILEMMA_EFFECT,
        INDICATOR,
        LOCATION,
        INDUSTRY_TOTAL,
        INFLUENCE_LIST
    };
}
