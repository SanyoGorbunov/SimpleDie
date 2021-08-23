using UnityEngine;

public class DiceScript : MonoBehaviour
{
    private static Rigidbody rb;
    public static Vector3 diceVelocity;
    public float force = 1500;
    public float throwHeight = 3.0f;
    public Follow followCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // ignore input if cube is not stopped yet
        if (rb.velocity.magnitude != 0.0f)
        {
            return;
        }
        else
        {
            if(!followCamera.enabled)
            { 
                followCamera.enabled = true;
                followCamera.calculateDesiredPosRot();
            }
        }

        //Follow.isActive = true;

        /*if (!Follow.isActive)
        {
            followCamera.calculateDesiredPosRot();
        }*/

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            followCamera.enabled = false;
            float dirX = Random.Range(-250, 250);
            float dirY = Random.Range(-250, 250);
            //float dirZ = Random.Range(0, 250);
            float rotX = Random.Range(-250, 250);
            float rotY = Random.Range(-250, 250);
            float rotZ = Random.Range(-250, 250);
            Vector3 oldPos = transform.position;
            oldPos.y = throwHeight;
            transform.position = oldPos;
            transform.rotation = Quaternion.Euler(new Vector3(rotX, rotY,rotZ));
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Vector3.up * force,ForceMode.Force);
            rb.AddTorque(dirX, dirY, 200);
        }
    }
}
