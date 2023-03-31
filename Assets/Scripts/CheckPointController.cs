using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
public static CheckPointController instance;
    public Vector3 spawnPoint;
    public CheckPoint [] checkpoints;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        checkpoints = FindObjectsOfType<CheckPoint>();

        spawnPoint = PlayerController.instance.transform.position;
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;

    }
}
