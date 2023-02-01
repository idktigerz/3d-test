using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class PlayerActions : MonoBehaviour
{
    public GameObject coin;
    public Transform cam;
    public float playerActivateDistance;
    public Text coinText;
    public Text hintText;
    bool active = false;
    int coinCounter = 0;

    string[] tags = { "Ground", "Wall" };
    private Material coinColor;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coinCounter;
        coinColor = coin.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    { 
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        if (active && (!hit.collider.CompareTag("Ground") && (!hit.collider.CompareTag("Wall")) && (!hit.collider.CompareTag("throwableObject"))))
        {
            hintText.enabled = true;
            if (hit.collider.CompareTag("Coin")){
                coinColor.color = Color.yellow;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Catch");
                    coin.SetActive(false);
                    StartCoroutine(Timer());
                    coinCounter++;
                    coinText.text = "Coins: " + coinCounter;
                }
            }
        }
        else
        {
            coinColor.color = Color.white;
            hintText.enabled = false;
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        coin.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            hintText.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                coinCounter++;
                Debug.Log(coinCounter);
                coinText.text = "Coins: " + coinCounter;
            }
        }
    }
}
