using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraController : MonoBehaviour
{	
	public GameObject player; //The object that camera will control
	private Vector3 offset; //Vector3 is used on 3D design and it holds x, y and z components
    private float timeRemaining;
	public Text timeText; //The UI component for the time 
    public Text timeOverText; //The UI component for the time over

    //Get-set methods for timeRemaining variable
	public void setTimeRemaining(float timeRemaining)
	{
		this.timeRemaining = timeRemaining;
	}
	public float getTimeRemaining()
	{
		return timeRemaining;
	}

    //This function is called when the current scene starts to operate
	void Start ()
	{
		timeRemaining = 120; //The game is played within 120 seconds
		timeOverText.text = "";
		offset = transform.position - player.transform.position; //Assign offset
	}

    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update ()
	{
		transform.position = player.transform.position + offset; //Update the position of the player
		timeRemaining -= Time.deltaTime; //Decrease the time
		timeText.text = "Duration : " + ((int)timeRemaining).ToString (); //Show the time on the screen

		if (timeRemaining <= 0) //When the game is finished
		{
			timeOverText.text = "Time Over :(";
            Time.timeScale = 0; //Terminate the game
		}
	}
}