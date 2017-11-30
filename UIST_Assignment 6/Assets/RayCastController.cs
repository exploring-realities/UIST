using UnityEngine;
using System.Collections;

public class RayCastController : MonoBehaviour {


	public Material highlightMat;
	public GameObject camera;
	private Renderer objRend;
	private Material initialMat;
	private GameObject selectedObj;
	private bool selected = false;


	
	// Update is called once per frame
	void Update () {
	
			RaycastHit hit;
		Vector3 fwd = transform.TransformDirection(Vector3.back);
		Debug.DrawRay(transform.position, fwd, Color.red);


		objRend.material = initialMat;
		

        if (Physics.Raycast(transform.position, fwd, out hit)){
		
			if(!selected){

				selectedObj = hit.collider.transform.gameObject;
				objRend = selectedObj.GetComponent<Renderer>();
				initialMat = objRend.material;

				selected = true;
				objRend.material = highlightMat;

			}

		}


	}
}
