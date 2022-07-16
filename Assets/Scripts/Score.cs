using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private GameObject goalUI;
    [SerializeField]
    private GameObject rolledUI;
    [SerializeField]
    private GameObject scoreUI;

    private int goalNumber;
    private List<int> badNumbers = new List<int>();
    private int score = 0;

    private void Start()
    {
        RandomGoal();
    }

    public void SetGoal(int goal)
    {
        if(goal<7&&goal>0)
        {
            goalNumber = goal;
        }
        else
        {
            goalNumber = 1;
        }
        goalUI.GetComponent<TextMeshProUGUI>().SetText(goalNumber.ToString());
    }
    public int GetGoal()
    {
        return goalNumber;
    }

    public void CompareGoal(int rolledNumber)
    {
        rolledUI.GetComponent<TextMeshProUGUI>().SetText(rolledNumber.ToString());
        if(rolledNumber==goalNumber)
        {
            goalNumber = 7; //Prevents multiple scoring until the goal number is changed
            AddScore();
        }
    }
    public void RandomGoal()
    {
        SetGoal(Random.Range(0, 6));
    }

    public void RandomBadNumber()
    {
        for(int y=0;y<20;y++) //Loop to try multiple times to get a new number. 
        {
            int x = Random.Range(0, 6);
            if (!badNumbers.Contains(x))
            {
                badNumbers.Add(Random.Range(0, 6));
                break;
            }
        }
    }

    public void ClearBadNumbers()
    {
        badNumbers.Clear();
    }

    public void AddScore()
    {
        score++;
        scoreUI.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
    }

    public void ClearScore()
    {
        score = 0;
        scoreUI.GetComponent<TextMeshProUGUI>().SetText(score.ToString());
    }
}
