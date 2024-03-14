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

    private AudioSource aud;
    private void Awake()
    {
        instance = this;
        spinWheel.onClick.AddListener(SpinTheWheel);
    }
    private void Start()
    {
        aud= GetComponent<AudioSource>();
        currentRotationSpeed = 1;
    }
    public void SpinTheWheel()
    {
        spinWheel.interactable = false;
        isWheelSpinned = true;
        isWheelStopped = false;
        currentRotationSpeed = 1;
        currentRotationSpeed = 200 * spinWheelSpeed;
        aud.Play();
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