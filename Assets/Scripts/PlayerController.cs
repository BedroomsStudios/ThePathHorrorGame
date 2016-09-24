using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera camera;
    GameObject target;
    string label;
    public Texture point;
    Animator animLat;
    Light lampa;


	public bool LampPickUp;
	public bool LampPickCanUse;
    
    public GameObject gun;
    public GameObject latarka;
    PlayerPistol gunCon;
    int x, y;
    float time;
    string msg;
    public GameObject handG;
	public Cinematic cin;
	public GameObject cinGO;
    public Animator handAnim;
    public GUIStyle style;
    bool PistolUse;
	public bool TargetActive;
    bool LampaUse;

	//Audio 
	AudioSource audio;
	public AudioClip dialog;



	void Start () {
		cinGO = GameObject.FindWithTag("Cinematic");
		cin = cinGO.GetComponent <Cinematic>();
        animLat = latarka.GetComponent<Animator>();
        lampa = latarka.GetComponentInChildren<Light>();
        gunCon = GetComponent<PlayerPistol>(); 
        handAnim = gameObject.GetComponent<Animator>();
		audio = GetComponentInChildren<AudioSource>();
		TargetActive = false;
        latarka.active = false;
        gunCon.enabled = false;
        handG.active = false;
 
    }
	
	void Update ()
    {
       
        animLat = latarka.GetComponent<Animator>();
        lampa = latarka.GetComponentInChildren<Light>();
        gunCon = GetComponent<PlayerPistol>();
        handAnim = handG.gameObject.GetComponent<Animator>();

        time -= Time.deltaTime;
        x = Screen.width / 2;
        y = Screen.height / 2;
        

        UsePistol();
		if (TargetActive)
		{
			UseItem ();
		}
        UseLamp();

    }
    
    void OnGUI()
    {
		if (TargetActive) {
			GUI.DrawTexture (new Rect (x - 16, y - 16, 32, 32), point);
			GUI.Label (new Rect (x - 30, y + 30, 100, 20), label, style);
			if (time > 0) {
				GUI.Label (new Rect (x, y + 200, 200, 30), msg, style);
			}
		}
       
    }

    void UseItem()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector2(x, y));

        if (Physics.Raycast(ray,out hit))
        {
            
            if(hit.collider.tag == "item" && hit.distance < 2)
            {
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SendMessage("Use");
                }

                string iname =  hit.collider.gameObject.name;
                hit.collider.SendMessage("SetTime");
                label = iname;
            }
            if(hit.collider.tag != "item" || hit.distance >2)
            {
               
                label = " ";
            }
        }


    }
    void UseLamp()
    {
      if (Input.GetButtonDown("Lamp"))
            {
            if (animLat != null)
            {
                
                if (PistolUse)
                {
                    handAnim.SetBool("On", false);
                    PistolUse = false;
                    gunCon.enabled = false;
                    
                }

                if (lampa.enabled)
                {
                    animLat.SetTrigger("Off");
                    LampaUse = false;
                    lampa.enabled = false;
                    
                }
                else
                {
                    LampaUse = true;
                    lampa.enabled = true;
                    animLat.SetTrigger("On");
                }
            }
        }
    }
    void UsePistol()
    {
        if (Input.GetButtonDown("Pistol"))
        {

            if (LampaUse)
            {

                animLat.SetTrigger("Off");
                LampaUse = false;
                lampa.enabled = false;
            }

            if (PistolUse)
            {
                handAnim.SetBool("On",false);
                PistolUse = false;
                gunCon.enabled = false;


            }
            else
            {

                gunCon.enabled = true;
                handAnim.SetBool("On", true);
                PistolUse = true;
            }

        }
        
    }
    void Message(string info)
    {
        msg = info;
        time = 4f;
    }
    void LatarkaOn()
    {
        if (PistolUse)
        {
             handAnim.SetBool("On",false);
            PistolUse = false;
            gunCon.enabled =  false;
            

        }
        latarka.active = true;
        LampaUse = true;
        animLat.SetTrigger("On");

    }
    void PistolOn()
    {
        
        if (LampaUse)
        {
            animLat.SetTrigger("Off");
            LampaUse = false;
            lampa.enabled = false;


        }
        PistolUse = true;
        gunCon.enabled= true;
        handAnim.enabled = true;
        handG.active = true;
        handAnim.SetBool("On", true);

    }



	public void PlayerAfterAnim()
	{
		TargetActive = true;
		cin.SendMessage ("WakeUp");

	}

	public void PlayDialogue()
	{
		audio.clip = dialog;
		audio.Play();
	}

}
