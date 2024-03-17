using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();
    public static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }
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

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<UnitMovement>().enabled = true;
    }
    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (unitsSelected.Contains(unitToAdd))
        {
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitsSelected.Remove(unitToAdd);
        }
        else
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }

    }
    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }
    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear();
    }
    public void Deselect(GameObject unitToDeselect)
    {
        unitToDeselect.GetComponent<UnitMovement>().enabled = false;
        unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
        unitsSelected.Remove(unitToDeselect);

    }
}
