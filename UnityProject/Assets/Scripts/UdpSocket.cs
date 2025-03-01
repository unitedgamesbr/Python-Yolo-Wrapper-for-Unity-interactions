using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using SimpleJSON;

public class UdpSocket : MonoBehaviour
{
    [HideInInspector] public bool isTxStarted = false;

    [SerializeField] readonly string IP = "127.0.0.1"; // local host
    [SerializeField] readonly int rxPort = 8000; // port to receive data from Python on
    [SerializeField] readonly int txPort = 8001; // port to send data to Python on
    public JSONNode DetectedObjects;
    public int peopleCount = 0;
    public Vector3 leftWristPosition;
    public Vector3 rightWristPosition;

    // Create necessary UdpClient objects
    UdpClient client;
    IPEndPoint remoteEndPoint;
    Thread receiveThread; // Receiving Thread

    public void SendData(string message) // Use to send data to Python
    {
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data, data.Length, remoteEndPoint);
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    void Awake()
    {
        // Create remote endpoint (to Matlab) 
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), txPort);

        // Create local client
        client = new UdpClient(rxPort);

        // local endpoint define (where messages are received)
        // Create a new thread for reception of incoming messages
        receiveThread = new Thread(new ThreadStart(ReceiveData))
        {
            IsBackground = true
        };
        receiveThread.Start();

        // Initialize (seen in comments window)
        print("UDP Comms Initialised");
    }

    private Vector3 ConvertJsonToVector3(JSONArray jsonArray)
    {

        if (jsonArray == null)
        {
            Debug.LogError("jsonArray is null");
            return new Vector3(0, 0, 0);  // Ou gérer l'erreur comme vous le souhaitez
        }

        return new Vector3(jsonArray[0].AsFloat, -jsonArray[1].AsFloat, 0);
    }

    // Receive data, update packets received
    private void ReceiveData()
    {
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                string text = Encoding.UTF8.GetString(data);

                // parse json from text
                var obj = JSON.Parse(text);

                // get hands distance
                obj = obj.AsArray;
                DetectedObjects = obj;
                peopleCount = obj.Count;

                // get left and right wrist positions
                var leftPositionsJson = obj[0]["left_wrist"].AsArray;
                var rightPositionsJson = obj[0]["right_wrist"].AsArray;
                leftWristPosition = ConvertJsonToVector3(leftPositionsJson);
                rightWristPosition = ConvertJsonToVector3(rightPositionsJson);

                ProcessInput(text);
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    private void ProcessInput(string input)
    {
        // PROCESS INPUT RECEIVED STRING HERE

        if (!isTxStarted) // First data arrived so tx started
        {
            isTxStarted = true;
        }
    }

    //Prevent crashes - close clients and threads properly!
    void OnDisable()
    {
        Debug.Log("Closing UDP socket");
        receiveThread?.Abort();
        client.Close();
    }

}