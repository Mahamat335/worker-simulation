using UnityEngine;

public class townCenter : Building
{

    public override void BuildingClicked()
    {
        ClearSelectedBuildings();
        BuildingPanel.SetActive(true);
    }

}
