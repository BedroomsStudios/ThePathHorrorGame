using UnityEngine;
using System.Collections;

public class Cinematic : MonoBehaviour {

	public GameObject player;
	public PlayerController playerCont;
	CharacterController control;
	Animator anim;
	void Start ()
	{
		player = GameObject.FindWithTag("Player");
		playerCont = player.GetComponent<PlayerController>();
		control = player.GetComponent<CharacterController> ();
		anim = player.GetComponent<Animator> ();


		control.enabled = false;
	}
	

	void Update () {
		
	
	}
	public void WakeUp()
	{
		control.enabled = true;
		anim.enabled = false;
	}
}
