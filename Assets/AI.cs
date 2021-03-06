using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class AI : MonoBehaviour
{
    protected GameObject[] Players;
    protected NavMeshAgent agent;
    public Collider navCollider;
    public int index;

    public float rePathRate;
    public LayerMask playerLayer;
    public Transform target;

    public int damage = 5;

    public GameObject explosionPS;
    // Use this for initialization
    protected virtual void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");


        agent = GetComponent<NavMeshAgent>();

        InvokeRepeating("TryGetPlayer",0,0.25f);

    }
    void TryGetPlayer()
    {
        if (GetClosestPlayer() == null)
            return;

        target = GetClosestPlayer().transform;
    }
    protected abstract void UpdatePath();

    protected GameObject GetClosestPlayer()
    {
        float distance = 10000;
        GameObject playerToChaise = null;
        foreach (var player in Players)
        {
            var newDistance = Vector3.Distance(player.transform.position, transform.position);

            if(newDistance < distance)
            {
                distance = newDistance;
                playerToChaise = player;
            }

        }
        return playerToChaise;
    }

    #region Wander

    protected bool isForcingRepath;
    protected Vector3 Destination { get; set; }
    protected Vector3 GetPointToGo()
    {
        Vector3 pointPos = Utils.RandomPointInBounds(navCollider.bounds);
        pointPos.z = 0;
        return pointPos;
    }

    protected bool isPathDone()
    {
        if (Vector3.Distance(transform.position, Destination) < 2f)
        {
            return true;
        }

        return false;
    }

    protected IEnumerator ForceRepath()
    {

        yield return new WaitForSeconds(rePathRate);

        isForcingRepath = false;

        if (agent.velocity != Vector3.zero)
            yield break;

        UpdatePath();
    }
    #endregion


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && collision.transform.GetComponent<PlayerMover>().playerIndex == index)
        {
            if (PlayerHealthHandler.GetInstance() != null)
                PlayerHealthHandler.GetInstance().TakeDamage(damage);

            StartDeathCycle();
        }

    }


    public virtual void StartDeathCycle()
    {
        GameObject PS = null;
        if (explosionPS != null)
        {
           PS = Instantiate(explosionPS, transform.position, Quaternion.identity);
        }
        if (CameraController.GetInstance() != null)
            CameraController.GetInstance().StartShakeG(0.1f, 0.1f);
        gameObject.SetActive(false);

        if (PS != null)
            Destroy(PS, 1f);

        Destroy(gameObject, 2f);
           
    }


}
