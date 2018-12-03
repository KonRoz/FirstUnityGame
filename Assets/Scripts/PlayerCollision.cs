using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    //Called When Collision occurs
	void OnCollisionEnter(Collision collisionInfo) 
    {
        //Check for tags as in any game you will have a LOT of the same object 
       if(collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
		
}

