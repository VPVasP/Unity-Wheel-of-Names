using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NamesManager : MonoBehaviour
{

    public static NamesManager instance;
    [SerializeField] private TMP_Text[] wheelNames;
    [SerializeField] private TMP_InputField[] panelNames;
    public  string[] stringNames;
    [SerializeField] private Image wheel;
    [SerializeField] private GameObject namesPanel;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //find and assign the wheel names and panel names
        wheelNames = wheel.GetComponentsInChildren<TMP_Text>();
        panelNames = namesPanel.GetComponentsInChildren<TMP_InputField>();

        //if the number of names matches the number of input fields
        if (stringNames.Length == panelNames.Length)
        {
            //update the input fields text with the stored names
            for (int i = 0; i < stringNames.Length; i++)
            {

                panelNames[i].text = stringNames[i];
            }

            //if the number of names matches the number of wheel texts
            if (stringNames.Length == wheelNames.Length)
            {
                //update the wheel texts with the string elements from the array
                for (int i = 0; i < stringNames.Length; i++)
                {

                    wheelNames[i].text = stringNames[i];
                }
            }
        }
    }
    private void Update()
    {
        //if the number of names matches the number of input fields
        if (stringNames.Length == panelNames.Length)
        {
            //update the input fields text with the stored names
            for (int i = 0; i < stringNames.Length; i++)
            {
                stringNames[i] = panelNames[i].text;
            }
        }
        //if the number of names matches the number of wheel texts
        if (stringNames.Length == wheelNames.Length)
        {
            //update the wheel texts with the panel names
            for (int i = 0; i < stringNames.Length; i++)
            {

                wheelNames[i].text = panelNames[i].text;
            }
        }
    }
}
