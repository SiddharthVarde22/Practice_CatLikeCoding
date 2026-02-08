using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class DataReciever : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_data;

    private void Start()
    {
        UdpClient server = new UdpClient(7777);
        IPEndPoint ep = new IPEndPoint(IPAddress.Any, 7777);
        byte[] data = server.Receive(ref ep);
        Debug.Log(Encoding.UTF8.GetString(data));
    }
}
