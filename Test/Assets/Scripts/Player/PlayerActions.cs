using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public GameObject coin;
    public Transform cam;
    public float playerActivateDistance;
    public Text coinText;
    public Text hintText;
    bool active = false;
    int coinCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coinCounter;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        if(Input.GetKeyDown(KeyCode.E) && active)
        {
            Debug.Log("Is active? " + active);
            if (hit.collider.CompareTag("Coin")){
                Debug.Log("Catch");
                coin.SetActive(false);
                StartCoroutine(Timer());
                coinCounter++;
                coinText.text = "Coins: " + coinCounter;
            }
        }
        else
        {
            Debug.Log("Is active? " + active);
        }
    }
    
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        coin.SetActive(true);
    }
}
