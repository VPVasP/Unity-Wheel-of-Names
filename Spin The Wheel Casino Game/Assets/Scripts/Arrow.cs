using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool collided;
    private GameObject namePanel;
    private TextMeshProUGUI wheelText;
    private void Start()
    {
        //Find the Name Panel,disable it and get assign the wheel text
        namePanel = GameObject.FindGameObjectWithTag("NamePanel");
        namePanel.SetActive(false);
        wheelText = namePanel.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        //if the wheel is stopped activate the panel 
        if (WheelManager.instance.isWheelStopped)
        {
            collided = true;
            namePanel.SetActive(true);
        }
        //if the wheel isn't stopped disable the panel
        else
        {
            collided = false;
            namePanel.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //if it has been collided and the collision tag is Name
        if (collided && collision.CompareTag("Name"))
        {
            //The Wheel text gets the value of the collision text
            wheelText.text = "Your Name is " + collision.GetComponent<TextMeshProUGUI>().text;
        }
       
    }
    
}
    
