using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePhysics : MonoBehaviour
{
    private static Rigidbody rb;
    private Vector3 diceVelocity;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        diceVelocity = rb.velocity;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Roll();
        }
    }

    private void Roll()
    {
        rb.position = new Vector3(0, 10, 0);

        float xDirection = Random.Range(-500, 250);
        float yDirection = Random.Range(-500, 500);
        float zDirection = Random.Range(-500, 500);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 100);
        rb.AddTorque(xDirection, yDirection, zDirection);
    }

    public Vector3 GetVelocity()
    {
        return diceVelocity;
    }
}
