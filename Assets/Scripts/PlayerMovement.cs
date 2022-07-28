using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angleSpeed;

    private float coeff = 1.0f;

    private Coroutine coroutine;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        TrapsManager.OnCraftBegin += StopMove;
        TrapsManager.OnCraftEnd += StartMove;
    }

    void FixedUpdate()
    {
        Vector3 moveVector = speed * Time.deltaTime * coeff * 
                             (transform.InverseTransformVector(transform.forward) * Input.GetAxis("Vertical") + 
                              transform.InverseTransformVector(transform.right) * Input.GetAxis("Horizontal")) ;
        this.transform.Translate(moveVector);

        this.transform.Rotate(transform.up, Input.GetAxis("Mouse X") * angleSpeed, Space.Self);
        //this.transform.Rotate(transform.right, Input.GetAxis("Mouse Y") * angleSpeed, Space.Self);
    }

    public void StopMove()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        this.enabled = false;
    }

    public void StartMove()
    {
        this.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChangeSpeed(float how, float time)
    {
        if(coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(SpeedChange(how, time));
    }

    IEnumerator SpeedChange(float how, float time)
    {
        coeff = how;
        yield return new WaitForSeconds(time);
        coeff = 1.0f;
    }
}