using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMapCreator : MonoBehaviour
{
    public LevelSOTemplate mapObjects;
    public GameObject LevelS;
    GameObject thisLevel;
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            int tmpLevelCount = PlayerPrefs.GetInt("CurrentLevel");
            
            if (tmpLevelCount < mapObjects.mapPrefabs.Count)
            {
            thisLevel =   Instantiate(mapObjects.mapPrefabs[PlayerPrefs.GetInt("CurrentLevel")]);
                thisLevel.transform.SetParent(LevelS.transform);
            }
            else
            {
             thisLevel = Instantiate(mapObjects.mapPrefabs[0]);
                thisLevel.transform.SetParent(LevelS.transform);
                PlayerPrefs.SetInt("CurrentLevel", 0);
            }
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            thisLevel = Instantiate(mapObjects.mapPrefabs[0]);
            thisLevel.transform.SetParent(LevelS.transform);
        }

    } // Awake()

} // class
