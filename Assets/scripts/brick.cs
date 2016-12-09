using UnityEngine;
using System.Collections;

public class brick : MonoBehaviour {

    public int hitPoints;
	private GameObject manager;
	private GameManager gm;


	// Use this for initialization
	void Start () {
        //hitPoints = 2;
		manager = GameObject.FindGameObjectWithTag("GameManager") as GameObject;
		gm = manager.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

        if(hitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
	
	}


	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Bullet") {
			hitPoints--;
			Camera.main.GetComponent<PerlinShake> ().InitiateShake (0.5f,1.0f,0.1f);
			gm.AddPoints (1);
			Destroy (collider.gameObject);
		}
	}




}
