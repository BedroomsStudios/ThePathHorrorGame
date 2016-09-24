using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    Animator anim;
    int i;
    AudioSource audio;
    public AudioClip open;
	GameObject Player;
	bool on;
	bool use;

    void Start ()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
		Player = GameObject.FindWithTag("Player");

	}
	
	
	void Update ()
    {
		on = Player.GetComponent<PlayerController>().LampPickUp;

	}

    public void Use()
    {
		if (on) {
			

			if (i == 0) {
				playAudio ();
				anim.SetTrigger ("Open");
				i++;
			} else {
				i--;
				playAudio ();
				anim.SetTrigger ("Close");
			}
		} else {

			Player.SendMessage ("PlayDialogue");
			Player.GetComponent<PlayerController>().LampPickCanUse = true;



		
		}
    }
    public void playAudio()
    {
        audio.clip = open;
        audio.Play();
    }
   
    public  void SetTime()
    {
        
    }
}
