using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TimeLimit
{
    public int limit1, limit2, limit3;
    public TimeLimit() { }
    public TimeLimit(int l1,int l2,int l3)
    {
        limit1 = l1;
        limit2 = l2;
        limit3 = l3;
    }
}
