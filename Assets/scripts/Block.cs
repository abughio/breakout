using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{

	private GameObject manager;
	private GameManager gm;

	// Use this for initialization
	void Start ()
	{
		manager = GameObject.FindGameObjectWithTag ("GameManager") as GameObject;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


}

