using UnityEngine;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;
    public LayerMask clickable;
    public LayerMask ground;
    public LayerMask townCenter;
    public LayerMask observatory;
    void Start()
    {
        myCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject.transform.root.gameObject);
                }
                else
                {
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject.transform.root.gameObject);
                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeselectAll();
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, townCenter))
                    {
                        Debug.Log(hit.collider.gameObject.transform.parent.gameObject + "tc");
                        hit.collider.gameObject.transform.parent.gameObject.GetComponent<Building>().BuildingClicked();
                    }
                    else if (Physics.Raycast(ray, out hit, Mathf.Infinity, observatory))
                    {
                        Debug.Log(hit.collider.gameObject.transform.parent.gameObject + "obs");
                        hit.collider.gameObject.transform.parent.gameObject.GetComponent<Building>().BuildingClicked();
                    }
                }
            }
        }
    }
}
