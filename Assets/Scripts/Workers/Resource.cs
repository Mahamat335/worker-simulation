using TMPro;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public float wood;
    public float gold;
    public float research;
    public float food;
    public float FoodConsumptionPerUnit = 10f;
    public float woodPerSecs = 0;
    public float goldPerSecs = 0;
    public float foodPerSecs = 0;
    public float researchPerSecs = 0;
    public float woodCollectionRate = 5;
    public float foodCollectionRate = 5;
    public float goldCollectionRate = 5;
    public float researchCollectionRate = 5;
    public TMP_Text woodInfo;
    public TMP_Text goldInfo;
    public TMP_Text researchInfo;
    public TMP_Text foodInfo;
    public GameObject endGame;
    public bool gameplay = true;
    public static Resource _instance;
    public static Resource Instance { get { return _instance; } }
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
        researchCollectionRate = Research.Instance.researchCollectionRate;
        goldCollectionRate = Research.Instance.goldCollectionRate;
        woodCollectionRate = Research.Instance.woodCollectionRate;
        foodCollectionRate = Research.Instance.foodCollectionRate;
        InvokeRepeating("Collect", 0f, 1f);
    }

    public void AddMiner()
    {
        goldPerSecs += goldCollectionRate;
    }
    public void AddResearcher()
    {
        researchPerSecs += researchCollectionRate;
    }
    public void AddFarmer()
    {
        foodPerSecs += foodCollectionRate;
    }
    public void AddLumberjack()
    {
        woodPerSecs += woodCollectionRate;
    }
    public void RemoveMiner()
    {
        goldPerSecs -= goldCollectionRate;
    }
    public void RemoveResearcher()
    {
        researchPerSecs -= researchCollectionRate;
    }
    public void RemoveFarmer()
    {
        foodPerSecs -= foodCollectionRate;
    }
    public void RemoveLumberjack()
    {
        woodPerSecs -= woodCollectionRate;
    }

    private void Collect()
    {
        if (gameplay)
        {

            wood += woodPerSecs;
            food += foodPerSecs;
            gold += goldPerSecs;
            research += researchPerSecs;
            foodInfo.text = food.ToString();
            woodInfo.text = wood.ToString();
            goldInfo.text = gold.ToString();
            researchInfo.text = research.ToString();
        }

    }
    public void Eat()
    {
        if (food >= FoodConsumptionPerUnit && gameplay)
        {
            SpendFood(FoodConsumptionPerUnit);
        }
        else
        {
            Debug.Log("Game Over");
            endGame.SetActive(true);
            gameplay = false;
        }
    }
    public void SpendWood(float spend)
    {
        wood -= spend;
        woodInfo.text = wood.ToString();
    }
    public void SpendFood(float spend)
    {
        food -= spend;
        foodInfo.text = food.ToString();
    }
    public void SpendGold(float spend)
    {
        gold -= spend;
        goldInfo.text = gold.ToString();
    }
    public void SpendResearch(float spend)
    {
        research -= spend;
        researchInfo.text = research.ToString();
    }

}
