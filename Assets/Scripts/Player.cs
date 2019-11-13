using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	// Use this for initialization	
	
	static public Vector3 enemyTarget;
	
	void Start ()
	{
		enemyTarget = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(GameMain.state == "inGame")
		{
			CheckClick();				
			
		}
	
	}
	
	void CheckClick()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit ))
		{
			
			
			if(Input.GetMouseButtonDown(0))
			{
				enemyTarget = transform.position;
				Enemy enemy = hit.transform.GetComponent<Enemy>();
				
				if(hit.transform.tag == "Enemy" && (enemy.renderer.material.color == Color.red || enemy.renderer.material.color == Color.blue))
				{
					enemyTarget = hit.transform.Find("PosLaser").position;					
					Hud.addPoint();
					enemy.Die();
					
				}
				else
				{
					enemyTarget = hit.point;
				}
				
				
				
			}			
		
		}
		
		//print(acertou);
	}
}
