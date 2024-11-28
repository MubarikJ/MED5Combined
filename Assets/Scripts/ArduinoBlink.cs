using UnityEngine;
using System.IO.Ports;

public class ArduinoBlink : MonoBehaviour
{
    SerialPort arduinoPort = new SerialPort("COM8", 115200); // Adjust COM port as needed

    void Start()
    {
        OpenSerialPort();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BossAttackWind"))
        {
            SendToArduino("MOVE"); // Send the MOVE command to Arduino
            Debug.Log("Collision with BossAttackWind detected. Servo moving to 180 degrees.");
        }

        if (other.CompareTag("BossAttack"))
        {
            SendToArduino("MOVEF"); // Send the MOVEF command to Arduino
            Debug.Log("Collision with BossAttack detected. Servo moving to 180 degrees.");
        }
    }

    void SendToArduino(string message)
    {
        if (arduinoPort.IsOpen)
        {
            arduinoPort.WriteLine(message); // Send the message to Arduino
        }
        else
        {
            Debug.LogWarning("Attempted to send data, but the serial port is closed.");
        }
    }

    void OpenSerialPort()
    {
        if (!arduinoPort.IsOpen)
        {
            try
            {
                arduinoPort.Open();
                arduinoPort.DtrEnable = true; // Ensures a stable connection
                Debug.Log("Serial port opened successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to open serial port: " + e.Message);
            }
        }
    }

    private void OnApplicationQuit()
    {
        CloseSerialPort();
    }

    private void OnDisable()
    {
        CloseSerialPort();
    }

    void CloseSerialPort()
    {
        if (arduinoPort.IsOpen)
        {
            try
            {
                arduinoPort.Close();
                Debug.Log("Serial port closed successfully.");
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to close serial port: " + e.Message);
            }
        }
    }
}
