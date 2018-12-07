using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Creating a Rigidbody variable
    public Rigidbody rb;
    public PlayerCollision theCollision;
    //Good Practice to include f at the end of a float
    //After including these two at the top we can now toggle them in unity
    public float fowardForce = 2000f; 
    public float sidewaysForce = 500f;
    public float jumpVelocity = 10f;
    public float minYPosition = -2f;

    //The Velocity At the Present Position
    public Vector3 currentSpeed;
    

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

        //Jump Section

        if (Input.GetKey("space"))
        {
            //we want the cube to fall back to earth
            rb.useGravity = true;

            //the component velocities at the time of jumping are calculated by using the rigidBody's position in each direction
            currentSpeed = (rb.GetPointVelocity(new Vector3(rb.position.x, rb.position.y, rb.position.z)));

            //PlayerCollision is referenced to check if the block is touching the ground when the space bar is pressed
            if (theCollision.isTouchingTheGround == true)
            {
                //the new velocity needs fixing: the current velocity should be inputed in the x and z components (especially the z eek!)
                rb.velocity = new Vector3(currentSpeed.x ,jumpVelocity, currentSpeed.z);

                //when this is set to false the player cannot keep pressing the space bar to go infinitely upwards
                theCollision.isTouchingTheGround = false;

            }
        }
        
        if(rb.position.y < minYPosition)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
