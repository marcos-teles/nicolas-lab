using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
	private int timeToUp;
	private int timetoDown;
	private float timeCont;
	private const int minToUp = 1;
	private const int maxToUp = 10;
	private string state;
	public GameObject enemy1;
	public GameObject enemy2;
	GameObject enemyTemp;
	
	
	
	// Use this for initialization
	void Start()
	{
		timeToUp = (int)Random.Range(minToUp, maxToUp);
		timetoDown = 3;
		timeCont = 0;
		state = "inRole";		
		renderer.material.color = Color.white;
		
				
	}
	
	// Update is called once per frame
	void Update()
	{
	
		
		if(GameMain.state == "inGame")
		{	
			timeCont += Time.deltaTime;
			
			if(state == "inRole" && (int)timeCont == timeToUp)
			{
				MoveUp();		
						
			}			
			else if(state == "outRole") 
			{
				if((int)timeCont == timeToUp + timetoDown)
					MoveDown();
				
				if((int)timeCont == timeToUp + timetoDown -1)
				{
					Animator controler = enemyTemp.GetComponent<Animator>();
					
					controler.Play("DownHole");
					
				}
			}			
			else if(state == "die")
			{
				if((int)timeCont == timeToUp + timetoDown + 1)
					MoveDown();
					
				if((int)timeCont == timeToUp + timetoDown -1)
				{
					Animator controler = enemyTemp.GetComponent<Animator>();
					controler.speed = 3f ;				
					controler.Play("Die");
				}
				
			}
	
		}
		
	}
	
	void MoveUp()
	{
		state = "outRole";
		int percent = (int)Random.Range(0, 100);
		
		if(percent <= 85)
		{
			gameObject.renderer.material.color = Color.red;
			enemyTemp =  (GameObject)Instantiate(enemy1, transform.position, transform.rotation);
		}			
		else
		{
			gameObject.renderer.material.color = Color.blue;
			enemyTemp =  (GameObject)Instantiate(enemy2, transform.position, transform.rotation);
		}
		
		
		Animator controler = enemyTemp.GetComponent<Animator>();
		controler.speed = 1.2f ;
		
	}
	
	void MoveDown()
	{
		state = "inRole";
		if(gameObject.renderer.material.color == Color.blue)
		{
			Hud.loseLife();
		}
		gameObject.renderer.material.color = Color.white;
		timeToUp = (int)Random.Range(minToUp, maxToUp);
		timeCont = 0;
		Destroy(enemyTemp);		
		
	}
	
	public void Die()
	{
		state = "die";
		gameObject.renderer.material.color = Color.green;			
		timeCont = 2;
		timeToUp = 0;				
	}
}
