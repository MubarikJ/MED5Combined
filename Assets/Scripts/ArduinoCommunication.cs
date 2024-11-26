using System.IO.Ports;
using UnityEngine;

public class ArduinoCommunication : MonoBehaviour
{
    private SerialPort arduinoPort;

    void Start()
    {
        // Replace "COM3" with the correct port for your Arduino
        arduinoPort = new SerialPort("COM3", 9600);

        // Open the serial port
        if (!arduinoPort.IsOpen)
        {
            arduinoPort.Open();
            Debug.Log("Connected to Arduino");
        }
    }

    void OnPlayerHit()
    {
        // Send the command to move the servo
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            arduinoPort.Write("1"); // Send '1' as a command to Arduino
            Debug.Log("Sent hit signal to Arduino");
        }
    }

    void OnApplicationQuit()
    {
        // Close the port when the application quits
        if (arduinoPort != null && arduinoPort.IsOpen)
        {
            arduinoPort.Close();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyAttack"))
        {
            OnPlayerHit();
        }
    }
}
