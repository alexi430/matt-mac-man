using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

    public GameObject panel;

	void Start(){
        gameObject.SetActive(false);
	}

    public void StartGame()
    {
        Destroy(panel);
    }
	



}
