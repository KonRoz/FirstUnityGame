using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    //This variable stores information about the player's orientation etc
    public Transform player;
    //A Vector 3 variable stores 3 floats -- this value can be toggled in the editor
    public Vector3 offset; 
	// Update is called once per frame
	void Update () {
        //We want the player and the camera's position to be the same --> player.position + offset = vector addition
        transform.position = player.position + offset;
	}
}
