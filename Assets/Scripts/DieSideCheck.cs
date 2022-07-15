using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSideCheck : MonoBehaviour
{
    private int value;
    private Vector3 DiceVelocity;

    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponentInParent<DiePhysics>())
        {
            DiceVelocity = other.GetComponentInParent<DiePhysics>().GetVelocity();
            if(DiceVelocity.x==0f&&DiceVelocity.y==0f&&DiceVelocity.z==0f)
            {
                //Switch statement did not work for some reason. So we get ugly stacked if statements. 
                if(other.gameObject.name=="Side1")
                {
                    Debug.Log("Landed on 6");
                }
                else if(other.gameObject.name=="Side2")
                {
                    Debug.Log("Landed on 5");
                }
                else if (other.gameObject.name == "Side3")
                {
                    Debug.Log("Landed on 4");
                }
                else if (other.gameObject.name == "Side4")
                {
                    Debug.Log("Landed on 3");
                }
                else if (other.gameObject.name == "Side5")
                {
                    Debug.Log("Landed on 2");
                }
                else if (other.gameObject.name == "Side6")
                {
                    Debug.Log("Landed on 1");
                }
            }
        }
    }

}
