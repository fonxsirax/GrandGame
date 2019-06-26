using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCameraTargets : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;
    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }
    public void Move() {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, 0.9f);

    }
    public void Zoom() {
        float newZoom = Mathf.Lerp(maxZoom,minZoom, GetGreatestDistance()/zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);


    }
    public float GetGreatestDistance() {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }
    public Vector3 GetCenterPoint()
    {

        if (targets.Count == 1) {
            return targets[0].position;
        }
        ///
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        //a bound is a square that encapsulate all targets.
        return bounds.center; //The center or this square that encapsulate all targets
    }
}
