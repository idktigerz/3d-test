using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeverActions : MonoBehaviour
{
    [SerializeField] Transform Wall;
    private bool canInteract;
    private Material leverColor;
    private bool leverState;
    // Start is called before the first frame update
    void Start()
    {
        leverColor = GetComponent<Renderer>().material;
        leverState = false;
    }
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if (leverState)
            {
                leverColor.color = Color.green;
                Vector3.MoveTowards(Wall.position, new Vector3(-4.6595f, 4.05f, -7.7079f), 10 * Time.deltaTime);
                leverState = false;
            }
            else
            {
                leverColor.color = Color.red;
                Vector3.MoveTowards(Wall.position, new Vector3(-4.6595f, 0, -7.7079f), 10 * Time.deltaTime);
                leverState = true;
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
        }

    }
}
