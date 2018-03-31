using UnityEngine;
using System.Collections;

public class MouseOverCube : MonoBehaviour {
    private MeshRenderer meshRenderer;
    private bool mouseOver = false;
    private Color unselectedColor;
    private Animator ani;
    

    void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
        unselectedColor = meshRenderer.sharedMaterial.color;
        ani = GetComponentInParent<Animator>();
    }
	
	void Update() {
        if (Input.GetButtonDown("Fire1") && mouseOver)
        {
            ani.SetTrigger("Flip");
        }

    }

    public void OnMouseOver()
    {
        mouseOver = true;
        meshRenderer.sharedMaterial.color = Color.yellow;
    }

    public void OnMouseExit()
    {
        mouseOver = false;
        meshRenderer.sharedMaterial.color = unselectedColor;
    }

}
