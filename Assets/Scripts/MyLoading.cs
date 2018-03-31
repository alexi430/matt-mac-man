using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyLoading : MonoBehaviour {

    public Button startButton;
    private bool temp = true;
    private Text LoadingText;

	void Start(){
        LoadingText = GetComponent<Text>();
        StartCoroutine(Loading());
        StartCoroutine(WordingBlink());
    }

    private IEnumerator Loading()
    {
        
        yield return new WaitForSeconds(2.0f);
        startButton.gameObject.SetActive(true);
        Destroy(gameObject);

    }

    private IEnumerator WordingBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            temp = !temp;
            LoadingText.text = (temp) ? "" : "Loading...";


        }
        
    }



    }
