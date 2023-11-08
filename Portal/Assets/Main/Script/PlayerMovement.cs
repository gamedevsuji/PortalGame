using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera Camera = null;
    private NavMeshAgent Agent;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float rayLength = 2;

    private RaycastHit[] Hits = new RaycastHit[1];


    [SerializeField]private GameObject clickParticlePrefab;

    private GameObject clickParticle;


    [SerializeField]private CinemachineFollowZoom cinemachineFollowZoom;

    private const float maxLerp = 60f;

    [SerializeField] private float scrollSpeed = 2f;

    [SerializeField] private DogAnimation dogAnimation;

    int groundLayer;


    private void Awake()
    {

        Debug.Log("Awakeee ");

        Agent = GetComponent<NavMeshAgent>();


    }

    private void Update()
    {



        if (InputController.instance.GetNavigate())
        {
            //Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Camera.ScreenToWorldPoint(Input.mousePosition), transform.forward, Color.green);

            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);


            CastRays.RayHitGround((hasHit, hitPos)=>{

                if(hasHit)
                {

                    if (clickParticle == null)
                    {
                        clickParticle = Instantiate(clickParticlePrefab);
                        clickParticle.transform.position = hitPos;

                    }
                    else
                    {
                        clickParticle.transform.position = hitPos;

                    }

                    Agent.SetDestination(hitPos);

                    dogAnimation.MoveDog();
                }
            });

        }


        if (!Agent.pathPending)
        {
            dogAnimation.StopDog();
        }

        if (InputController.instance.GetZoomIn() > 0)
        {

            cinemachineFollowZoom.m_MinFOV = Mathf.Lerp(cinemachineFollowZoom.m_MinFOV, 0, scrollSpeed * Time.deltaTime);
        }
        else if(InputController.instance.GetZoomOut() > 0)
        {
            cinemachineFollowZoom.m_MinFOV = Mathf.Lerp(cinemachineFollowZoom.m_MinFOV, maxLerp, scrollSpeed * Time.deltaTime);
        }




    }

    public void GoToPosition(Vector3 gotToPosition)
    {

        gameObject.SetActive(false);
        transform.position = gotToPosition;
        Agent.SetDestination(gotToPosition);

        gameObject.SetActive(true);


    }
}