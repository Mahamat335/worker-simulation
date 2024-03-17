using TMPro;
using UnityEngine;

public class Research : MonoBehaviour
{
    public float woodCollectionRate = 10;
    public float foodCollectionRate = 10;
    public float goldCollectionRate = 10;
    public float researchCollectionRate = 10;
    public float goldPrice = 100;
    public float woodPrice = 100;
    public float foodPrice = 100;
    public float researchPrice = 100;
    public float priceMultiplier = 2;
    public float valueDelta = 5;
    public TMP_Text woodInfo;
    public TMP_Text goldInfo;
    public TMP_Text researchInfo;
    public TMP_Text foodInfo;
    public static Research _instance;
    public static Research Instance { get { return _instance; } }
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


    public void UpgradeWood()
    {
        if (Resource.Instance.research >= woodPrice)
        {
            Resource.Instance.SpendResearch(woodPrice);
            Upgrade(woodInfo, ref woodCollectionRate, ref woodPrice);
            Resource.Instance.woodCollectionRate = woodCollectionRate;
        }
    }

    public void UpgradeGold()
    {
        if (Resource.Instance.research >= goldPrice)
        {
            Resource.Instance.SpendResearch(goldPrice);
            Upgrade(goldInfo, ref goldCollectionRate, ref goldPrice);
            Resource.Instance.goldCollectionRate = goldCollectionRate;
        }
    }

    public void UpgradeFood()
    {
        if (Resource.Instance.research >= foodPrice)
        {
            Resource.Instance.SpendResearch(foodPrice);
            Upgrade(foodInfo, ref foodCollectionRate, ref foodPrice);
            Resource.Instance.foodCollectionRate = foodCollectionRate;
        }

    }

    public void UpgradeResearch()
    {
        if (Resource.Instance.research >= researchPrice)
        {
            Resource.Instance.SpendResearch(researchPrice);
            Upgrade(researchInfo, ref researchCollectionRate, ref researchPrice);
            Resource.Instance.researchCollectionRate = researchCollectionRate;
        }
    }
    private void Upgrade(TMP_Text info, ref float value, ref float price)
    {
        value += valueDelta;
        price *= priceMultiplier;
        info.text = "value: " + value + "\ncost: " + price;

        foreach (GameObject go in UnitSelections.Instance.unitList)
        {
            go.GetComponent<Worker>().UpdateCollectRate();
        }
    }
    public void GetCollectRate(Worker.WorkerType workerType, ref float collectRate)
    {
        switch (workerType)
        {
            case Worker.WorkerType.Farmer:
                collectRate = foodCollectionRate;
                break;
            case Worker.WorkerType.Miner:
                collectRate = goldCollectionRate;
                break;
            case Worker.WorkerType.Researcher:
                collectRate = researchCollectionRate;
                break;
            case Worker.WorkerType.Lumberjack:
                collectRate = woodCollectionRate;
                break;
            default:
                break;
        }
    }

}
