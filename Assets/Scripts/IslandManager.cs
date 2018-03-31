using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IslandManager : MonoBehaviour {


    public static ArrayList DLCSceneNames = new ArrayList();

    void Start(){
        
    }
	
	void Update() {

	}

    public static ArrayList getAllIsland()
    {
        ArrayList tempReturn = new ArrayList();
        tempReturn.Add("island01");
        tempReturn.Add("island02");
        tempReturn.Add("island03");
        foreach (string s in DLCSceneNames) tempReturn.Add(s);
        return tempReturn;
    }

}
