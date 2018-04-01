using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Networking;

public class LoadButtonIsland : MonoBehaviour {

    public Button buttonIslandPrefab;

    public static AssetBundle MyAssetBundle;


	void Start(){
        print("aitest");
        ArrayList islands = IslandManager.getAllIsland();

        foreach (string island in islands)
        {
            print("aitest: load button island " + island);
            Button aButton = Instantiate(buttonIslandPrefab, Vector3.zero, Quaternion.identity) as Button;
            aButton.gameObject.name = island;
            aButton.onClick.AddListener(() => { switchScene(island); });
            aButton.transform.SetParent(gameObject.transform, false);
            StartCoroutine(setButtonSprite(island, aButton));
        }
    }
	
	void Update() {

	}

    public void switchScene(string sceneName)
    {
        PlayerPrefs.SetString("CurrentIsland", sceneName);
        SceneManager.LoadScene(sceneName);
    }

    private Sprite TextureToSprite(Texture2D texture)
    {
        // get the size of the texture
        Rect rect = new Rect(0, 0, texture.width, texture.height);

        // set pivot point to be the center 0.5 = half way
        Vector2 pivot = new Vector2(0.5f, 0.5f);

        // create new Sprite object with out texture, size and pivot
        Sprite sprite = Sprite.Create(texture, rect, pivot);

        return sprite;
    }


    IEnumerator setButtonSprite(string Island, Button aButton)
    {
        if (Island != "island01" && Island != "island02" && Island != "island03")
        {
            if (MyAssetBundle == null)
            {
                print("in setButtonSprite with island04 and asset bundle is null");
                string url = Application.dataPath;
                //url = Path.Combine(url, "Scenes");
                url = Path.Combine(url, "island04");

                var uwr = UnityWebRequest.GetAssetBundle(url);

                print("aitest:"+url);

                yield return uwr.SendWebRequest();
                //Instantiate(DownloadHandlerAssetBundle.GetContent(uwr).mainAsset);
                Instantiate(DownloadHandlerAssetBundle.GetContent(uwr));

                MyAssetBundle = DownloadHandlerAssetBundle.GetContent(uwr);
            }

            string[] temp = MyAssetBundle.GetAllAssetNames();
            foreach (string a in temp) print("aitest:" + a);

            Texture2D aTexture2D = MyAssetBundle.LoadAsset<Texture2D>("island04.png");



            //Texture2D texture = request.asset as Texture2D;
            aButton.image.sprite = TextureToSprite(aTexture2D);
        }
        else
        {
            //string url = Application.dataPath;
            string url = "http://www.csie.ntu.edu.tw/~r93059";
            url = Path.Combine(url, Island + ".png");
            Debug.LogError("aitest:" + url);
            WWW www = new WWW(url);
            yield return www;


            //Texture2D externalImage = (Texture2D)Resources.Load(Island+".png");

            Texture2D externalImage = www.texture;
            aButton.image.sprite = TextureToSprite(externalImage);
        }
        
    }

}
