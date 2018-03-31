using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButton : MonoBehaviour {
    public GameObject MenuPanel;
    public GameObject PanelDisable;
    private Animator ani;

    private bool isAppeared = false;

    void Start(){
        ani = MenuPanel.GetComponent<Animator>();

    }
	
	void Update() {

	}

    public void MenuButtonClick()
    {
        isAppeared = true;
        ani.SetTrigger("SidePanelAppear");
        StartCoroutine(LetPanelDisableActive());
        //Color aColor = PanelDisable.GetComponent<Image>().color;
        //aColor.a = 120;
    }

    public void MenuBackButtonClick()
    {
        isAppeared = false;
        ani.SetTrigger("SidePanelAppear");
        StartCoroutine(LetPanelDisableInactive());
        //Color aColor = PanelDisable.GetComponent<Image>().color;
        //aColor.a = 0;
    }

    private IEnumerator LetPanelDisableActive()
    {

        yield return new WaitForSeconds(0.7f);
        PanelDisable.SetActive(true);       

    }

    private IEnumerator LetPanelDisableInactive()
    {

        yield return new WaitForSeconds(0.6f);
        PanelDisable.SetActive(false);

    }

}
