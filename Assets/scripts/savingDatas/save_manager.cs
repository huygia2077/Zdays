using UnityEngine;
using System.IO;
using System.Collections.Generic;

// Struct data structure to store the ID of a prefab build
// This then stored in a list of build types
[System.Serializable]
public struct BuildsMapping
{
    public string ID;
    public GameObject prefabBuild;
}



public class save_manager : MonoBehaviour
{
    public BuildsMapping[] buildTypes;
    private Dictionary<string, GameObject> buildings;


    // Saved location
    private string savedPath;
    private SaveData savedDatas = new SaveData();


    void Awake()
    {
        savedPath = Path.Combine(Application.dataPath, "savedDatas");;
        buildings = new Dictionary<string, GameObject>();

        if (!Directory.Exists(savedPath))
        {
            Directory.CreateDirectory(savedPath);
        }

        // 2. THE FIX: You must combine the folder path with a file name!
        savedPath = Path.Combine(savedPath, "buildsave.json");

        // Load all the building types in game and their IDs
        foreach (BuildsMapping buildMapping in buildTypes)
        {
            if (!buildings.ContainsKey(buildMapping.ID))
            {
                buildings.Add(buildMapping.ID, buildMapping.prefabBuild);
            }
        }
    }


    // Save active builds in scene
    public void saveGame(HashSet<GameObject> activeBuilds)
    {
        // Clear the old data first before we can overite it with the new one
        savedDatas.savedBuildings.Clear();
        // savedDatas.savedGameStats = default;

        // Save the active builds in scene
        foreach (GameObject build in activeBuilds)
        {
            build_identifier identifier = build?.GetComponent<build_identifier>();
            
            if (identifier != null)
            {
                Building currentBuildData = new Building();
                currentBuildData.prefabID = identifier.ID;
                currentBuildData.position = identifier.transform.position;
                currentBuildData.rotation = identifier.transform.eulerAngles.z;
                currentBuildData.damagedStat = identifier.currentDamagedStat;
                
                // Add the saved build to Building Saved list of SaveData()
                savedDatas.savedBuildings.Add(currentBuildData);
            }
        }

        // Save the game stats
        savedDatas.savedGameStats.playerHealth = game_manager.instance.playerHealth.currentHealth;
        Debug.Log(savedDatas.savedGameStats.playerHealth);
        savedDatas.savedGameStats.survivedDays = game_manager.instance.survivedDays;
        savedDatas.savedGameStats.zombieKilled = game_manager.instance.killCounts;
        

        // Saving to JSON file
        string json = JsonUtility.ToJson(savedDatas, true);
        File.WriteAllText(savedPath, json);

        Debug.Log("Saved Successfully");
    }


    // Load the builds
    public void loadSavedGame()
    {
        if (hasLoadedDatas())
        {
            string json = File.ReadAllText(savedPath);
            savedDatas = JsonUtility.FromJson<SaveData>(json);

            // Load builds
            foreach (Building build in savedDatas.savedBuildings)
            {
                if (buildings.TryGetValue(build.prefabID, out GameObject spawnedBuild))
                {
                    Vector2 spawnPos = build.position;
                    Quaternion rotationAngle = Quaternion.Euler(0f, 0f, build.rotation);
                    GameObject obstacle = Instantiate(spawnedBuild, spawnPos, rotationAngle);
                    obstacle.GetComponent<build_identifier>().currentDamagedStat = build.damagedStat;
                    
                    game_manager.instance.addActiveBuild(obstacle);
                }
            }

            // Load Game Stats
            GameStats savedStats = savedDatas.savedGameStats;
            game_manager.instance.survivedDays = savedStats.survivedDays;
            game_manager.instance.killCounts = savedStats.zombieKilled;
            game_manager.instance.playerHealth.currentHealth = savedStats.playerHealth;

            Debug.Log("Loaded successfully");
        }
    }


    // Check if the saved file exist
    public bool hasLoadedDatas()
    {
        return File.Exists(savedPath);
    }
}
