using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    public static WheelManager instance;

    [SerializeField] private Image Wheel;
    [SerializeField] private Button spinWheel;
    [SerializeField] private float spinWheelSpeed;
    public bool isWheelSpinned;
    public bool isWheelStopped;

    private float currentRotationSpeed;

    private void Awake()
    {
        instance = this;
        spinWheel.onClick.AddListener(SpinTheWheel);
    }

    public void SpinTheWheel()
    {
        spinWheel.interactable = false;
        isWheelSpinned = true;
        isWheelStopped = false;
        currentRotationSpeed = 1000 * spinWheelSpeed;
    }

    private void Update()
    {
        if (isWheelSpinned)
        {
            Wheel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);
            Invoke("StopSpinWheel", 5f);
        }
        if (isWheelStopped)
        {
            spinWheel.interactable = true;
        }
    }

    private void StopSpinWheel()
    {
        Debug.Log("Stopped Wheel");
        isWheelSpinned = false;
        isWheelStopped = true;
        currentRotationSpeed = 0;
    }
}