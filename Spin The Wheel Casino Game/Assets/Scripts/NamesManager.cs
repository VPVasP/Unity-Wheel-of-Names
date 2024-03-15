using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NamesManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] wheelNames;
    [SerializeField] private TMP_InputField[] panelNames;
    [SerializeField] private string[] stringNames;
    [SerializeField] private Image wheel;
    [SerializeField] private GameObject namesPanel;

    private void Start()
    {
        wheelNames = wheel.GetComponentsInChildren<TMP_Text>();
        panelNames = namesPanel.GetComponentsInChildren<TMP_InputField>();
        if (stringNames.Length == panelNames.Length)
        {

            for (int i = 0; i < stringNames.Length; i++)
            {

                panelNames[i].text = stringNames[i];
            }

            if (stringNames.Length == wheelNames.Length)
            {

                for (int i = 0; i < stringNames.Length; i++)
                {

                    wheelNames[i].text = stringNames[i];
                }
            }
        }
    }
    private void Update()
    {
        wheelNames = wheel.GetComponentsInChildren<TMP_Text>();
        panelNames = namesPanel.GetComponentsInChildren<TMP_InputField>();
        if (stringNames.Length == panelNames.Length)
        {
            for (int i = 0; i < stringNames.Length; i++)
            {
               stringNames[i] = panelNames[i].text;
            }
        }

        if (stringNames.Length == wheelNames.Length)
            {

                for (int i = 0; i < stringNames.Length; i++)
                {

                wheelNames[i].text = panelNames[i].text;
            }
            }
        }
    }


