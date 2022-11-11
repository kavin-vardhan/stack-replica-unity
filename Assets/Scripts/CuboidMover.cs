using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboidMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool canMove;
    private GameObject cuboidToMove;
    public Vector2 xExtents;

    private Vector3 startPos, targetPos;
    private float lerpAmount = 0;
    private float targetLerpAmount = 1;
    public void StartMovement(GameObject obj, GameObject prevObj)
    {
        lerpAmount = 0;
        cuboidToMove = obj;
        canMove = true;
        if (GameVariables.layerCount % 2 == 1)
        {
            startPos = new Vector3(xExtents.x, obj.transform.position.y, prevObj.transform.position.z);
            targetPos = new Vector3(xExtents.y, obj.transform.position.y, prevObj.transform.position.z);
        } else
        {
            startPos = new Vector3(prevObj.transform.position.x, obj.transform.position.y, xExtents.x);
            targetPos = new Vector3(prevObj.transform.position.x, obj.transform.position.y, xExtents.y);
        }
        obj.transform.position = startPos;
    }
        
    public void StopMovement()
    {
        canMove = false;
    }
    void FixedUpdate()
    {
        if(canMove && cuboidToMove != null)
        {
            
            lerpAmount = Mathf.MoveTowards(lerpAmount, targetLerpAmount, moveSpeed * Time.deltaTime);

            if (lerpAmount == 1) targetLerpAmount = 0;
            else if(lerpAmount == 0) targetLerpAmount = 1;
            cuboidToMove.transform.position = Vector3.Lerp(startPos, targetPos, lerpAmount);
        }
    }
}
