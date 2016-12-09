using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour {

    public float speed = 200f;
    float direction;
    Vector3 position = new Vector3();
    public BoxCollider2D rightCollider;
    public BoxCollider2D leftCollider;
    public BoxCollider2D middleCollider;
    private float screenX = Screen.width;
	public GameObject bulletEmitterRight;
	public GameObject bulletEmitterLeft;
	public GameObject bullet;
	public float bulletForce;
    

	// Use this for initialization
	void Start () {
        position.y = 0;
        position.z = 0;

        //print("ScreenX variable value is :" +   screenX);

       

      //transform.

    }

    // Update is called once per frame
    void Update() {
        
        position.x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
        transform.position += position;
        //print("Value of positionx = " + transform.position.x);
        if (position.x < screenX)
        {
            position.x = screenX;
        }

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			GameObject bullet1 = Instantiate (bullet, bulletEmitterLeft.transform.position, bulletEmitterLeft.transform.rotation) as GameObject;
			GameObject bullet2 = Instantiate (bullet, bulletEmitterRight.transform.position, bulletEmitterRight.transform.rotation) as GameObject;

			bullet1.GetComponent<Rigidbody2D> ().AddForce (new Vector3(0,bulletForce,0));
			Destroy (bullet1, 10f);
			bullet2.GetComponent<Rigidbody2D> ().AddForce (new Vector3(0,bulletForce,0));
			Destroy (bullet2, 10f);


		}

        
    }
}
