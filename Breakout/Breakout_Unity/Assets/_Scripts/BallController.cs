using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    /*
     * TO-DO:
     * disable ball at start
     * insantaiate when played
     * 
     */

    public float ballInitialVelocity = 600f;
    public float randMin = 0.1f;
    public float randMax = 1.0f;


    private Rigidbody rb;
    private bool start;

    public GameObject uiObject;
    private UIController uiController;

    private void Start()
    {
        uiController = uiObject.GetComponent<UIController>();
        rb = GetComponent<Rigidbody>();

        start = uiController.IsStart();
    }

    void Update()
    {
        
        if (!start)
        {
            rb.useGravity = false;
        }

        /*
        if (start)
        {
            transform.parent = null;
            start = true;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
        */

        //start = uiController.IsStart();
        


    }

    private void OnCollisionExit(Collision collision)
    {
        // Add random factor
        // Prevents ball from infinitely bouncing up and down
        rb.velocity = new Vector3(rb.velocity.x + Random.Range(randMin, randMax), rb.velocity.y + Random.Range(randMin, randMax), 0f);
    }

    private void OnBecameInvisible()
    {
        // Destroy object when it leaves the camera view
        Destroy(gameObject);
        uiController.GameOver();
    }
}
