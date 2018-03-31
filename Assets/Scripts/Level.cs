using UnityEngine;
using System.Collections;
using System;

public class Level : MonoBehaviour {

    public string levelName;
    public GameObject aLevelManagerObject;

    private UnityEngine.AI.NavMeshAgent playerNavMeshAgent;
    private MeshRenderer meshRenderer;
    private bool mouseOver = false;

    private Color unselectedColor;
    private GameObject playerGO;

    void Start(){
        //aLevelManager = aLevelManagerObject.GetComponent<LevelManager>();
        //aLevelManager.setLevelCylinder(levelName, gameObject);

        meshRenderer = GetComponent<MeshRenderer>();
        unselectedColor = meshRenderer.sharedMaterial.color;

        

        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerNavMeshAgent = playerGO.GetComponent<UnityEngine.AI.NavMeshAgent>();

    }
	
	void Update() {
        if (Input.GetButtonDown("Fire1") && mouseOver)
        {

            LevelManager aLevelManager = aLevelManagerObject.GetComponentInChildren<LevelManager>();
            aLevelManager.onlyTargetHasCoolider(Int32.Parse(levelName));

            playerNavMeshAgent.SetDestination(transform.position);
            BasicController aBasicController = playerGO.GetComponent<BasicController>();
            aBasicController.isMoving = true;

        }
    }

    void OnMouseOver()
    {
        mouseOver = true;
        meshRenderer.material.color = Color.cyan;

        //meshRenderer.sharedMaterial.color = Color.yellow;
    }

    void OnMouseExit()
    {
        mouseOver = false;
        meshRenderer.material.color = unselectedColor;

        //meshRenderer.sharedMaterial.color = unselectedColor;
    }

}
