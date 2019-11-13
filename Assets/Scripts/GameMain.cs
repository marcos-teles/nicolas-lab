using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour
{

	// Use this for initialization
	static public string state;
	static public float speedLevel;
	
	//Home Screen Elements	
	private float btnW;
	private float btnH;
    private float btnsX;
	private float btnsY;
	private float time;
	public Font fontGame;
	public Font fontGame2;
	public Fade fade;
	public Texture2D texture;
	GUIStyle textStyle;
	GUIStyle textStyle2;
	private bool canLoad = true;
	
	void Start()
	{
		state = "homeScreen";		
		btnW = Screen.width * 0.2f;
		btnH = Screen.height * 0.1f;
		btnsX = Screen.width/2 - btnW/2;
		btnsY = Screen.height * 0.7f;
		
		fade.CreateEffect("fadeIn");
				
				
	}
	void OnGUI()
	{

		
		textStyle = new GUIStyle(GUI.skin.button);		
		textStyle.font = fontGame;
		textStyle.fontSize = 30;		
		textStyle.normal.textColor = Color.white;		
		textStyle.hover.textColor = Color.cyan;		
		
		if(state == "homeScreen")
		{
			time+= Time.deltaTime*0.8f;
			float sinEfect = Mathf.Sin(time)*15;			
			
			if(GUI.Button(new Rect(btnsX,btnsY+sinEfect,btnW,btnH), "Iniciar Jogo",textStyle))
			{
				fade.CreateEffect("fadeOut");				
				state = "load";
			}
			sinEfect = Mathf.Sin(time-0.3f)*15;
			if(GUI.Button(new Rect(btnsX,btnsY+sinEfect + Screen.height * 0.15f,btnW,btnH), "Creditos", textStyle))
			{
				
				state = "creditsScreen";
			}		
		}
		else if(state == "load")
		{
			if(fade.EndFadeOut())
			{
				Application.LoadLevel(1);
				state = "inGame";
			}

		}		
		else if(state == "creditsScreen")
		{
			float boxW = Screen.width * 0.7f;
			float boxH = Screen.height * 0.4f;
			float boxX = Screen.width/2 - boxW/2;
			
			textStyle2 = new GUIStyle(GUI.skin.button);		
			textStyle2.font = fontGame2;		
			textStyle2.normal.textColor = Color.white;		
			textStyle2.hover.textColor = Color.cyan;
			
			GUI.Label(new Rect(boxX,btnsY-Screen.height*0.4f ,boxW,boxH), "Programação e Arte por\n Marcos Teles", textStyle2);
		
			
			if(GUI.Button(new Rect(btnsX,btnsY + 40,btnW,btnH), "tela inicial",textStyle))
			{
				state = "homeScreen";
			}		
		}
		else if (state == "paused")
		{
			Time.timeScale = 0;
		}
		else if (state == "inGame")
		{
			Time.timeScale = 1;		
		}
		
		print (state);	
			
	}
	


}
