using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.SceneManagement;

public class TestPref : MonoBehaviour {

    public GameObject sayDialog;

	void Start(){

        string[] fileEntries = Directory.GetFiles(Application.dataPath, "*.dlc");
        foreach (string url in fileEntries)
        {
            StartCoroutine(LoadAsset(url));
        }
        
	}
	
	void Update() {

	}

    public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void testLog()
    {
        Debug.Log("aitest1");
        print("aitest2");
        Debug.unityLogger.Log("aitest3");
        Debug.LogError("aitest4");

        Debug.unityLogger.LogError("aitest", "aitest5");
        Debug.LogAssertion("aitest6");
    }

    public void activateSayDialog()
    {
        sayDialog.SetActive(true);
    }

    public void TryToSwitchScene()
    {
        SceneManager.LoadScene("island04");
    }


    IEnumerator LoadAsset(string url)
    {

        //string url = "file:" + Application.dataPath;
        //string url = Application.dataPath;
        //url = Path.Combine(url, "mydlc.dlc");
        //var uwr = UnityWebRequest.GetAssetBundle("http://myserver/myBundle.unity3d");
        print("load asset url:" + url);

        
        var uwr = UnityWebRequest.GetAssetBundle(url);
        yield return uwr.SendWebRequest();
        //Instantiate(DownloadHandlerAssetBundle.GetContent(uwr).mainAsset);
        Instantiate(DownloadHandlerAssetBundle.GetContent(uwr));

        string[] AllScenePath = DownloadHandlerAssetBundle.GetContent(uwr).GetAllScenePaths();
        foreach( string scenePath in AllScenePath)
        {
            string sceneName = Path.GetFileNameWithoutExtension(scenePath);
            print(sceneName);
            IslandManager.DLCSceneNames.Add(sceneName);
        }
    }

    public void AITEST_printAllScene()
    {
        //Scene[] allScenes = SceneManager.GetAllScenes();
        print(SceneManager.sceneCount);
        for(int i=0;i< SceneManager.sceneCount; i++)
        {
            Scene aScene = SceneManager.GetSceneAt(i);
            print(aScene.name);
        }

        Scene[] allScenes = SceneManager.GetAllScenes();
        print(allScenes.Length);

        print(Application.levelCount);
        print(SceneManager.sceneCountInBuildSettings);
        
    }


}
