using UnityEngine;
using System.IO.Ports;

public class ArduinoBlinkOnStart : MonoBehaviour
{
    public string portName = "COM8"; // Replace with your Arduino's COM port
    private SerialPort arduino;

    void Awake()
    {
        // Initialize SerialPort
        arduino = new SerialPort(portName, 9600);

        try
        {
            arduino.Open();
            Debug.Log("Arduino connected.");
        }
        catch
        {
            Debug.LogError($"Could not open port {portName}. Check the connection.");
        }
    }

    void Start()
    {
        // Send the blink signal to Arduino
        if (arduino != null && arduino.IsOpen)
        {
            arduino.Write("1"); // Send the blink command
            Debug.Log("Blink command sent to Arduino.");
        }
        else
        {
            Debug.LogError("Arduino is not connected or the port is not open.");
        }
    }

    private void OnApplicationQuit()
    {
        // Close the Serial connection when the application quits
        if (arduino != null && arduino.IsOpen)
        {
            arduino.Close();
            Debug.Log("Arduino connection closed.");
        }
    }
}
