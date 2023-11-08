using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePortals : MonoBehaviour
{
    public Portal portalPrefab;

    private Camera camera = null;

    private RaycastHit[] Hits = new RaycastHit[1];

    [HideInInspector]public Portal[] portalClones = new Portal[2];

    private int currentCubeIndex;

    public bool cubesExhausted =false;

    private bool clicked = true;

    private readonly float timeLimit = 10f;

    private float currentTime;

    private bool startTime = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        for (int i = 0; i < portalClones.Length; i++)
        {
          Portal portal =  Instantiate(portalPrefab);
          portal.DisablePortal();
          portalClones[i] = portal;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(currentTime < timeLimit && startTime)
        {
            currentTime += Time.deltaTime;
        }
        else if(startTime)
        {
            currentCubeIndex = 0;
            startTime = false;
            currentTime = 0;
            DisableBothCubes();
        }


        
     
        if (InputController.instance.GetCubePlacement() && !clicked && !cubesExhausted)
        {
            clicked = true;




            CastRays.RayHitGround((hasHit, hitPos) =>
            {
                if (hasHit)
                {
                    portalClones[currentCubeIndex].EnablePortal(hitPos, this);
                    if (portalClones.Length > currentCubeIndex + 1)
                    {
                        ++currentCubeIndex;
                    }
                    else
                    {
                        cubesExhausted = true;
                        startTime = true;
                    }
                }
            });


            //   Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            //if (Physics.RaycastNonAlloc(ray, Hits) > 0)
            //{
            //    Debug.Log("portal length " + portalClones.Length+ " currentCubeIndex "+ currentCubeIndex);

            //        portalClones[currentCubeIndex].EnablePortal(Hits[0].point,this);
            //    if (portalClones.Length > currentCubeIndex + 1)
            //    {
            //        ++currentCubeIndex;
            //    }
            //    else
            //    {
            //        cubesExhausted = true;
            //        startTime = true;
            //    }
            //}

        }
        else if(!InputController.instance.GetCubePlacement())
        {
            clicked = false;

        }
    }


    private void DisableBothCubes()
    {
        for (int i = 0; i < portalClones.Length; i++)
        {
            portalClones[i].DisablePortal();
        }

        cubesExhausted = false;
    }
}
