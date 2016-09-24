using UnityEngine;
using System.Collections;

public class PistolController : MonoBehaviour {

    Renderer rend;
    string name;
    bool On;
    bool show;
    GameObject Player;
    float time;
	Shader Outline;
	Shader standart;


    void Start()
    {
        rend = GetComponent<Renderer>();
        Player = GameObject.FindWithTag("Player");


    }

    void Update()
    {
		Outline = Shader.Find("Toon/Basic Outline");
		standart = Shader.Find("Standard");
        time -= Time.deltaTime;
        ShaderChangeOn();


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
        Player.SendMessage("PistolOn");
		Player.SendMessage("Message", "Picked up Revolver");
        Destroy(gameObject);

    }

}
