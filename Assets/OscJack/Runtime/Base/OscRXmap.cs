using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscRXmap : MonoBehaviour
{
    [System.Serializable]
    public class PortMap
    {
        [Tooltip("Choose name to associate with port")]
        public string portSymbol = "default";
        [Tooltip("Choose OSC port")]
        public int portNumber = 9999;

    }

    public PortMap myPortMap;


    static public List<PortMap> allPortMaps = new List<PortMap>();


    private void Awake()
    {
        if (myPortMap.portSymbol == string.Empty)
        {
            Debug.LogError(name + " " + GetType() + ".Awake() port name field empty , aborting");
            Destroy(this);
        }

        foreach (PortMap pm in allPortMaps)
        {
            if (myPortMap.portSymbol == pm.portSymbol)
            {
                Debug.LogWarning(name + " " + GetType() + ".OnValidate() port name: " + myPortMap.portSymbol + " already being used, aborting");
                Destroy(this);
            }
            //if (myPortMap.portNumber == pm.portNumber)
            //{
            //    Debug.LogWarning(name + " " + GetType() + ".OnValidate() port number: " + myPortMap.portNumber + " already being used, aborting");
            //    Destroy(this);
            //}
        }
        allPortMaps.Add(myPortMap);

    }

    private void OnDestroy()
    {
        allPortMaps.Remove(myPortMap);
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
            foreach (PortMap pm in allPortMaps)
            {
                print(" name: " + pm.portSymbol + "  port: " + pm.portNumber);
            }
    }
}
