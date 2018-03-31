using UnityEngine;
using System.Collections;

public class ClickMeToSetDestination : MonoBehaviour {
	private UnityEngine.AI.NavMeshAgent playerNavMeshAgent;
	private MeshRenderer meshRenderer;
	private bool mouseOver = false;

	private Color unselectedColor;
    private GameObject playerGO;


    void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		unselectedColor = meshRenderer.sharedMaterial.color;

		playerGO = GameObject.FindGameObjectWithTag("Player");
		playerNavMeshAgent = playerGO.GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1") && mouseOver){
			playerNavMeshAgent.SetDestination(transform.position);
            BasicController aBasicController = playerGO.GetComponent<BasicController>();
            aBasicController.isMoving = true;

        }
    }
	
	void OnMouseOver()
	{
		mouseOver = true;
		//meshRenderer.sharedMaterial.color = Color.yellow;
        meshRenderer.material.color = Color.gray;

    }
	
	void OnMouseExit()
	{
		mouseOver = false;
		//meshRenderer.sharedMaterial.color = unselectedColor;
        meshRenderer.material.color = unselectedColor;
    }
}
