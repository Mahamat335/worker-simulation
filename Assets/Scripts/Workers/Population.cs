using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Population : MonoBehaviour
{
    public GameObject spawnPoint;
    public float recruitmentCost = 100;
    public float construtionCost = 100;
    public float housePop = 5;
    public float currentPop = 5;
    public float maxPop;
    public TMP_Text popInfo;
    public static Population _instance;
    public static Population Instance { get { return _instance; } }
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
    void Start()
    {
        popInfo.text = currentPop + "/" + maxPop;
    }
    public void RecruitWorker()
    {
        if (Resource.Instance.gold >= recruitmentCost && currentPop < maxPop)
        {
            Resource.Instance.SpendGold(recruitmentCost);
            WorkerFactory.Instance.CreateWorker(Worker.WorkerType.Idle, spawnPoint);
            currentPop++;
            popInfo.text = currentPop + "/" + maxPop;
        }
    }
    public void ConstructHouse()
    {
        if (Resource.Instance.wood >= construtionCost)
        {
            Resource.Instance.SpendWood(construtionCost);
            maxPop += housePop;
            popInfo.text = currentPop + "/" + maxPop;
        }
    }
}
