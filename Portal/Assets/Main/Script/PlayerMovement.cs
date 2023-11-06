using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera Camera = null;
    private NavMeshAgent Agent;

    private RaycastHit[] Hits = new RaycastHit[1];

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (InputController.instance.GetNavigate())
        {
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.RaycastNonAlloc(ray, Hits) > 0)
            {
                Agent.SetDestination(Hits[0].point);
            }
        }

        
    }

    public void GoToPosition(Vector3 gotToPosition)
    {

        transform.position = gotToPosition;
        Agent.SetDestination(gotToPosition);

    }
}