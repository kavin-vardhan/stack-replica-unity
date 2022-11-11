using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{
    public static int layerCount = 1;
    public static MoveDirection currentMoveDirection = MoveDirection.x;

    public static void Reset()
    {
        layerCount = 1;
    }
}


public enum MoveDirection
{
    x,
    z
}