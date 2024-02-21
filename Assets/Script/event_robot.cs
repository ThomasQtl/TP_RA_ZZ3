using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event_robot : MonoBehaviour
{
    public Transform Socle2;
    public Transform BrasArticule;



    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("JoystickRobotMove", RobotMove);
 
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EventManager.StopListening("JoystickRobotMove", RobotMove);
    }

    void RobotMove(EventParam a)
    {
        EventParamVector2 trueParam = a as EventParamVector2;
        Socle2.Rotate(Vector3.up, trueParam.Value.x);
        BrasArticule.Rotate(Vector3.right, trueParam.Value.y);
       
    }
}
