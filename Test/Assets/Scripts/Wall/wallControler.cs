using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallControler : MonoBehaviour
{
    private bool gateState;
    private Vector3 firstPos;
    private Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        firstPos = transform.position;
        nextPos = transform.position + new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gateState)
        {
            var current = Vector3.MoveTowards(transform.position, nextPos, 10 * Time.deltaTime);
            transform.position = current;

        }
        else
        {
            var current = Vector3.MoveTowards(transform.position, firstPos, 10 * Time.deltaTime);
            transform.position = current;
        }
    }
    public void MoveGate(bool state)
    {
        if (state)
        {
            gateState = true;

        }
        else
        {
            gateState = false;
        }
    }
}
