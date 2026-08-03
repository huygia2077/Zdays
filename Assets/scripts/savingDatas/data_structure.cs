using System.Collections.Generic;
using UnityEngine;

// Builds data
[System.Serializable]
public class Building
{
    public string prefabID;
    public Vector2 position;
    public float rotation;
    public float damagedStat;
}


// Game stats data
[System.Serializable]
public class GameStats
{
    public float playerHealth;
    public int survivedDays;
    public int zombieKilled;
}


// Public data storage class
[System.Serializable]
public class SaveData
{
    public List<Building> savedBuildings = new List<Building>();
    public GameStats savedGameStats = new GameStats();
}