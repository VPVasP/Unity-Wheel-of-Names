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
    //make this a signleton and add a listener to our button
    private void Awake()
    {
        instance = this;
        spinWheel.onClick.AddListener(SpinTheWheel);
    }
    //assign the components and put the add the the rotation speed value
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        currentRotationSpeed = 1;
    }
    //spin the wheel function
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
        //if the wheel is spinned rotate it on the z axis each second
        if (isWheelSpinned)
        {
            Wheel.transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);
        }
        //if the wheel has been stopped make the button interactable
        if (isWheelStopped)
        {
            spinWheel.interactable = true;
        }
    }
    //stop the spin wheel function
    private void StopSpinWheel()
    {
        Debug.Log("Stopped Wheel");
        isWheelSpinned = false;
        isWheelStopped = true;
        currentRotationSpeed = 0;
    }
}