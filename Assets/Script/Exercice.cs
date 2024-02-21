using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using System;
using System.Runtime.InteropServices.WindowsRuntime;


public class Exercice : MonoBehaviour
{

    bool appuyerunefois;
    bool actif;
    // Start is called before the first frame update
    void Start()
    {
        appuyerunefois = true;
        actif = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
       
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            // Affiche un cube rose lorsqu'on appuie sur le bouton trigger
            UnityEngine.XR.InputDevice device = leftHandDevices[0];
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                if (appuyerunefois) {
                    if (!actif)
                    {
                        EventManager.TriggerEvent("AC", null);
                    }
                    if (actif)
                    {
                        EventManager.TriggerEvent("DC", null);
                    }
                    appuyerunefois = false;
                    actif = !actif;
                }
                
            }
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && !triggerValue) { 
                 appuyerunefois = true;
            }

            // Déplacement du robot à l'aide d'un joystick

            Vector2 axisValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out axisValue) && (axisValue != Vector2.zero))
            {
                EventParamVector2 camecasselescouilles = new EventParamVector2();
                camecasselescouilles.Value = axisValue;
                EventManager.TriggerEvent("JoystickRobotMove", camecasselescouilles);
                
            }
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        
        
    }
}


// Modifier la rotation de socle2 avec Y
// Modifier la rotation de BrasPrincipal avec z