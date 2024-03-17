using UnityEngine;
public class Idle : Worker
{

    protected override void Start()
    {
        workerType = WorkerType.Idle;
    }
    public void FirstAssignment(WorkerType workerType)
    {
        ChangeRole(workerType);
    }

    public override void CollectResource()
    {
    }
    public override void StopCollecting()
    {
    }
}