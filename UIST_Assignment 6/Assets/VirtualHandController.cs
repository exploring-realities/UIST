using UnityEngine;
using System.Collections;


public class VirtualHandController : MonoBehaviour {

public Material highlightMat;
public GameObject camera;
private Renderer objRend;
private Material initialMat;
private GameObject selectedObj;
private bool selected = false;




	void Update(){

	
            
		//handling grabbing and releasing of object when space is pressed/released
		if(Input.GetKeyDown(KeyCode.Space) && selected){
			
			 selectedObj.transform.parent = this.transform;
			
		} else if(Input.GetKeyUp(KeyCode.Space)){

			selectedObj.transform.parent = camera.transform;
		}


	}


	public void OnTriggerEnter(Collider collider) {
		
		selectedObj = collider.transform.gameObject;
		objRend = selectedObj.GetComponent<Renderer>();
		initialMat = objRend.material;

		selected = true;
		objRend.material = highlightMat;

	

	}


	public void OnTriggerExit(Collider collider)
	{
		selected = false;
		objRend.material = initialMat;
		
	}





}
