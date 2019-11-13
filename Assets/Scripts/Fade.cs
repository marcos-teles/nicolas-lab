using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

	// Use this for initialization
	public GUITexture ground;
	private float alpha = 0f;
	private int fadeFactor = 0;
	public bool restart = false;
	public float vel = 0.9f;
	private string typeFade;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeFactor != 0)
		{
			ground.color = new Color(ground.color.r, ground.color.g, ground.color.b, alpha);
			alpha += vel*fadeFactor;
		}
		
		ground.pixelInset = new Rect(0,0,Screen.width, Screen.height);
		//print (alpha);
	
	}
	
	public void CreateEffect(string fadeType)
	{
			

		
		if(fadeType == "fadeIn" && typeFade != "fadeIn")
		{
			alpha = 1;
			fadeFactor = -1;

		}
		else if (fadeType == "fadeOut" && typeFade != "fadeOut") 
		{
			alpha = 0;			
			fadeFactor = 1;

		}

		typeFade = fadeType;
	}
	
	public bool EndFadeIn()
	{
		if(alpha <= 0)
		{
			print ("efi");
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public bool EndFadeOut()
	{
		//print (alpha);
		if(alpha >= 1)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
}
