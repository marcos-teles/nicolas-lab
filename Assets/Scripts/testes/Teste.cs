using UnityEngine;
using System.Collections;

public class Teste : MonoBehaviour {

	// Use this for initialization
	Vector3 angle = new Vector3(0,0,0);
	
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(angle + new Vector3(0,1,0));
		
		if(Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);		
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, 100))
			{
				if(hit.transform.tag == "Player")
					transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
			}
				//Debug.DrawLine(ray.origin, hit.point);
		}
		
		
		
		
		
		
		
			
	}
}
