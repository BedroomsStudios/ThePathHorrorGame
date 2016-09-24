using UnityEngine;
using System.Collections;

public class LatarkaScript : MonoBehaviour {

    Renderer rend;
    bool On;
    bool show;
    GameObject Player;
    public float time;
	Shader Outline;
	bool on;
	Shader standart;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Player = GameObject.FindWithTag("Player");


    }
    
	void Update()
	{
		on = Player.GetComponent<PlayerController>().LampPickCanUse;
		Outline = Shader.Find("Toon/Basic Outline");
		standart = Shader.Find("Standard");
		time -= Time.deltaTime;
		ShaderChangeOn();

		if (on) 
		{
			
			gameObject.tag = "item";
		}else{

			gameObject.tag = "Untagged";

		}




	}
	void SetTime()
	{
		time = 0.1f;
	}


	void ShaderChangeOn()
	{
		if (time <= 0)
		{
			rend.material.shader = standart;
		}
		else
		{
			rend.material.shader = Outline;
		}

	}

    void Use()
    {

        Player.SendMessage("LatarkaOn");
        Player.SendMessage("Message", "Picked up Lamp");
		Player.GetComponent<PlayerController>().LampPickUp= true;
        Destroy(gameObject);


    }

    
}

