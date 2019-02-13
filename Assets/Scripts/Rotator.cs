using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    //This function runs per frame (fps-frame per second is changable according to different computers/CPUs)
	void Update ()
	{
        //Rotate the pick ups per frame
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}