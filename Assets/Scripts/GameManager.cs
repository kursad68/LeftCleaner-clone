using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    private GameObject Homes;
    public LevelSOTemplate mapObjects;
    [SerializeField]
    private GameObject AllLevels;
    List<GameObject> HomeLevels=new List<GameObject>();
    private GameObject thisLevel;
    CharacterMovement cM;
    UIManager getUı;
   [SerializeField]
    private GameObject Canvas;
    private int ThisHomeSize,MaxHomeSize;
    public int ThisLevel,MaxLevel;
    public int deadTime,maxDeadTime;
    bool isfinish;
    void Start()
    {
        Canvas.SetActive(false);
        cM = EventManager.onCharacterScript.Invoke();
        ThisHomeSize = 0;ThisLevel = 0;
        Homes = AllLevels.transform.GetChild(0).GetChild(0).gameObject;
        Debug.Log(PlayerPrefs.GetInt("CurrentLevel") + mapObjects.mapPrefabs[PlayerPrefs.GetInt("CurrentLevel")].name+Homes.name);
        for (int i = 0; i < Homes.transform.childCount; i++)
        {
           
            HomeLevels.Add(Homes.transform.GetChild(i).gameObject);

           
        }
        
        MaxHomeSize=  Homes.transform.childCount;
        thisLevel = HomeLevels[ThisHomeSize];
        StartCoroutine(endTimeStart());
        getUı = EventManager.GetUIManager.Invoke();
    }
    IEnumerator endTimeStart()
    {
        yield return new WaitForSeconds(1f);
        deadTime--;
        if (deadTime <= 0)
        {
            deadTime = 0;
        }
        StartCoroutine(endTimeStart());
    }
    private void LevelFailed()
    {
        Canvas.SetActive(true);
    }
    private void HomesAddList()
    {
        HomeLevels.Clear();

        for (int i = 0; i < Homes.transform.childCount; i++)
        {

            HomeLevels.Add(Homes.transform.GetChild(i).gameObject);


        }

    }
    void SetPlayerPrefSettings()
    {
        if (isfinish)
        {
            int tmpCurr = PlayerPrefs.GetInt("CurrentLevel");
            tmpCurr++;
            PlayerPrefs.SetInt("CurrentLevel", tmpCurr);
            Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));

        }
    }

    void Update()
    {
        leafControl();
   
    }

    private void leafControl()
    {
        
        if (thisLevel.transform.GetChild(0).childCount <= 1)
        {
            if (ThisHomeSize < MaxHomeSize-1 )
            {
                ThisHomeSize++;
                Debug.Log("leaf1"+ThisHomeSize);
                thisLevel = HomeLevels[ThisHomeSize];
                Debug.Log("leaf2");

                openkHome();

            }
            else
            {
                if (cM.BarbageBoxSize == 0&& isfinish==false)
                {


                    isfinish = true;
                    SetPlayerPrefSettings();
                    LevelFailed();

                }
            }
    

            deadTime += 10;
            if (deadTime > maxDeadTime)
                deadTime = maxDeadTime;
        }
    }
    private void openkHome()
    {
        for (int j = 0; j < thisLevel.transform.childCount; j++)
        {
            if (thisLevel.transform.GetChild(j).childCount > 0)
            {
                for (int x = 0; x < thisLevel.transform.GetChild(j).childCount; x++)
                {
                    thisLevel.transform.GetChild(j).GetChild(x).gameObject.layer = 9;
                    Debug.Log("i");
                }
            }
            thisLevel.transform.GetChild(j).gameObject.layer = 9;
        }
    }
    private void nextlevel()
    {
   
        AllLevels.transform.GetChild(ThisLevel).gameObject.SetActive(false);
        if (ThisLevel < MaxLevel) ThisLevel++;
        AllLevels.transform.GetChild(ThisLevel).gameObject.SetActive(true);
        Homes = AllLevels.transform.GetChild(ThisLevel).GetChild(0).gameObject;
    }
}
