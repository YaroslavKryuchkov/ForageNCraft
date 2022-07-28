using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private float coeff;
    [SerializeField]
    private float activateTime;
    [SerializeField]
    private float duration;
    [SerializeField]
    private LayerMask mask;

    void OnTriggerEnter(Collider coll)
    {
        PlayerMovement pm = coll.gameObject.GetComponent<PlayerMovement>();
        if(pm != null)
        {
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(activateTime);
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, range, Vector3.up, 0.0f);
        foreach (var hit in hits)
        {
            PlayerMovement pm = hit.collider.gameObject.GetComponent<PlayerMovement>();
            if(pm != null)
            {
                pm.ChangeSpeed(coeff, duration);
            }
        }
        Destroy(this.gameObject);
    }
}