using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Nudge : MonoBehaviour
{
    [SerializeField]
    Slider powerSlider;
    [SerializeField]
    private float maxPower;

    private float power;
    private float startingMouseX;
    private RaycastHit nudgeLocation;
    bool frozen = false;
    bool slidingPower = false;

    private void Start()
    {
        powerSlider.maxValue = maxPower;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Freeze();
        }
        if(frozen)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<DiePhysics>())
                {
                    Debug.DrawLine(new Vector3(0, 0, 0), hit.point, Color.blue, 0f);
                    Debug.DrawLine(hit.point+hit.normal, hit.point, Color.red, 0f);
                    if(Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        nudgeLocation = hit;
                        SlidePower();
                    }
                }
            }
            if(slidingPower)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    power = (Input.mousePosition.x - startingMouseX)/3;
                    Debug.Log(power);
                    if(power>maxPower)
                    {
                        power = maxPower;
                    }
                    else if(power<1)
                    {
                        power = 1;
                    }
                    powerSlider.value = power;
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    nudgeLocation.collider.gameObject.GetComponent<DiePhysics>().Nudge(nudgeLocation.point, nudgeLocation.normal,power);
                    slidingPower = false;
                    powerSlider.value = 0;
                    Freeze();
                }
            }
        }
    }

    private void Freeze()
    {
            frozen = !frozen;
    }

    private void SlidePower()
    {
        if (slidingPower == false)
        {
            slidingPower = true;
            startingMouseX = Input.mousePosition.x;
        }
    }
}
