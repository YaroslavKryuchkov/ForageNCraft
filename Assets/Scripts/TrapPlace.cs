using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TrapType
{
    Slow,
    Stop,
    NumberOfTraps
}

public class TrapPlace : MonoBehaviour
{
    [SerializeField]
    private GameObject trapPlace;
    [SerializeField]
    private LayerMask placebleLayers;
    [SerializeField]
    private GameObject[] traps;
    
    [SerializeField]
    private TrapsManager tm;

    private bool isPlacing = false;
    private TrapType currentTrapType;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isPlacing = !isPlacing;
            trapPlace.SetActive(isPlacing);
        }
        if(isPlacing)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.forward * 2.0f, 
                              -transform.up, out hit, 1.0f, placebleLayers))
            {
                trapPlace.transform.position = hit.point;
            }
            if(Input.GetKeyDown(KeyCode.X))
            {
                currentTrapType++;
                if (currentTrapType == TrapType.NumberOfTraps)
                    currentTrapType = 0;
            }
            if(Input.GetMouseButtonDown(0) && TrapsManager.trapCount[(int)currentTrapType] > 0)
            {
                TrapsManager.trapCount[(int)currentTrapType]--;
                tm.ChangeText();
                Object.Instantiate(traps[(int)currentTrapType], trapPlace.transform.position, Quaternion.identity);
            }
        }
    }
}
