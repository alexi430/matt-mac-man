using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.Networking;

public class InitTile : MonoBehaviour {
    //public GameObject prop;
    public TextAsset levelDataTextFile;
    public GameObject number1;
    public GameObject number2;
    public GameObject number3;
    public GameObject number4;
    public GameObject numberAdd;
    public GameObject numberSub;
    public GameObject numberMul;
    public GameObject numberDiv;
    public GameObject tile;
    public Text targetText;
    public Dictionary<char, GameObject> dictionary = new Dictionary<char, GameObject>();

    public SeeIfWin aSeeIfWin;

    private string LevelData = "";


    void Start(){

        getLevelDataTextFile();
        //StartCoroutine(initTiles());
        
    }

    private void initTiles(string LevelData)
    {
        //AssetBundle aAssetBundle;

        targetText.text = LevelData;
        //yield return new WaitForSeconds(1.0f);


        aSeeIfWin = gameObject.GetComponent<SeeIfWin>();

        char newlineChar = '\n';
        //string[] stringArray = levelDataTextFile.text.Split(newlineChar);


        string[] stringArray = LevelData.Split(newlineChar);
        dictionary['1'] = number1;
        dictionary['2'] = number2;
        dictionary['3'] = number3;
        dictionary['4'] = number4;
        dictionary['+'] = numberAdd;
        dictionary['-'] = numberSub;
        dictionary['*'] = numberMul;
        dictionary['/'] = numberDiv;

        int numRows = stringArray.Length;

        int numTiles = numRows - 1;
        aSeeIfWin.initTiles(numTiles);

        string strAnswer = stringArray[0];
        targetText.text = "Target = " + strAnswer;
        int intAnswer = Int32.Parse(strAnswer);
        aSeeIfWin.numAnswer = intAnswer;
        aSeeIfWin.numCurrent = intAnswer - 1;

        for (int i = 1; i < stringArray.Length; i++)
        {
            AddPropFront aAddPropFront = tile.GetComponentInChildren<AddPropFront>();
            aAddPropFront.prop = dictionary[stringArray[i][0]];
            aSeeIfWin.Front[i - 1] = stringArray[i][0];

            AddPropBack aAddPropBack = tile.GetComponentInChildren<AddPropBack>();
            aAddPropBack.prop = dictionary[stringArray[i][1]];
            aSeeIfWin.Back[i - 1] = stringArray[i][1];

            aSeeIfWin.FrontOrBackAnswer[i - 1] = stringArray[i][2];

            float x = 0f;
            int offset = numRows / 2;
            x = i - offset;
            Vector3 position = new Vector3(x, 0.5f, 0f);
            Quaternion noRotation = Quaternion.identity;
            aSeeIfWin.tiles[i - 1] = Instantiate(tile, position, noRotation) as GameObject;
        }

        aSeeIfWin.isInited = true;
        //yield return new WaitForSeconds(1.0f);
    }

    void Update() {

	}

    private void getLevelDataTextFile()
    {
        string currentIsland = PlayerPrefs.GetString("CurrentIsland");
        string currentLevel = PlayerPrefs.GetString("CurrentLevel");
        StartCoroutine(getLevelData(currentIsland, currentLevel));
        //levelDataTextFile = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Level/" + currentIsland + "/level" + currentLevel + ".txt");
    }

    IEnumerator getLevelData(string currentIsland, string currentLevel)
    {
        if (currentIsland == "island04")
        {


            TextAsset aTextAsset = LoadButtonIsland.MyAssetBundle.LoadAsset<TextAsset>("level"+ currentLevel + ".txt");

            initTiles(aTextAsset.text);
        }
        else
        {

            //string url = "file:" + Application.dataPath;
            string url = "http://www.csie.ntu.edu.tw/~r93059";
            //url = Path.Combine(url, "Level");
            url = Path.Combine(url, currentIsland);
            url = Path.Combine(url, "level" + currentLevel + ".txt");
            WWW www = new WWW(url);
            yield return www;

            LevelData = www.text;

            //TextAsset textAsset = (TextAsset)Resources.Load(currentIsland+"/level"+currentLevel+".txt");
            //LevelData = textAsset.text;

            initTiles(LevelData);
        }
        
    }

}
