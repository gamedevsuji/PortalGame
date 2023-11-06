using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update

    private PlacePortals placePortals;

    private static bool lockPortal;

    public bool fromPortal;

    private void OnTriggerEnter(Collider other)
    {

        PlayerMovement player = other.GetComponent<PlayerMovement>();


        if (player != null)
        {

            Debug.Log("Player Found "+lockPortal);

            if (placePortals.cubesExhausted && !lockPortal)
            {
                for (int i = 0; i < placePortals.portalClones.Length; i++)
                {

                    Debug.Log("portal clones "+i);

                    if (placePortals.portalClones[i].gameObject == this.gameObject)
                    {
                        Debug.Log("My portal found");

                        if (i == 0)
                        {
                            lockPortal = true;
                            fromPortal = true;

                            player.GoToPosition(placePortals.portalClones[1].gameObject.transform.position);
                        }
                        else
                        {
                            lockPortal = true;

                            fromPortal = true;

                            player.GoToPosition(placePortals.portalClones[0].gameObject.transform.position);

                        }
                    }
                }
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();


        if (player != null && !fromPortal)
        {
            lockPortal = false;

            for (int i = 0; i < placePortals.portalClones.Length; i++)
            {
                placePortals.portalClones[i].fromPortal = false;
            }
        }
    }



    public void EnablePortal(Vector3 position, PlacePortals portalManager)
    {

        placePortals ??= portalManager;
        transform.position = position;
        gameObject.SetActive(true);

     
    }

    public void DisablePortal()
    {
        fromPortal = false;
        lockPortal = false;
        gameObject.SetActive(false);
    }
}
