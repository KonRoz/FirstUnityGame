using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Creating a Rigidbody variable
    public Rigidbody rb; 
    //Good Practice to include f at the end of a float
    //After including these two at the top we can now toggle them in unity
    public float fowardForce = 2000f; 
    public float sidewaysForce = 500f;
    public float minYPosition = -2f;

    // Update is called once per frame
    // Unity Physics Engine likes this better than just Update -- smoothes out collisions
    void FixedUpdate () 
    {
        // Time.deltaTime helps ensure that the cube acts the same on all computers regardless processor quality
        // Adding a foward force
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);
        
        if( Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if(rb.position.y < minYPosition)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
