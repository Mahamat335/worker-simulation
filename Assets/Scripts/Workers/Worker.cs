using System.Collections;
using UnityEngine;

public abstract class Worker : MonoBehaviour
{
    protected float detectionRadius = 5f;
    protected float minTimeToChangeRole = 10f;
    protected float maxTimeToChangeRole = 20f;
    public float collectRate;
    public Transform hand;
    protected bool isCollecting = false;
    public enum WorkerType
    {
        Farmer,
        Miner,
        Researcher,
        Lumberjack,
        Idle
    }
    public WorkerType workerType;
    protected virtual void Start()
    {
        Invoke("CheckForRoleChange", Random.Range(minTimeToChangeRole, maxTimeToChangeRole));
        InvokeRepeating("Eat", 2f, 2f);
        UpdateCollectRate();

    }

    protected void CheckForRoleChange()
    {
        ChangeRoleRandomly();
        Invoke("CheckForRoleChange", Random.Range(minTimeToChangeRole, maxTimeToChangeRole));
    }

    protected void ChangeRoleRandomly()
    {
        WorkerType randomType;
        do
        {
            randomType = (WorkerType)Random.Range(0, System.Enum.GetValues(typeof(WorkerType)).Length);
        } while (randomType == workerType || randomType == WorkerType.Idle);

        ChangeRole(randomType);
    }

    protected void ChangeRole(WorkerType newType)
    {
        if (isCollecting)
        {
            RemoveManually();
        }
        WorkerFactory.Instance.CreateWorker(newType, gameObject);
        Destroy(gameObject);
    }


    public abstract void CollectResource();
    public abstract void StopCollecting();

    protected void RemoveManually()
    {
        switch (workerType)
        {
            case WorkerType.Farmer:
                Resource.Instance.RemoveFarmer();
                break;
            case WorkerType.Miner:
                Resource.Instance.RemoveMiner();
                break;
            case WorkerType.Researcher:
                Resource.Instance.RemoveResearcher();
                break;
            case WorkerType.Lumberjack:
                Resource.Instance.RemoveLumberjack();
                break;
            default:
                break;
        }
    }
    protected void Eat()
    {
        Resource.Instance.Eat();
    }
    protected void OnDestroy()
    {
        UnitSelections.Instance.Deselect(gameObject);
    }
    public void UpdateCollectRate()
    {
        Research.Instance.GetCollectRate(workerType, ref collectRate);
    }
    protected IEnumerator CollectAnimation1()
    {
        float rotationSpeed = 135f;
        while (isCollecting)
        {
            while (hand.rotation.x < 90f)
            {
                hand.Rotate(Vector3.right * Time.fixedDeltaTime * rotationSpeed);
                yield return new WaitForFixedUpdate();
            }
            while (hand.rotation.x > 0f)
            {
                hand.Rotate(Vector3.left * Time.fixedDeltaTime * rotationSpeed);
                yield return new WaitForFixedUpdate();
            }
        }
    }
    protected IEnumerator CollectAnimation()
    {
        float rotationSpeed = 135f;

        while (isCollecting)
        {
            // El nesnesi hedef rotasyona ulaşana kadar döner

            Quaternion targetRotation = Quaternion.Euler(90f, 0f, 0f);
            while (Quaternion.Angle(hand.localRotation, targetRotation) > 0.01f)
            {
                hand.localRotation = Quaternion.RotateTowards(hand.localRotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
                yield return new WaitForFixedUpdate();
            }

            // Hedef rotasyona ulaşıldığında, hedef rotasyonu değiştirerek ters yöne döner
            targetRotation = Quaternion.Euler(0f, 0f, 0f);
            while (Quaternion.Angle(hand.localRotation, targetRotation) > 0.01f)
            {
                hand.localRotation = Quaternion.RotateTowards(hand.localRotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}