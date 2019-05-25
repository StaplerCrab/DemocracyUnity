using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934

public static class SaveLoad
{
    public static List<Game> savedGames = new List<Game>();
    public static Game currentGame;

    //save current game
    public static void Save()
    {
        Load();

        Game toSave = currentGame;
        bool gameFound = false;

        for (int i = 0; i < savedGames.Count; i++)
        {
            if (savedGames[i].saveString.Equals(toSave.saveString))
            {
                savedGames[i] = toSave;
                Debug.Log("saved to slot: " + toSave.saveString + "\nsavedGames count: " + savedGames.Count);
                gameFound = true;
                break;

            }
        }

        if (!gameFound)
        {
            savedGames.Add(currentGame);
            Debug.Log("saved to NEW slot: " + toSave.saveString + "\nsavedGames count: " + savedGames.Count);
        }

        SaveList();
    }

    //save current game to slot
    public static void SaveToSlot(string identifier)
    {
        Load();

        Game toSave = currentGame;
        bool gameFound = false;

        for (int i = 0; i < savedGames.Count; i++)
        {
            if (savedGames[i].saveString.Equals(identifier))
            {
                savedGames[i] = toSave;
                Debug.Log("saved to slot, overwrote: " + identifier + "\nsavedGames count: " + savedGames.Count);
                gameFound = true;
                break;

            }
        }

        if (!gameFound)
        {
            Debug.Log("slot not found. saved to NEW slot: " + identifier + "\nsavedGames count: " + savedGames.Count);
            savedGames.Add(currentGame);
        }

        SaveList();   
    }

    //load savedgames list
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.ecsim"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.ecsim", FileMode.Open);
            SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }
    }

    public static void DeleteAllSaves()
    {
        savedGames.Clear();
        SaveList();
    }

    public static void DeleteSave(string identifier)
    {
        for (int i = 0; i < savedGames.Count; i++)
        {
            if (savedGames[i].saveString.Equals(identifier))
            {

                Debug.Log("deleted save: " + savedGames[i].saveString);
                savedGames.Remove(savedGames[i]);
                break;

            }
        }
    }


    private static void SaveList()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.ecsim");
        bf.Serialize(file, SaveLoad.savedGames);
        file.Close();
    }

    //get game via identifier. make sure the savedgameslist is loaded somewhere at least once.
    public static Game GetGame(string identifier)
    {
        for (int i = 0; i < savedGames.Count; i++)
        {
            if (savedGames[i].saveString.Equals(identifier))
            {

                return savedGames[i];
            }
        }

        Debug.Log("save gamed not found, returned null: " + identifier);
        return null;
    }
}
