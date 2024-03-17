using UnityEngine;

public class Researcher : Worker
{
    protected override void Start()
    {
        base.Start();
        workerType = WorkerType.Researcher;
    }
    public override void CollectResource()
    {
        Resource.Instance.AddResearcher();
        isCollecting = true;
        StartCoroutine("CollectAnimation");
    }

    public override void StopCollecting()
    {
        isCollecting = false;
        Resource.Instance.RemoveResearcher();
    }
}