using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private Material currentMat;
    public void CompareMaterialHeight(GameObject cuboid)
    {
        float topHeight = currentMat.GetFloat("TopHeight");
        float cuboidHeight = cuboid.transform.position.y;
        if(cuboidHeight > topHeight)
        {
            ChangeMaterial(cuboid);
        }
    }

    void ChangeMaterial(GameObject cuboid)
    {
        Material newMaterial = cuboid.GetComponent<MeshRenderer>().material;
        float curHeight = cuboid.transform.position.y - 0.5f;

        Color topColor = newMaterial.GetColor("Color_Top");

        newMaterial.SetFloat("BottomHeight", curHeight);
        newMaterial.SetFloat("TopHeight", curHeight + 5f);
        newMaterial.SetColor("Color_Bottom", topColor);
        newMaterial.SetColor("Color_Top", Random.ColorHSV());

        cuboid.GetComponent<MeshRenderer>().material = newMaterial;

        currentMat = newMaterial;
    }
}
