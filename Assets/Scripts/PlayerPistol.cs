using UnityEngine;
using System.Collections;

public class PlayerPistol : MonoBehaviour {

    public GameObject revolver;
    public GameObject hand;
    float time;
    public int ammo;
    AudioSource audio;
    public AudioClip shot;
    public AudioClip empty;
    int x, y;


    void Update()
    {

        time -= Time.deltaTime;
        audio = gameObject.GetComponent<AudioSource>();
        Animator revolverAnim = revolver.gameObject.GetComponent<Animator>();
        Animator handAnim = hand.gameObject.GetComponent<Animator>();
        x = Screen.width / 2;
        y = Screen.height / 2;

        if (Input.GetMouseButtonDown(0))
        {
            if(time <0)
            {
                if(ammo >0)
                {
                    playShotAudio();
                    revolverAnim.SetTrigger("Shot1");
                    handAnim.SetTrigger("Shot1");
                    Shooting();
                    time = 0.8f;
                    ammo--;

                }
                else
                {
                    playEmptyAudio();

                }
                
            }
            
        }

    }

    public void playShotAudio()
    {
        audio.clip = shot;
        audio.Play();
    }
    void playEmptyAudio()
    {
        audio.clip = empty;
        audio.Play();
    }

    void Shooting()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(x, y));

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.tag == "enamy")
            {

                hit.collider.gameObject.SendMessage("ApplayDamage");
            }
        }


    }
}

