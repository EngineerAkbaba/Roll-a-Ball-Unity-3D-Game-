using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed; //The speed of the player
	private Rigidbody rb; //Controls the position of the player through physics rules
	private int score; //The score of the player
	public Text countText; //The UI component that refers to score
	public Text winText; //Occurs on the screen when the player collects all the pick up objects
	public CameraController camera;

    //Get-set methods for score variable
	public void setScore(int score)
	{
		this.score = score;
	}
	public int getScore()
	{
		return score;
	}

    //This function is called when the current scene starts to operate
	void Start ()
	{
		rb = GetComponent<Rigidbody>(); //Get the position of player
		setScore (0);
		assignScore (); //Call function
		winText.text = ""; //Do NOT show the winText when the game starts
	}

    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update ()
	{
        //Get the horizontal and vertical inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed); //Add physics force to the player according to inputs
        assignScore(); //Call function
	}
	
    //Control the collisor
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) //If the player crashs any of the pick up objects
		{
			other.gameObject.SetActive (false); //Deactive/destruct the pick up object
			score = score + 10; //Increase the score
            assignScore(); //Call function
		}
	}

    //This function sets the score 
	void assignScore()
	{
		countText.text = "Score     : " + score.ToString ();
		if (score >= 270) //If all the pick up objects has been collected
		{
			winText.text = "You Win:)";
            Time.timeScale = 0; //Terminate the game
		}
    }
}
