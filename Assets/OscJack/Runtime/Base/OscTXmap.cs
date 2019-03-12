using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscTXmap : MonoBehaviour
{
    [System.Serializable]
    public class TXmap
    {
        [Tooltip("Choose name to associate with port")]
        public string txSymbol = "default";
        [Tooltip("Choose OSC port")]
        public int portNumber = 9999;
        public string address = "localhost";

    }

    public TXmap myTXmap;


    static public List<TXmap> allTXmaps = new List<TXmap>();


    private void Awake()
    {
        if (myTXmap.txSymbol == string.Empty)
        {
            Debug.LogError(name + " " + GetType() + ".Awake() port name field empty , aborting");
            Destroy(this);
        }

        if (myTXmap.address == "localhost")
            myTXmap.address = "127.0.0.1";
        else if (myTXmap.address == "broadcast")
            myTXmap.address = "255.255.255.255";

        foreach (TXmap pm in allTXmaps)
        {
            if (myTXmap.txSymbol == pm.txSymbol)
            {
                Debug.LogWarning(name + " " + GetType() + ".OnValidate() port name: " + myTXmap.txSymbol + " already being used, aborting");
                Destroy(this);
            }
        }
        allTXmaps.Add(myTXmap);

    }

    private void OnDestroy()
    {
        allTXmaps.Remove(myTXmap);
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
            foreach (TXmap pm in allTXmaps)
            {
                print(" name: " + pm.txSymbol + "  port: " + pm.portNumber);
            }
    }
}
