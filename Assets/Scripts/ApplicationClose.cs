using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.IO;

public class ApplicationClose : MonoBehaviour {

	void Start(){
	}
	
	void Update() {

	}

    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
        AssetBundle.UnloadAllAssetBundles(true);
        /*
        string url = "file:" + Application.dataPath;
        url = Path.Combine(url, "mydlc.dlc");
        var uwr = UnityWebRequest.GetAssetBundle(url);
        DownloadHandlerAssetBundle.GetContent(uwr).Unload(true);
        */
    }
}
