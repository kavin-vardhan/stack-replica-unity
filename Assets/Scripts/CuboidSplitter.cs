using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboidSplitter : MonoBehaviour
{
    public GameObject SplitCuboid(GameObject prevCuboid, GameObject currentCuboid)
    {
        Vector3 initSpawnPos = new Vector3(1000, currentCuboid.transform.position.y, 1000);
        float prevCuboidPos, curCuboidPos, prevCuboidScale, curCuboidScale;
        
        if (GameVariables.layerCount % 2 == 0)
        {
            prevCuboidPos = prevCuboid.transform.position.z;
            curCuboidPos = currentCuboid.transform.position.z;
            prevCuboidScale = prevCuboid.transform.localScale.z;
            curCuboidScale = currentCuboid.transform.localScale.z;
        }
        else
        {
            prevCuboidPos = prevCuboid.transform.position.x;
            curCuboidPos = currentCuboid.transform.position.x;
            prevCuboidScale = prevCuboid.transform.localScale.x;
            curCuboidScale = currentCuboid.transform.localScale.x;
        }


        if (Mathf.Abs(currentCuboid.transform.position.x - prevCuboid.transform.position.x) > prevCuboid.transform.localScale.x)
            return prevCuboid;

        float positionOffset = curCuboidPos - prevCuboidPos;
        float newScale = prevCuboidScale - Mathf.Abs(positionOffset);
        float newPos = curCuboidPos - positionOffset / 2;
        if (GameVariables.layerCount % 2 == 0)
        {
            currentCuboid.transform.localScale = new Vector3(currentCuboid.transform.localScale.x, currentCuboid.transform.localScale.y, newScale);
            currentCuboid.transform.position = new Vector3(currentCuboid.transform.position.x, currentCuboid.transform.position.y, newPos);
        } else
        {
            currentCuboid.transform.localScale = new Vector3(newScale, currentCuboid.transform.localScale.y, currentCuboid.transform.localScale.z);
            currentCuboid.transform.position = new Vector3(newPos, currentCuboid.transform.position.y, currentCuboid.transform.position.z);
        }

        float splitCuboidScale = Mathf.Abs(positionOffset);
        float splitCuboidPos = prevCuboidPos + Mathf.Sign(positionOffset) * (prevCuboidScale / 2 + splitCuboidScale / 2);
        var splitCuboid = Instantiate(currentCuboid, initSpawnPos, Quaternion.identity);

        if (GameVariables.layerCount % 2 == 0)
        {
            splitCuboid.transform.position = new Vector3(currentCuboid.transform.position.x, currentCuboid.transform.position.y, splitCuboidPos);
            splitCuboid.transform.localScale = new Vector3(currentCuboid.transform.localScale.x, currentCuboid.transform.localScale.y, splitCuboidScale);
        } else
        {
            splitCuboid.transform.position = new Vector3(splitCuboidPos, currentCuboid.transform.position.y, currentCuboid.transform.position.z);
            splitCuboid.transform.localScale = new Vector3(splitCuboidScale, currentCuboid.transform.localScale.y, currentCuboid.transform.localScale.z);
        }

        splitCuboid.AddComponent<Rigidbody>();

        return currentCuboid;
    }
}
