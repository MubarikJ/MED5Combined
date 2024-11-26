using UnityEngine;
using System.IO.Ports;

public class ArduinoControl : MonoBehaviour
{
    public string portName = "COM8"; // Replace with the actual COM port for Arduino
    private SerialPort arduino;

    void Start()
    {
        arduino = new SerialPort(portName, 9600);
        try
        {
            arduino.Open();
        }
        catch
        {
            Debug.LogError($"Could not open port {portName}");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BossAttack"))
        {
            SendArduinoMessage("1");
            Debug.Log("Player hit! Sending signal to Arduino.");
        }
    }

    void SendArduinoMessage(string message)
    {
        if (arduino != null && arduino.IsOpen)
        {
            arduino.Write(message);
        }
        else
        {
            Debug.LogError("Arduino connection not open.");
        }
    }

    private void OnApplicationQuit()
    {
        if (arduino != null && arduino.IsOpen)
        {
            arduino.Close();
        }
    }
}
