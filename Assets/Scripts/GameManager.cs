using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraManager cameraManager;
    [HideInInspector] public CuboidSpawner spawner;
    [HideInInspector] public CuboidMover mover;
    [HideInInspector] public CuboidSplitter splitter;
    [HideInInspector] public MaterialManager materialManager;
    [HideInInspector] public GameObject currentCuboid;
    public GameObject prevCuboid;
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        spawner = GetComponent<CuboidSpawner>();
        mover = GetComponent<CuboidMover>();
        splitter = GetComponent<CuboidSplitter>();
        materialManager = GetComponent<MaterialManager>();
        SpawnCuboid();
    }
    private void ClickAction()
    {
        var tempGo = prevCuboid;
        prevCuboid = splitter.SplitCuboid(prevCuboid, currentCuboid);
        if(tempGo == prevCuboid)
        {
            return;
        }

        mover.StopMovement();

        SpawnCuboid();
        materialManager.CompareMaterialHeight(currentCuboid);
        cameraManager.UpdateCamera();
    }

    private void SpawnCuboid()
    {
        currentCuboid = spawner.SpawnCuboid(prevCuboid);
        GameVariables.layerCount++;
        mover.StartMovement(currentCuboid, prevCuboid);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClickAction();
        }
    }
}
