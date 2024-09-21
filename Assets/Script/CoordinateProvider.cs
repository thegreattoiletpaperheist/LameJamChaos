using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateProvider : MonoBehaviour
{

    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        
    }
    public Vector3 GetCoordOutsideOfScreen()
    {
        var camera = Camera.main;
        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;

        var lowerLeft = camera.ViewportToWorldPoint(Vector3.zero);
        var upperRight = camera.ViewportToWorldPoint(Vector3.one);
        var maxR = (lowerLeft - cameraPosition).magnitude > (upperRight - cameraPosition).magnitude
            ? lowerLeft
            : upperRight;

        var radius = maxR - cameraPosition;
        var magnitude = radius.magnitude;

        var direction = Random.insideUnitCircle.normalized;

        var newPosition = direction * (magnitude + 1);
        return newPosition;
    }
}
