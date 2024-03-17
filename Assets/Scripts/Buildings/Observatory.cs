using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Observatory : Building
{
    public override void BuildingClicked()
    {

        ClearSelectedBuildings();
        BuildingPanel.SetActive(true);

    }
}
