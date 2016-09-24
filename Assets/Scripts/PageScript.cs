using UnityEngine;
using System.Collections;

public class PageScript : MonoBehaviour {

    Renderer rend;
    GameObject player;
    public string name;
    public bool On;
    bool show;
    public Texture page;
    int x, y;
    public float time;
    float acc;
    void Start()
    {
        On = false;
        rend = GetComponent<Renderer>();
        player = GameObject.FindWithTag("Player");


    }

    void Update()
    {

        x = Screen.width / 2;
        y = Screen.height / 2;
        time -= Time.deltaTime;

            ShaderChangeOn();   
            if (show)
          {
              UnUse();

          }
    }


    void UnUse()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            show = false;
            Time.timeScale = 1;
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
            rend.material.shader = Shader.Find("Standard");
        }
        else
        {
            rend.material.shader = Shader.Find("Outlined/Silhouetted Bumped Diffuse");
        }

    }

    void Use()
    {
        show = true;
        Time.timeScale = 0.0f;

    }

    void OnGUI()
        {
        if (show)
        {
            GUI.DrawTexture(new Rect(x - 200, y - 300, 400, 500), page);
        }
    }
}
