using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startthegame : MonoBehaviour {

    public void Start()
    {
        Debug.Log("test");
    }

    public void Astartthegame()
    {
        Debug.Log("Hello");

    }

    public void SayMyName()
    {
        Debug.Log("Hello");
        using (AndroidJavaObject examples = new AndroidJavaObject("com.addcomponent.unitynativeplugin.Example"))
        {
            examples.Call("sayMyName");
        }
    }


    public void OnAccessToken(string accessToken)
    {
        Debug.Log("Message Received!!!! :" + accessToken);

        switch (accessToken)
        {
            case "Canvas/Panel/StartButton":
                buttonClick(accessToken);
                break;
            case "Canvas/Button":
                buttonClick(accessToken);
                break;
            case "Canvas/Panel/New Prefab/Panel-slot-grid/island01":
                buttonClick(accessToken);
                break;
            case "Canvas/Panel/New Prefab/Panel-slot-grid/island02":
                buttonClick(accessToken);
                break;
            case "Canvas/Panel/New Prefab/Panel-slot-grid/island03":
                buttonClick(accessToken);
                break;
            case "test":
                GameObject aCylinder = GameObject.Find("Cylinder1").GetComponent<GameObject>();
                Level aLevel = aCylinder.GetComponent<Level>();
                aLevel.OnMouseOver();
                break;
            default:
                break;
        }
       
        SayItLikeJesse(accessToken);
    }

    public void SayItLikeJesse(string accessToken)
    {
        using (AndroidJavaObject examples = new AndroidJavaObject("com.addcomponent.unitynativeplugin.Example"))
        {
            examples.Call("sayItLikeJesse", accessToken);
        }
    }

    private void buttonClick(string buttonPath)
    {
        Button startButton = GameObject.Find(buttonPath).GetComponent<Button>();
        startButton.onClick.Invoke();
    }
}
