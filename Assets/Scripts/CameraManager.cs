using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    bool moveCamera = false;
    public AnimationCurve movementEasing;
    public float cameraMoveSpeed = 0.5f;
    Vector3 startPos, endPos;
    float lerpFactor;
    public void UpdateCamera()
    {
        moveCamera = true;
        startPos = transform.position;
        endPos = transform.position + Vector3.up * 0.5f;
        lerpFactor = 0;

    }
    private void FixedUpdate()
    {
        if(moveCamera)
        {
            lerpFactor = Mathf.MoveTowards(lerpFactor, 1, cameraMoveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(startPos, endPos, movementEasing.Evaluate(lerpFactor));
            if (lerpFactor >= 1) moveCamera = false;
        }
    }
}
