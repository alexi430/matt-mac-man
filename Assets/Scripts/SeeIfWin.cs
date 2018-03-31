using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using System.IO;
using System;

public class SeeIfWin : MonoBehaviour {
    public GameObject[] tiles;
    public char[] FrontOrBackAnswer;
    public char[] Front;
    public char[] Back;
    private bool isWin = false;
    public Text TextWin;
    public Text CurrentResult;
    public Text targetText;
    public bool isInited = false;
    public int numCurrent;
    public int numAnswer;
    void Start(){
    }

    public void initTiles(int size)
    {
        tiles = new GameObject[size];
        FrontOrBackAnswer = new char[size];
        Front = new char[size];
        Back = new char[size];
    }

    public void printFrontOrBackAnswer()
    {
        print("length:" + FrontOrBackAnswer.Length);
        for(int i=0; i<FrontOrBackAnswer.Length; i++)
        {
            print(i + "th char: " + FrontOrBackAnswer[i]);
        }
    }




    void Update() {
        if (isInited && !isWin)
        {
            calculateNow();
            //if (judgeIfWin())
            if (numAnswer==numCurrent)
            {
                isWin = true;
                for(int i=0; i<tiles.Length; i++)
                {
                    Destroy(tiles[i]);
                }
                CurrentResult.text = "";
                targetText.text = "";
                TextWin.text = "You Win!";
                storeCurrentIslandWin();
            }
        }
	}

    private void calculateNow()
    {
        string tempString = "Current: " + "?";

        char[] temp = new char[FrontOrBackAnswer.Length];

        for (int i = 0; i < FrontOrBackAnswer.Length; i++)
        {
            if (tiles[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Front"))
            {
                temp[i] = Front[i];
            }
            else if (tiles[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Back"))
            {
                temp[i] = Back[i];
            }
            else
            {
                CurrentResult.text = tempString;
                return;
            }
        }

        //print(FrontOrBackAnswer.Length + "");
        //foreach (char c in temp) print(c);

        ArrayList aArrayList = new ArrayList();
        char pc = 'x';
        char po = 'x';
        int pn = 0;
        for(int i=0;i<temp.Length;i++)
        {
            char c = temp[i];
            if (pc == '+' || pc == '-' || pc == '*' || pc == '/') 
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    po = c;
                }
                else
                {
                    aArrayList.Add(po);
                    pn = Int32.Parse(c.ToString());
                    if (i == temp.Length - 1) aArrayList.Add(pn);
                }
            }
            else
            {
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    po = c;
                    aArrayList.Add(pn);
                    pn = 0;
                }
                else
                {
                    pn = pn * 10 + Int32.Parse(c.ToString());
                    if(i==temp.Length-1) aArrayList.Add(pn);
                }

            }
            pc = temp[i];
        }

        for (int i = 0; i < aArrayList.Count; i++)
        {
            print(aArrayList[i]);
        }

        int result = CalculateMulDivAddSub(aArrayList);
        CurrentResult.text = "Current: " + result.ToString();
        numCurrent = result;
    }

    private int CalculateMulDivAddSub(ArrayList aArrayList)
    {
        ArrayList arrayListNoMulAndDiv = CalculateFirstMulOrDiv(aArrayList);
        ArrayList arrayListDone = CalculateFirstAddOrSub(arrayListNoMulAndDiv);
        int result = (int)arrayListDone[0];
        return result;
    }

    private ArrayList CalculateFirstMulOrDiv(ArrayList aArrayList)
    {
        for(int i = 0; i < aArrayList.Count; i++)
        {
            if (aArrayList[i].GetType() == typeof(char))
            {
                char c = (char)aArrayList[i];
                if (c == '*' )
                {
                    aArrayList[i] = ((int)aArrayList[i - 1]) * ((int)aArrayList[i + 1]);
                    aArrayList.RemoveAt(i + 1);
                    aArrayList.RemoveAt(i - 1);
                    return CalculateFirstMulOrDiv(aArrayList);
                }
                else if (c == '/')
                {
                    aArrayList[i] = ((int)aArrayList[i - 1]) / ((int)aArrayList[i + 1]);
                    aArrayList.RemoveAt(i + 1);
                    aArrayList.RemoveAt(i - 1);
                    return CalculateFirstMulOrDiv(aArrayList);
                }
            }
        }
        return aArrayList;
    }

    private ArrayList CalculateFirstAddOrSub(ArrayList aArrayList)
    {
        for (int i = 0; i < aArrayList.Count; i++)
        {
            if (aArrayList[i].GetType() == typeof(char))
            {
                char c = (char)aArrayList[i];
                if (c == '+')
                {
                    aArrayList[i] = ((int)aArrayList[i - 1]) + ((int)aArrayList[i + 1]);
                    aArrayList.RemoveAt(i + 1);
                    aArrayList.RemoveAt(i - 1);
                    return CalculateFirstMulOrDiv(aArrayList);
                }
                else if (c == '-')
                {
                    aArrayList[i] = ((int)aArrayList[i - 1]) - ((int)aArrayList[i + 1]);
                    aArrayList.RemoveAt(i + 1);
                    aArrayList.RemoveAt(i - 1);
                    return CalculateFirstMulOrDiv(aArrayList);
                }
            }
        }
        return aArrayList;
    }

    private bool judgeIfWin()
    {
        bool tempReturn = true;

        for(int i=0; i< FrontOrBackAnswer.Length; i++)
        {
            if (FrontOrBackAnswer[i] == '1')
            {
                if (!tiles[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Front"))
                {
                    tempReturn = false;
                    break;
                }
            }
            if (FrontOrBackAnswer[i] == '0')
            {
                if (!tiles[i].GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Back"))
                {
                    tempReturn = false;
                    break;
                }
            }
        }
        return tempReturn;
    }

    

    public void storeCurrentIslandWin()
    {
        string currentIsland = PlayerPrefs.GetString("CurrentIsland");
        string currentLevel = PlayerPrefs.GetString("CurrentLevel");
        PlayerPrefs.SetString(currentIsland + "win", currentLevel);

        int currentWin = Int32.Parse(currentLevel);
        int currintMaxWin = Int32.Parse(PlayerPrefs.GetString(currentIsland + "maxwin"));
        if(currentWin> currintMaxWin)
        {
            PlayerPrefs.SetString(currentIsland + "maxwin", currentLevel);
        }
    }
}
