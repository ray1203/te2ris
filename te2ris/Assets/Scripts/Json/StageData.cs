using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StageData
{
    public int[] clearAmount;
    public StageData() { 
        clearAmount = new int[10];
    }
    public StageData(int[] clearAmount)
    {
        this.clearAmount = clearAmount;
    }
    
    public void print()
    {
        Debug.Log(clearAmount);
    }
}