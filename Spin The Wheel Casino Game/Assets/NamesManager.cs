using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NamesManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] names;
    [SerializeField] private TMP_Text[] panelNames;
    [SerializeField] private string[] stringNames;
    [SerializeField] private Image wheel;
    [SerializeField] private GameObject namesPanel;

    private void Start()
    {
        names = wheel.GetComponentsInChildren<TMP_Text>();
        panelNames = namesPanel.GetComponentsInChildren<TMP_Text>();
        if (stringNames.Length == panelNames.Length)
        {

            for (int i = 0; i < stringNames.Length; i++)
            {

                panelNames[i].text = stringNames[i];
            }

            if (stringNames.Length == names.Length)
            {

                for (int i = 0; i < stringNames.Length; i++)
                {

                    names[i].text = stringNames[i];
                }
            }
        }
    }
}
