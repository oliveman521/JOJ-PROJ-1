using UnityEngine;

using Pathfinding;

public class Ghost : MonoBehaviour
{
    public float speed = 3;


    //Pathfinding
    [HideInInspector] public Vector2 targetPt;
    float repathPeriod = .5f;
    float nextWaypointDist = 2f; //distance to next waypoint before we move onto the next one
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;


    //References
    GameObject player;
    Seeker seeker;
    Rigidbody2D rb;

    public virtual void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InitiatePathfinding();
    }

    // Update is called once per frame
    void Update()
    {
        targetPt = player.transform.position;
        Debug.Log(GetPathDirection());
        rb.velocity = GetPathDirection() * speed;
        
    }

    public void InitiatePathfinding()
    {
        InvokeRepeating("UpdatePath", 0, repathPeriod);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, targetPt, OnPathComplete);
    }
    void OnPathComplete(Path path)
    {
        if(path.error) { return; }
        this.path = path;
        currentWaypoint = 0;
    }
    public Vector2 GetPathDirection()
    {
        Debug.Log("1");
        if(path == null) { return Vector2.zero; }
        Debug.Log("2");
        //Advance to next waypoint if we're there
        Vector2 nextWaypoint = (Vector2)path.vectorPath[currentWaypoint] - rb.position;
        if (nextWaypoint.magnitude < nextWaypointDist)
        {
            currentWaypoint++;
            nextWaypoint = (Vector2)path.vectorPath[currentWaypoint] - rb.position;
        }

        //if we've finished path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return Vector2.zero;
        }
        else
        {
             reachedEndOfPath = false;
        }
        Debug.Log("3");
        return nextWaypoint.normalized;
    }
}
