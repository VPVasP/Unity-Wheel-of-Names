using TMPro;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool collided;
    [SerializeField] private GameObject panel;
    private TextMeshProUGUI text;
    private void Start()
    {
        panel.SetActive(false);
        text = panel.GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        if (WheelManager.instance.isWheelStopped)
        {
            collided = true;
            panel.SetActive(true);
        }
        else
        {
            collided = false;
            panel.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
   
        if (collided && collision.CompareTag("Name"))
        {
            
            Debug.Log("Entered" +collision.name);
            text.text = "Your Name is " + collision.GetComponent<TextMeshProUGUI>().text;
        }
       
    }
    
}
    
