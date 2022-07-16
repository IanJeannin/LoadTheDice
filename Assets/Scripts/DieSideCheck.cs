using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSideCheck : MonoBehaviour
{
    [SerializeField]
    Score score;

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
                    value = 6;
                }
                else if(other.gameObject.name=="Side2")
                {
                    value = 5;
                }
                else if (other.gameObject.name == "Side3")
                {
                    value = 4;
                }
                else if (other.gameObject.name == "Side4")
                {
                    value = 3;
                }
                else if (other.gameObject.name == "Side5")
                {
                    value = 2;
                }
                else if (other.gameObject.name == "Side6")
                {
                    value = 1;
                }
                score.CompareGoal(value);
            }
        }
    }

}
