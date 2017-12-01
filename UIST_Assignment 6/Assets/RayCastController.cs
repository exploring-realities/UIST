using UnityEngine;
using System.Collections;

public class RayCastController : MonoBehaviour {


	public Material highlightMat;
	public GameObject camera;
	private Renderer objRend;
	public Material initialMat;
	private GameObject selectedObj;
	private bool selected = false;


	
	// Update is called once per frame
	void Update () {
	
		RaycastHit hit;
		Vector3 direction = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(this.transform.position, direction, Color.red, 0.1f);

		

        if (Physics.Raycast(this.transform.position, direction, out hit)){

			if(hit.collider.tag == "Target"){
				
				selectedObj = hit.collider.transform.gameObject;
				selectedObj.GetComponent<Renderer>().material = highlightMat;
				selected = true;
			}

		if(Input.GetKeyDown(KeyCode.Space) && selected){
			
			 selectedObj.transform.parent = this.transform;
			
		}
							
		}
		else if(selected)
		{
			selectedObj.GetComponent<Renderer>().material = initialMat;
			selected = false;
		}
		else if(Input.GetKeyUp(KeyCode.Space)){

			selectedObj.transform.parent = camera.transform;
		}

	}
}


