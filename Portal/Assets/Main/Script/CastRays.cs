using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CastRays 
{

    private static RaycastHit[] Hits = new RaycastHit[1];

    [SerializeField] private static LayerMask layerMask = LayerMask.GetMask("Ground");

    private static int groundLayer;


    public static void RayHitGround(Action<bool,Vector3> callback)
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.RaycastNonAlloc(ray, Hits) > 0)
        {
            foreach (var hit in Hits)
            {
                groundLayer = 1 << hit.transform.gameObject.layer;

                if (groundLayer == layerMask.value)
                {
                     callback(true,hit.point);
                }
            }

        }
    }
}
