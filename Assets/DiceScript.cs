using UnityEngine;

public class DiceScript : MonoBehaviour
{
    private static Rigidbody rb;
    public static Vector3 diceVelocity;
    public float force = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            float rotX = Random.Range(0, 500);
            float rotY = Random.Range(0, 500);
            float rotZ = Random.Range(0, 500);
            transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.Euler(new Vector3(rotX, rotY,rotZ));
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
