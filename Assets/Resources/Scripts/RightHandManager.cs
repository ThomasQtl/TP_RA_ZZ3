using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandManager : MonoBehaviour
{
    private InputDevice mainDevice;
    [SerializeField]
    InputDeviceCharacteristics controllerCharacteristics;

	// Start is called before the first frame update
	void Start()
    {
        List<InputDevice> devicesList = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devicesList);
    
        foreach (InputDevice inputItem in devicesList)
		{
            Debug.Log($"{inputItem.name} : {inputItem.characteristics}");
        }

        if (devicesList.Count > 0)
        {
            mainDevice = devicesList[0];
        }

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
