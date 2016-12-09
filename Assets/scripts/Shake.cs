using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
	public Camera camera;
	public float shake = 0;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	public float duration;
	Transform original;


	// Use this for initialization
	void Start ()
	{
		original = camera.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shake > 0) {
			camera.transform.localPosition = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;



		} else {
			shake = 0.0f;
		}
	}

	public void SetShake(float shakeRate){
		this.shake = shakeRate;	

	}




}

