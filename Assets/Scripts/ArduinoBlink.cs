using UnityEngine;
using System.IO.Ports;

public class ArduinoBlink : MonoBehaviour
{
    SerialPort arduinoPort = new SerialPort("COM8", 115200); // Adjust COM port as needed

    void Start()
    {
        if (!arduinoPort.IsOpen)
        {
            arduinoPort.Open();     // Open the serial port
            arduinoPort.DtrEnable = true; // Ensures a stable connection
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "TEST"
        if (collision.gameObject.CompareTag("BossAttackWind"))
        {
            SendToArduino("MOVE"); // Send the MOVE command to Arduino
            Debug.Log("Collision with TEST detected. Servo moving to 180 degrees.");
        }


        if (collision.gameObject.CompareTag("BossAttack"))
        {
            SendToArduino("MOVEF"); // Send the MOVE command to Arduino
            Debug.Log("Collision with TEST detected. Servo moving to 180 degrees.");
        }
    }




    void SendToArduino(string message)
    {
        if (arduinoPort.IsOpen)
        {
            arduinoPort.WriteLine(message); // Send the message to Arduino
        }
    }

    private void OnApplicationQuit()
    {
        if (arduinoPort.IsOpen)
        {
            arduinoPort.Close(); // Close the serial port when exiting
        }
    }
}
