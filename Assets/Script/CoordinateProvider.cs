using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

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
        var cameraTransform = _camera.transform;
        var cameraPosition = cameraTransform.position;

        var lowerLeft = _camera.ViewportToWorldPoint(Vector3.zero);
        var upperRight = _camera.ViewportToWorldPoint(Vector3.one);
        var maxR = (lowerLeft - cameraPosition).magnitude > (upperRight - cameraPosition).magnitude
            ? lowerLeft
            : upperRight;

        var radius = maxR - cameraPosition;
        var magnitude = radius.magnitude;

        var direction = Random.insideUnitCircle.normalized;

        var newPosition = direction * (magnitude + 1);
        return newPosition;
    }

    public bool OnScreen(Vector3 parentPosition)
    {
        var lowerLeft = _camera.ViewportToWorldPoint(Vector3.zero);
        var upperRight = _camera.ViewportToWorldPoint(Vector3.one);

        return parentPosition.x > lowerLeft.x && parentPosition.x < upperRight.x
                                              && parentPosition.y > lowerLeft.y && parentPosition.y < upperRight.y;
    }

    public Vector3 GetEdgeScreenLocaiton(Vector3 transformPosition)
    {
        var lowerLeft = _camera.ViewportToWorldPoint(Vector3.zero);
        var upperRight = _camera.ViewportToWorldPoint(Vector3.one);

        if (transformPosition.y > upperRight.y)
        {
            transformPosition.y = math.min(transformPosition.y, upperRight.y);
        } else if (transformPosition.y < lowerLeft.y)
        {
            transformPosition.y = math.max(transformPosition.y, lowerLeft.y);
        }
        
        if (transformPosition.x > upperRight.x)
        {
            transformPosition.x = math.min(transformPosition.x, upperRight.x);
        } else if (transformPosition.x < lowerLeft.x)
        {
            transformPosition.x = math.max(transformPosition.x, lowerLeft.x);
        }
    

        return transformPosition;
    }
}
