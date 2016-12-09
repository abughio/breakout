using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 10f;
    public bool active = false;
    public int lives = 30;
    public int score = 0;
    public TextMesh scoreText;
    public TextMesh lifeText;
	public RectTransform normalScore;
	public RectTransform highScore;
    string scorePref = "Score: ";
    string livesPref = "Lives: ";
	PerlinShake sn;
	public GameObject gameManager;
	private GameManager gm;
    Vector3 direction = new Vector3();
    Vector3 velocity;


    // Use this for initialization
    void Start () {
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
		sn = this.GetComponent<PerlinShake>();
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		gm = gameManager.GetComponent<GameManager> ();
       
    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            active = true;
        }

		if (active && lives > 0 )
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        // speed += Time.deltaTime;

     //   scoreText.text = scorePref + score;
       // lifeText.text = livesPref + lives;


      	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        //print("Collision Detected");
		if (collider.tag == "TopWall") {
			direction = new Vector3 (direction.x, direction.y * -1, 0f);
		} else if (collider.tag == "LeftWall" || collider.tag == "RightWall") {
			direction = new Vector3 (direction.x * -1, direction.y, 0f);
            
		} else if (collider.tag == "BottomWall") {
			lives--;
			transform.position = new Vector3 (0f, 0f, 0f);
			active = false;

		} else if (collider.tag == "Bar") {
			//print ("Bar is hit");

			//print (collider.ToString ());



//			print ("value of direction" + direct.ToString ());
//
//			if (collider.gameObject.name == "Middle Collider") {
//            
//				direction = new Vector3 (direction.x, direction.y * -1, 0f);
//			} else if (collider.gameObject.name == "Right Collider") {
//				// if ball is coming from right side it should always to back to right side. 
//				direction = new Vector3 (direction.x < 0 ? direction.x * -1f : direction.x * 1f, direction.y * -1f, 0f);
//              
//			} else if (collider.gameObject.name == "Left Collider") {
//				direction = new Vector3 (direction.x < 0 ? direction.x * 1f : direction.x * -1f, direction.y * -1f, 0f);
//               
//
//			}


			setDirection (FindDirection (this.transform.position, collider.transform.position, collider.bounds.size.x));



		} else if (collider.tag == "Brick") {
			//print(collider.ToString());

			setDirection(FindDirection (this.transform.position, collider.transform.position, collider.bounds.size.x));
			var other = collider.gameObject.GetComponent<brick> ();
			other.hitPoints--;
			sn.InitiateShake (0.5f,3.0f,0.1f);
			gm.AddPoints (1);

		} else {
			
		}


    }

	void setDirection (float direct)
	{
					
		// right side.
		if (direct > 0.4) {
			direction = new Vector3 (direction.x < 0 ? direction.x * -1f : direction.x * 1f, direction.y * -1f, 0f);
		}
		else
			if (direct < -0.4) {
				// left side
				direction = new Vector3 (direction.x < 0 ? direction.x * 1f : direction.x * -1f, direction.y * -1f, 0f);
			}
			else {
				//middle 
				direction = new Vector3 (direction.x, direction.y * -1, 0f);
			}
	}

				private float FindDirection(Vector3 ball, Vector3 brick, float barWidth){

		return (ball.x - brick.x) / barWidth;
	}


}
