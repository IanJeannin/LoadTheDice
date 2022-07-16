using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    [SerializeField]
    private GameObject die;
    [SerializeField]
    private int numberOfDice;

    private Vector3 launchDirection;
    private Vector3 startLocation;
    private float launchPower;
    private bool startedLaunch=false;
    private GameObject launchedDice;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartLaunch();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Sling();
        }
    }

    private void StartLaunch()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (startedLaunch==false)
        {
            startedLaunch = true;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Launch>())
                {
                    startLocation = hit.point;
                }
                launchedDice = Instantiate(die);
                launchedDice.transform.position = startLocation;
            }
        }
        Physics.Raycast(ray, out hit);
        launchDirection = (hit.point - startLocation) * -1;
        launchPower = Vector3.Distance(hit.point, startLocation);
    }

    private void Sling()
    {
        //launchedDice.GetComponent<Rigidbody>().isKinematic = false;
        //launchedDice.GetComponent<Rigidbody>().AddForce(launchDirection*launchPower, ForceMode.Impulse);
        launchedDice.GetComponent<DiePhysics>().Roll(launchDirection*launchPower);
        startedLaunch = false;
    }
}
