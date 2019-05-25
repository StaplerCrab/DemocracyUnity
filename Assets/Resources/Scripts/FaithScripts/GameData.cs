using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class JsonData
{
    public string dataType = "";

    public JsonData()
    {
    }

    public JsonData(string data)
    {
        dataType = data;   
    }
}

[System.Serializable]
public class JsonBookData : JsonData
{
    public List<BookData> booksData;

    public JsonBookData() : base()
    {
        dataType = "books";
        booksData = new List<BookData>();
    }
}

[System.Serializable]
public class JsonIndustryData : JsonData
{
    public List<IndustryData> industryData;

    public JsonIndustryData() : base()
    {
        dataType = TableNames.INDUSTRY;
        industryData = new List<IndustryData>();
    }
}

[System.Serializable]
public class JsonIndustryDemandData : JsonData
{
    public List<IndustryDemandData> industryDemandData;

    public JsonIndustryDemandData() : base()
    {
        dataType = TableNames.INDUSTRY_DEMAND;
        industryDemandData = new List<IndustryDemandData>();
    }

}

[System.Serializable]
public class JsonSectorData : JsonData
{
    public List<SectorData> sectorData;

    public JsonSectorData() : base()
    {
        dataType = TableNames.SECTOR;
        sectorData = new List<SectorData>();
    }
}

[System.Serializable]
public class JsonGSimulationData : JsonData
{
    public List<GSimulationData> gSimulationData;

    public JsonGSimulationData() : base()
    {
        dataType = TableNames.G_SIMULATION;
        gSimulationData = new List<GSimulationData>();
    }
}

[System.Serializable]
public class JsonUSimulationData : JsonData
{
    public List<USimulationData> uSimulationData;

    public JsonUSimulationData() : base()
    {
        dataType = TableNames.U_SIMULATION;
        uSimulationData = new List<USimulationData>();
    }
}

[System.Serializable]
public class JsonSituationData : JsonData
{
    public List<SituationData> situationData;

    public JsonSituationData() : base()
    {
        dataType = TableNames.SITUATION;
        situationData = new List<SituationData>();
    }
}

[System.Serializable]
public class JsonStrategicMoveData : JsonData
{
    public List<StrategicMoveData> strategicMoveData;

    public JsonStrategicMoveData() : base()
    {
        dataType = TableNames.STRATEGIC_MOVE;
        strategicMoveData = new List<StrategicMoveData>();
    }
}

[System.Serializable]
public class JsonDilemmaData : JsonData
{
    public List<DilemmaData> dilemmaData;

    public JsonDilemmaData() : base()
    {
        dataType = TableNames.DILEMMA;
        dilemmaData = new List<DilemmaData>();
    }
}

[System.Serializable]
public class JsonEventData : JsonData
{
    public List<EventData> eventData;

    public JsonEventData() : base()
    {
        dataType = TableNames.EVENT;
        eventData = new List<EventData>();
    }
}

[System.Serializable]
public class JsonDilemmaEffectData : JsonData
{
    public List<DilemmaEffectData> dilemmaEffectData;

    public JsonDilemmaEffectData() : base()
    {
        dataType = TableNames.DILEMMA_EFFECT;
        dilemmaEffectData = new List<DilemmaEffectData>();
    }
}

[System.Serializable]
public class JsonIndicatorData : JsonData
{
    public List<IndicatorData> indicatorData;

    public JsonIndicatorData() : base()
    {
        dataType = TableNames.INDICATOR;
        indicatorData = new List<IndicatorData>();
    }
}

[System.Serializable]
public class JsonLocationData : JsonData
{
    public List<LocationData> locationData;

    public JsonLocationData() : base()
    {
        dataType = TableNames.LOCATION;
        locationData = new List<LocationData>();
    }
}

[System.Serializable]
public class JsonIndustryTotalData : JsonData
{
    public List<IndustryTotalData> industryTotalData;

    public JsonIndustryTotalData() : base()
    {
        dataType = TableNames.INDUSTRY_TOTAL;
        industryTotalData = new List<IndustryTotalData>();
    }

}

[System.Serializable]
public class JsonInfluenceListData : JsonData
{
    public List<InfluenceListData> influenceListData;

    public JsonInfluenceListData() : base()
    {
        dataType = TableNames.INFLUENCE_LIST;
        influenceListData = new List<InfluenceListData>();
    }

}

//DATA these gotta be exact same name as the columns in the database. ////////////////////////////
[System.Serializable]
public class Data
{
    public string id = "0";
}

[System.Serializable]
public class BookData : Data
{
    public string title;
    public string author;
    public int year_published;
}

[System.Serializable]
public class IndustryData : Data
{
    public string name;
}

[System.Serializable]
public class IndustryDemandData : Data
{
    public int industry;
    public int input_industry;
    public int units;
}

[System.Serializable]
public class SectorData : Data
{
    public string name;
}

[System.Serializable]
public class GSimulationData : Data
{
    public string name;
    public string description;
    public int sector_id;
}

[System.Serializable]
public class USimulationData : Data
{
    public string name;
    public string description;
    public int sector_id;
}

[System.Serializable]
public class SituationData : Data
{
    public string name;
    public string description;
    public int simulation_id;
    public string sim_type;
    public float start_trigger_mult;
    public float end_trigger_mult;
}

[System.Serializable]
public class StrategicMoveData : Data
{
    public string name;
    public string description;
    public int sector_id;
    public int implement_time;
    public int budget_cost;
}
[System.Serializable]
public class DilemmaData : Data
{
    public string name;
    public string choice_A;
    public string choice_B;
    public int duration;
    public string description;
}

[System.Serializable]
public class EventData : Data
{
    public string name;
    public string description;
    public int duration;
    public float intial_chance;

}

[System.Serializable]
public class DilemmaEffectData : Data
{
    public int dilemma_id;
    public int choice_num;
    public int indicator_type_dest;
    public float threshold;
    public string is_thresh_plus;
    public float multiplier;
    public string is_mult_plus;
    public string indicator_name_dest;

}

[System.Serializable]
public class IndicatorData : Data
{
    public string name;
}

[System.Serializable]
public class LocationData : Data
{
    public string name;
    public string description;
    public string location_image;
}

[System.Serializable]
public class IndustryTotalData : Data
{
    public int industry_id;
    public float ce;
    public float depn;
    public float its;
    public float os;
}

[System.Serializable]
public class InfluenceListData : Data
{
    public int event_id;
    public int dilemma_id;
    public int indicator_id;
    public string indicator_name;
    public float threshold;
    public string is_thresh_plus;
    public float multiplier;
    public string is_mult_plus;
}






