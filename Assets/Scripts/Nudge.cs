using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nudge : MonoBehaviour
{
    bool frozen = false;
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
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        hit.collider.gameObject.GetComponent<DiePhysics>().Nudge(hit.point,hit.normal);
                        Freeze();
                    }
                }
            }
        }
    }

    private void Freeze()
    {
            frozen = !frozen;
    }
}
