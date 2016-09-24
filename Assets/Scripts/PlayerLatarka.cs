using UnityEngine;
using System.Collections;

public class PlayerLatarka : MonoBehaviour {


    Light lampa;
    Animator anim;
	
	void Start ()
    {
        
    }
	
	
	void Update () {
        lampa = GetComponentInChildren<Light>();
        anim = GetComponentInChildren<Animator>();

        if (Input.GetButtonDown("Lamp"))
        {

            if(anim != null)
            {

                if (lampa.enabled)
                {
                    lampa.enabled = false;
                    anim.SetTrigger("Off");

                }
                else
                {
                    lampa.enabled = true;
                    anim.SetTrigger("On");


                }
            }
          
                
        }
	
	}
}
