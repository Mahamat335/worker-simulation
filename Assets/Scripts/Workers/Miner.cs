using UnityEngine;

public class Miner : Worker
{
    protected override void Start()
    {
        base.Start();
        workerType = WorkerType.Miner;
    }
    public override void CollectResource()
    {
        Resource.Instance.AddMiner();
        isCollecting = true;
        StartCoroutine("CollectAnimation");
    }

    public override void StopCollecting()
    {
        isCollecting = false;
        Resource.Instance.RemoveMiner();
    }
}