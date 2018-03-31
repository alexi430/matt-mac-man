using UnityEngine;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject[] levelCylinders;
    private int size = 0;
    private bool inited = false;
    public Toggle aToggleToShowIslandAllPassDialog;

    void Start(){

        
        initCylindersAndPlayer();

    }
	
    public int getCurrentIslandWin(string currentIsland)
    {
        string CurrentIslandWin = PlayerPrefs.GetString(currentIsland+"win");
        if (CurrentIslandWin == "")
        {
            PlayerPrefs.SetString(currentIsland+"win", "00");
            return 0;
        }
        int numCurrentIslandWin = Int32.Parse(CurrentIslandWin);
        return numCurrentIslandWin;
    }

    public int getCurrentIslandMaxWin(string currentIsland)
    {
        string CurrentIslandMaxWin = PlayerPrefs.GetString(currentIsland + "maxwin");
        print("aitest1:" + CurrentIslandMaxWin);
        if (CurrentIslandMaxWin == "")
        {
            PlayerPrefs.SetString(currentIsland+"maxwin", "00");
            return 0;
        }

        CurrentIslandMaxWin = PlayerPrefs.GetString(currentIsland + "maxwin");
        int numCurrentIslandMaxWin = Int32.Parse(CurrentIslandMaxWin);
        int numCurrentIslandWin = getCurrentIslandWin(currentIsland);
        if (numCurrentIslandWin > numCurrentIslandMaxWin)
        {
            PlayerPrefs.SetString(currentIsland + "maxwin", PlayerPrefs.GetString(currentIsland + "win"));
        }

        CurrentIslandMaxWin = PlayerPrefs.GetString(currentIsland + "maxwin");
        numCurrentIslandMaxWin = Int32.Parse(CurrentIslandMaxWin);
        return numCurrentIslandMaxWin;
    }

    void Update() {
        
	}

    public void onlyTargetHasCoolider(int target)
    {
        for(int i=0;i< levelCylinders.Length; i++)
        {
            if (i == target)
            {
                levelCylinders[i].GetComponent<CapsuleCollider>().enabled = true;
            }
            else
            {
                levelCylinders[i].GetComponent<CapsuleCollider>().enabled = false;
            }
            
        }
    }

    private void initCylindersAndPlayer()
    {
        string currentIsland = SceneManager.GetActiveScene().name;
        int currentMaxWin = getCurrentIslandMaxWin(currentIsland);
        int currentWin = getCurrentIslandWin(currentIsland);
        

        levelCylinders[0].GetComponent<CapsuleCollider>().enabled = false;
        for (int i = 1; i < levelCylinders.Length; i++)
        {
            if (i == currentMaxWin)
            {
                levelCylinders[i].GetComponent<CapsuleCollider>().enabled = true;
            }
            else if (i < currentMaxWin)
            {
                levelCylinders[i].GetComponent<CapsuleCollider>().enabled = true;
            }
            else if (i == currentMaxWin + 1)
            {
                levelCylinders[i].GetComponent<CapsuleCollider>().enabled = true;
            }
            else if (i > currentMaxWin + 1)
            {
                levelCylinders[i].GetComponent<CapsuleCollider>().enabled = false;
                levelCylinders[i].GetComponent<MeshRenderer>().material.color = Color.gray;
            }
        }

        print("currentwin:" + currentWin + " currentmaxwin:" + currentMaxWin);

        levelCylinders[currentWin].GetComponent<CapsuleCollider>().enabled = false;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = levelCylinders[currentWin].transform.position;
        player.transform.position += new Vector3(0.222f, 0, 0);
        player.GetComponent<EnterLevel>().enabled = true;
        inited = true;

        print("levelCylinders length-1:" + (levelCylinders.Length - 1) + " currentmaxwin:" + currentMaxWin);
        if (currentMaxWin == levelCylinders.Length-1)
        {
            aToggleToShowIslandAllPassDialog.isOn = true;
        }
    }

    //not used
    public void setLevelCylinder(string level, GameObject go)
    {
        size++;
        int numLevel = Int32.Parse(level);
        levelCylinders[numLevel] = go;
    }




}
