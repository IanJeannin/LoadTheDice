using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePhysics : MonoBehaviour
{
    [SerializeField]
    private Score score;

    private static Rigidbody rb;
    private Vector3 savedVelocity;
    private Vector3 savedAngularVelocity;
    private bool frozen=false;
    private Vector3 diceVelocity;
    private Vector3 nudgeForce = new Vector3(5, 5, 5);

    //public float power;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Roll();
    }

    private void Update()
    {
        diceVelocity = rb.velocity;

        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Roll();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Freeze();
        }
    }

    private void Roll()
    {
        rb.velocity = Vector3.zero;
        rb.position = new Vector3(0, 10, 0);

        float xDirection = Random.Range(-750, 750);
        float yDirection = Random.Range(-750, 750);
        float zDirection = Random.Range(-750, 750);
        transform.rotation = Quaternion.identity;
        rb.AddForce(transform.up * 100);
        rb.AddTorque(xDirection, yDirection, zDirection);

        score.RandomGoal();
    }

    public Vector3 GetVelocity()
    {
        return diceVelocity;
    }

    public void Nudge(Vector3 location,Vector3 force,float power)
    {
        Freeze();
        rb.AddForceAtPosition(force*-power, location, ForceMode.Impulse);
    }

    private void Freeze()
    {
        if(!frozen)
        {
            savedVelocity = rb.velocity;
            savedAngularVelocity = rb.angularVelocity;
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
            rb.AddForce(savedVelocity, ForceMode.VelocityChange);
            rb.AddTorque(savedAngularVelocity, ForceMode.VelocityChange);
        }
        frozen = !frozen;
    }
}
