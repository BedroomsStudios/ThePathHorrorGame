using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	
	void Start () {
	
	}
	
	
	void Update () {
	
	}
    
    void ApplayDamage ()
    {
        Debug.Log("Enamy HIT!");
        Destroy(gameObject);
    }
}
