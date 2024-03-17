using UnityEngine;

public class WorkerFactory : MonoBehaviour
{
    public GameObject idlePrefab;
    public GameObject farmerPrefab;
    public GameObject minerPrefab;
    public GameObject researcherPrefab;
    public GameObject lumberjackPrefab;
    public static WorkerFactory _instance;
    public static WorkerFactory Instance { get { return _instance; } }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void CreateWorker(Worker.WorkerType workerType, GameObject go)
    {
        switch (workerType)
        {
            case Worker.WorkerType.Farmer:
                Instantiate(farmerPrefab, go.transform.position, go.transform.rotation);
                break;
            case Worker.WorkerType.Miner:
                Instantiate(minerPrefab, go.transform.position, go.transform.rotation);
                break;
            case Worker.WorkerType.Researcher:
                Instantiate(researcherPrefab, go.transform.position, go.transform.rotation);
                break;
            case Worker.WorkerType.Lumberjack:
                Instantiate(lumberjackPrefab, go.transform.position, go.transform.rotation);
                break;
            case Worker.WorkerType.Idle:
                Instantiate(idlePrefab, go.transform.position, go.transform.rotation);
                break;
        }
    }
}
