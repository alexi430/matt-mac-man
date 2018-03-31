using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        SayItLikeJesse(accessToken);
    }

    public void SayItLikeJesse(string accessToken)
    {
        using (AndroidJavaObject examples = new AndroidJavaObject("com.addcomponent.unitynativeplugin.Example"))
        {
            examples.Call("sayItLikeJesse", accessToken);
        }
    }
}
