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

    [SerializeField] private float currentRotationSpeed;

    private void Awake()
    {
        instance = this;
        spinWheel.onClick.AddListener(SpinTheWheel);
    }
    private void Start()
    {
        currentRotationSpeed = 5;
    }
    public void SpinTheWheel()
    {
        spinWheel.interactable = false;
        isWheelSpinned = true;
        isWheelStopped = false;
        currentRotationSpeed = 5;
        currentRotationSpeed = 1000 * spinWheelSpeed;

        Invoke("StopSpinWheel", 5f);
    }

    private void Update()
    {
        if (isWheelSpinned)
        {
            Wheel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);
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