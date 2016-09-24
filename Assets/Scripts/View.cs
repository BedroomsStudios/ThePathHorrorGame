using UnityEngine;
using System.Collections;

public class View : MonoBehaviour {

    Renderer rend;
    public string name;
    public bool On;
    bool show;
    public Texture page;
    public float time;
    void Start()
    {
        rend = GetComponent<Renderer>();


    }

    void Update()
    {

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
            rend.material.shader = Shader.Find("Standard");
        }
        else
        {
            rend.material.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
        }

    }

    void Use()
    {
        // show = true;
        // Time.timeScale = 0.0f;

    }


}
