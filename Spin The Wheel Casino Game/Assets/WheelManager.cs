using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private Image Wheel;
    [SerializeField] private Button spinWheel;
    [SerializeField] private float spinWheelSpeed;
    private bool isWheelSpinned;
    private void Awake()
    {
        spinWheel.onClick.AddListener(SpinTheWheel);
    }
    public void SpinTheWheel()
    {
        
        spinWheel.interactable = false;
        isWheelSpinned = true;
    }
    private void Update()
    {
        if (isWheelSpinned)
        {
            Wheel.transform.Rotate(0, 0, 1000 * spinWheelSpeed * Time.deltaTime);
            Invoke("StopSpinWheel", 5f);
        }
    }
    private void StopSpinWheel()
    {

        Wheel.transform.Rotate(0, 0, 0);
        spinWheel.interactable = true;
        isWheelSpinned = false;
    }
}
