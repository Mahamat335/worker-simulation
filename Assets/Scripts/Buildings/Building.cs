using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    public GameObject BuildingPanel;
    public List<GameObject> Panels;
    public abstract void BuildingClicked();
    public void ClearSelectedBuildings()
    {

        foreach (GameObject go in Panels)
        {
            go.SetActive(false);
        }
    }
}
