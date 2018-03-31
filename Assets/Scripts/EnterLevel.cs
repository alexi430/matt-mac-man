using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnterLevel : MonoBehaviour {

	void Start(){
	}
	
	void Update() {

	}

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Level")
        {
            string levelName = other.gameObject.GetComponent<Level>().levelName;
            string sceneName = SceneManager.GetActiveScene().name;

            PlayerPrefs.SetString("CurrentIsland", sceneName);
            PlayerPrefs.SetString("CurrentLevel", levelName);
            GetComponent<SwitchScene>().switchToLevelScene();
            //GetComponent<SwitchScene>().switchToTest2Scene();
        }
        if (other.gameObject.tag == "Island")
        {
            string IslandName = other.gameObject.GetComponent<Island>().IslandName;
            GetComponent<SwitchScene>().switchToIsland(IslandName);
        }
    }



}
