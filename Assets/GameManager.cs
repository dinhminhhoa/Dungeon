using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : BaseManager<GameManager>
{
    private int Gold = 0;
    public int Goldd => Goldd;

    public void UpdateGold(int v)
    {
        Gold = v;
    }
}
