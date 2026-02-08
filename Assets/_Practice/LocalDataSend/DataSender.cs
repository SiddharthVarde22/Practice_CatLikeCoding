using System.Net.Sockets;
using UnityEngine;

public class DataSender : MonoBehaviour
{
    [SerializeField] int m_dataToSend;

    UdpClient client;
    private void Awake()
    {
        client = new UdpClient();
    }

    [ContextMenu("Send Data")]
    private void SendData()
    {
        //byte[] data = m_dataToSend;
        //client.Send(data, 1, "127.0.0.1", 7777);
    }
}
