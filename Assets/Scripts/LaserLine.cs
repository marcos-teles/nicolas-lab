using UnityEngine;
using System.Collections;

public class LaserLine : MonoBehaviour {
	public Transform canion;
	public Color c1 = Color.yellow;
	public Color c2 = Color.red;
	private bool shoot;
	private float shootWidht;
	public int lengthOfLineRenderer = 2;
	void Start() {
		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetColors(c1, c2);
		shootWidht = 0.1f;
		lineRenderer.SetWidth(shootWidht, shootWidht);
		//lineRenderer.SetVertexCount(lengthOfLineRenderer);
	}
	void Update() {
		if(GameMain.state == "inGame")
		{
			LineRenderer lineRenderer = GetComponent<LineRenderer>();
			if(Input.GetMouseButtonDown(0))
			{
				shoot = true;
				shootWidht = 0.1f;
				
				
				
			}
			
			
			
			if(shoot)
			{
				canion.rotation = Quaternion.Slerp(canion.localRotation, transform.localRotation, 0.8f);
				transform.LookAt(Player.enemyTarget);
				
				if(canion.localRotation == transform.localRotation)
				{
					 
					lineRenderer.SetPosition(0, transform.position);		
					lineRenderer.SetPosition(1, Player.enemyTarget);
					shootWidht -= 0.008f;
					lineRenderer.SetWidth(shootWidht, shootWidht);				
				
				}
			
				
				if(shootWidht <= 0)
				{
					shoot = false;
					shootWidht = 0;
					lineRenderer.SetWidth(shootWidht, shootWidht);
					
					transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + 15 ,
					                                      transform.rotation.eulerAngles.y ,
					                                      transform.rotation.eulerAngles.z);
				}	
				
												
			}		
		}		
	}
}
