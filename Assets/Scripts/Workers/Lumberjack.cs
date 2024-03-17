using UnityEngine;

public class Lumberjack : Worker
{
    protected override void Start()
    {
        base.Start();
        workerType = WorkerType.Lumberjack;
    }
    public override void CollectResource()
    {
        Resource.Instance.AddLumberjack();
        isCollecting = true;
        StartCoroutine("CollectAnimation");
    }

    public override void StopCollecting()
    {
        isCollecting = false;
        Resource.Instance.RemoveLumberjack();
    }
}