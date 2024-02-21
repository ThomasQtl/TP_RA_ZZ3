using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using UnityEngine;

public class event_cube : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube.SetActive(false);
        EventManager.StartListening("AC", ApparitionCube);
        EventManager.StartListening("DC", DesapparitionCube);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        EventManager.StopListening("AC", ApparitionCube);
        EventManager.StopListening("DC", DesapparitionCube);
    }
    void ApparitionCube(EventParam a)
    {
        cube.SetActive(true);

    }

    void DesapparitionCube(EventParam a)
    {
        cube.SetActive(false);
    }

}
