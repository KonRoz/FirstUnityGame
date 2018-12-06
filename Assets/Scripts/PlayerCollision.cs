using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    
    //Added for PlayerMovement jump if-statement
    public bool isTouchingTheGround = false;

    //Called When a of any sort Collision occurs between the player (because this component is on the player) and the environment
	void OnCollisionEnter(Collision collisionInfo) 
    {
        //Check for tags as in any game you will have a LOT of the same object 
       if(collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

       if(collisionInfo.collider.name == "Ground")
        {
            isTouchingTheGround = true;
        }
    }
}

