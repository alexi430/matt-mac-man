using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class SwitchScene : MonoBehaviour {



    public void switchBacktoGameScene()
    {
        SceneManager.LoadScene("Game01");
    }

    public void switchToLevelScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void switchToIslandScene()
    {
        SceneManager.LoadScene("island01");
    }

    public void switchToTestScene()
    {
        SceneManager.LoadScene("test");
    }

    public void switchToTest2Scene()
    {
        SceneManager.LoadScene("test2");
    }

    public void switchToCurrentIsland()
    {
        print("aitest: ??");
        string strCurrentIsland = getCurrentIsland();
        print("aitest:" + strCurrentIsland);
        SceneManager.LoadScene(strCurrentIsland);
    }


    public string getCurrentIsland()
    {
        string CurrentIsland = PlayerPrefs.GetString("CurrentIsland");
        if (CurrentIsland == "")
        {
            PlayerPrefs.SetString("CurrentIsland", "island01");
            return "island01";
        }
        return CurrentIsland;
    }

    public void switchToIsland(string IslandName)
    {
        PlayerPrefs.SetString("CurrentIsland", IslandName);
        switchToCurrentIsland();
    }
}
