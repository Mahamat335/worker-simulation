

using System.Collections;
using UnityEngine;

public class Farmer : Worker
{
    protected override void Start()
    {
        base.Start();
        workerType = WorkerType.Farmer;
    }
    public override void CollectResource()
    {
        Resource.Instance.AddFarmer();
        isCollecting = true;
        StartCoroutine("CollectAnimation");
    }

    public override void StopCollecting()
    {
        isCollecting = false;
        Resource.Instance.RemoveFarmer();
    }
}