using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaycastSphereAI : MonoBehaviour
{
    public LayerMask hitMask;
    public enum Type
    {
        SphereCast
    }

    public Type sensorType = Type.SphereCast;

    [Header("Sphere Settings")]
    public float sphereRadius;

    Transform CachedTransform;
    private int i = 0;

    public GameObject NPC;

    // Start is called before the first frame update
    void Start()
    {
        NPC = GameObject.FindGameObjectWithTag("NPC");
        CachedTransform = GetComponent<Transform>();
        NPC.SetActive(true);
    }

    public bool Hit { get; private set; }
    public RaycastHit info = new RaycastHit();

    public bool Scan()
    {
        Vector3 Direction = CachedTransform.forward;
        Collider[] Collisions;

        switch (sensorType)
        {
            case Type.SphereCast:
                Collisions = Physics.OverlapSphere(this.transform.position, sphereRadius, hitMask, QueryTriggerInteraction.Ignore);
                for (int i = 0; i < Collisions.Length; i++)
                    if (Collisions[i].tag == "NPC")
                    {
                        Hit = true;
                        if(Hit == true)
                        {
                            NPC.SetActive(false);
                        }
                        return true;
                    }
                    if (Collisions[i].tag != "NPC")
                    {
                        Hit = false;
                        if(Hit == false)
                        {
                            NPC.SetActive(true);
                        }
                        return true;
                    }
                break;
        }
        return false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if (CachedTransform == null)
        {
            CachedTransform = GetComponent<Transform>();
        }
        Scan();
        if (Hit) Gizmos.color = Color.red;
        Gizmos.matrix *= Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        switch (sensorType)
        {
            case Type.SphereCast:
                Gizmos.DrawWireSphere(Vector3.zero, sphereRadius);
                break;
        }
    }

    void Update()
    {
        OnDrawGizmos();
    }
}
