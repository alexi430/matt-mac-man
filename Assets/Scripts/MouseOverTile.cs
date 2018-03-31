using UnityEngine;
using System.Collections;

public class MouseOverTile : MonoBehaviour {
    private MeshRenderer meshRenderer;
    private MouseOverCube aMouseOverCube;
    private bool mouseOver = false;
    private Color unselectedColor;
    private Animator ani;
    

    void Start(){
        meshRenderer = GetComponentInParent<MeshRenderer>();
        aMouseOverCube = GetComponentInParent<MouseOverCube>();
        unselectedColor = meshRenderer.sharedMaterial.color;
        ani = GetComponentInParent<Animator>();
    }
	
	void Update() {
        if (Input.GetButtonDown("Fire1") && mouseOver)
        {
            ani.SetTrigger("Flip");
        }

    }

    void OnMouseOver()
    {
        mouseOver = true;
        //aMouseOverCube.OnMouseOver();
        //meshRenderer.sharedMaterial.color = Color.yellow;
    }

    void OnMouseExit()
    {
        mouseOver = false;
        //aMouseOverCube.OnMouseExit();
        //meshRenderer.sharedMaterial.color = unselectedColor;
    }

}
