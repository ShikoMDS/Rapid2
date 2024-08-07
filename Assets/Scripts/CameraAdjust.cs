using UnityEngine;
using Cinemachine;
using System.Collections.Generic;

public class CameraAdjust : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;
    public float cameraYOffset;  // The camera Y offset when in this trigger zone
    public float transitionStartDuration = 0.5f; // Duration for starting the transition
    public float transitionFinishDuration = 1f;  // Duration for finishing the transition

    private float originalYOffset;
    private CinemachineCameraOffset cameraOffset;
    private List<CameraAdjust> activeTriggers = new List<CameraAdjust>();
    private bool isTransitioning = false;
    private float targetYOffset;
    private float transitionStartTime;
    private float currentYOffset;
    private float transitionDuration;

    void Start()
    {
        if (cinemachineCamera == null)
        {
            Debug.LogError("Cinemachine Virtual Camera is not assigned.");
            return;
        }

        cameraOffset = cinemachineCamera.GetComponent<CinemachineCameraOffset>();
        if (cameraOffset != null)
        {
            originalYOffset = cameraOffset.m_Offset.y;
            currentYOffset = originalYOffset;
            targetYOffset = originalYOffset;
            Debug.Log("Original Y Offset: " + originalYOffset);
        }
        else
        {
            Debug.LogError("CinemachineCameraOffset component is not found on the assigned Cinemachine Virtual Camera.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!activeTriggers.Contains(this))
            {
                activeTriggers.Add(this);
            }
            Debug.Log("Player entered trigger zone: " + gameObject.name);
            StartTransition(GetCurrentTargetYOffset(), transitionStartDuration);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (activeTriggers.Contains(this))
            {
                activeTriggers.Remove(this);
            }
            Debug.Log("Player exited trigger zone: " + gameObject.name);

            // Only start transition if there are no more active triggers
            if (activeTriggers.Count == 0)
            {
                StartTransition(originalYOffset, transitionFinishDuration);
            }
            else
            {
                StartTransition(GetCurrentTargetYOffset(), transitionFinishDuration);
            }
        }
    }

    float GetCurrentTargetYOffset()
    {
        if (activeTriggers.Count > 0)
        {
            return activeTriggers[activeTriggers.Count - 1].cameraYOffset;
        }
        else
        {
            return originalYOffset;
        }
    }

    void StartTransition(float newYOffset, float duration)
    {
        targetYOffset = newYOffset;
        transitionStartTime = Time.time;
        transitionDuration = duration;
        isTransitioning = true;
    }

    void Update()
    {
        if (isTransitioning)
        {
            float elapsedTime = Time.time - transitionStartTime;
            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            currentYOffset = Mathf.Lerp(currentYOffset, targetYOffset, t);
            Vector3 currentOffset = cameraOffset.m_Offset;
            cameraOffset.m_Offset = new Vector3(currentOffset.x, currentYOffset, currentOffset.z);

            if (t >= 1f)
            {
                isTransitioning = false;
                Debug.Log($"Transition complete. New Y Offset: {targetYOffset}");
            }
        }
    }
}
