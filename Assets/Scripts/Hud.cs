using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour
{
	
	static private int life;
	static private int pontuation;
	private float time;
	private string pauseButton;	
	private GUIStyle styleText;
	public Font HudFont;
	public Fade fade;

	// Use this for initialization	
	void Start()
	{
		time = 120;
		life = 3;
		pontuation = 0;
		pauseButton = "II";
		GameMain.state = "inGame";
		fade.CreateEffect("fadeIn");
		
	
	}
	
	// Update is called once per frame
	void OnGUI()
	{	
	
		styleText = new GUIStyle(GUI.skin.button);
		styleText.font = HudFont;
		styleText.hover.textColor = Color.cyan;	
			
		GameStatsGUI();
		
		
		if(GameMain.state == "gameOver")
		{
			GameOverGUI();
		}
		else
		{
			PauseGUI();		
		}
	}		
	
	void Update()
	{
		if(GameMain.state == "inGame")
		{
			time -= Time.deltaTime;
			if((int)time == 0)
			{
				GameMain.state = "gameOver";
			}
		}		
	}
	
	static public void loseLife()
	{
		if(GameMain.state != "gameOver" )
		{
			life--;
		}		
			
		if(life == 0)
		{
			GameMain.state = "gameOver";
		}
	}
	
	static public void addPoint()
	{
		pontuation += 10;
	}
	
	void GameStatsGUI()
	{
		float width = Screen.width * 0.2f;
		float height = Screen.height * 0.07f ;			
		float positionX = Screen.width* 0.02f;
		float positionY = Screen.height* 0.05f;
		float offSetY = Screen.height*0.08f;

		GUI.Box (new Rect (100, 100, time , 10), "");

		//GUI.Box(new Rect(positionX, positionY, width, height), "time: " + (int)time, styleText);
		//GUI.Box(new Rect(positionX, positionY + offSetY, width, height), "life: " + life, styleText);
		//GUI.Box(new Rect(positionX + width*1.1f , positionY, width, height*2), "pontuaçao \n " + pontuation, styleText);
		
		//GUI.Button(new Rect(200,10,100,20), GameMain.state);
	}
	
	void GameOverGUI()
	{
		float width = Screen.width * 0.3f;
		float height = Screen.height * 0.07f ;			
		float positionX = Screen.width* 0.98f - width;
		float positionY = Screen.height* 0.05f;
		float offSetY = Screen.height*0.08f;
		
		GUI.Button(new Rect(positionX, positionY, width, height), "Game Over" , styleText);
		
		if(GUI.Button(new Rect(positionX, positionY + offSetY, width, height), "Reiniciar", styleText))
		{
			Application.LoadLevel(1);
			GameMain.state = "inGame";
		}
		
		if(GUI.Button(new Rect(positionX, positionY + offSetY*2, width, height), "Tela Inicial", styleText))
		{
			Application.LoadLevel(0);
			GameMain.state = "homeScreen";
		}		
	}
	
	void PauseGUI()
	{
		float width = Screen.width * 0.07f;
		float height = Screen.height * 0.07f ;			
		float positionX = Screen.width* 0.98f - width;
		float positionY = Screen.height* 0.05f;
		
		
		if(GUI.Button(new Rect(positionX,positionY,width,height), pauseButton, styleText))
		{
			if(pauseButton == "II")
			{	
				pauseButton = ">";
				GameMain.state = "paused";
			}
			else
			{
				pauseButton = "II";
				GameMain.state = "inGame";
			}
		}
	}
}
