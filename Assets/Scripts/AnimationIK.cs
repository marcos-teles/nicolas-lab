using UnityEngine;
using System.Collections;

public class AnimationIK : MonoBehaviour {

	
	public Transform armature;
	public Transform headFake;
	public Transform head;	
	GameObject auxHead; 
	Transform headFast;
	
	private string state;
	private int timeState;
	private float timeCont;
	
	void Start () {		
		
		auxHead = new GameObject();		
		headFast = auxHead.transform;		
		headFast.parent = head.parent;
		headFast.position = head.position;
		head.rotation = headFake.rotation;			
		state = "noting";		
		RestartTimestate();
		
	}
	
	
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		timeCont += Time.deltaTime;		
		
		if((int)timeCont == timeState)
		{			
			if(state == "noting")
			{
				state = "analysing";				
			}
			else
			{	
				state = "trasition";				
			}								
			
			RestartTimestate();
		}		
		
		if(state == "noting")
		{		
			
			CopyAnimation(transform, armature);
			Animator anim = armature.parent.GetComponent<Animator>();
			anim.speed = 1f;		
		
		}
		else if(state == "trasition")
		{
			if(head.localRotation != headFake.localRotation)
			{
				head.localRotation = Quaternion.Slerp(head.localRotation, headFake.localRotation, 0.2f);
				head.localScale = Vector3.Slerp(head.localScale, headFake.localScale, 0.2f);
			}	
			else
			{
				state = "noting";
			}
		}
		else if(state == "analysing")
		{
			headFast.LookAt(Player.enemyTarget, headFast.localPosition);
			
			head.localRotation = Quaternion.Slerp(head.localRotation, headFast.localRotation, 0.1f);			
			Animator anim = armature.parent.GetComponent<Animator>();
			anim.speed = 0;
			
		}	

	}
	
	void RestartTimestate()
	{
		timeCont = 0;
		timeState = Random.Range(3, 7);	
	}
	
	void CopyAnimation(Transform armature, Transform armatureToCopy)
	{
		if(armature.childCount > 0)
		{		
			foreach(Transform b1 in armature)
			{							
				foreach(Transform b2 in armatureToCopy)
				{					
					if(b1.name == b2.name)
					{					
						b1.rotation = b2.rotation;	
						b1.localScale = b2.localScale;	
						b1.localPosition = b2.localPosition;				
					}
					
					CopyAnimation(b1, b2);											
				}											
			}			
		}
	
	}
}
