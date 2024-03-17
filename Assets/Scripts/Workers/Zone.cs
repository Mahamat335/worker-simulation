using System.Collections;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public Worker.WorkerType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Idle"))
        {
            StartCoroutine(IdleFirstAssignmentCoroutine(other.gameObject.GetComponent<Idle>()));
        }
        if (other.gameObject.CompareTag("Worker") && type == other.gameObject.GetComponent<Worker>().workerType)
        {
            other.gameObject.GetComponent<Worker>().CollectResource();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Worker") && type == other.gameObject.GetComponent<Worker>().workerType)
        {
            other.gameObject.GetComponent<Worker>().StopCollecting();
        }
    }

    private IEnumerator IdleFirstAssignmentCoroutine(Idle idleSc)
    {
        float currentTime = 0f;
        float targetTime = 1f;
        while (currentTime < targetTime)
        {
            currentTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        idleSc.FirstAssignment(type);
    }
}
