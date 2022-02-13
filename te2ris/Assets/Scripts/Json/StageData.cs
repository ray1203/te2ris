using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StageData
{
    public int[] clearAmount;
    public TimeLimit[] timeLimits;
    public StageData() { 
        clearAmount = new int[10];
        timeLimits = new TimeLimit[10];
    }
    public StageData(int[] clearAmount, TimeLimit[] timeLimits)
    {
        this.clearAmount = clearAmount;
        this.timeLimits = timeLimits;
    }
    
    public void print()
    {
        Debug.Log(clearAmount);
    }
}