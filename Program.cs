using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Client
{
    public static void Main()
    {
        // Setting up the server IP address and port number
        IPAddress serverAddress = IPAddress.Parse("127.0.0.7");
        int serverPort = 8000;


         // Creating our client socket
        Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Connecting to the server
        clientSocket.Connect(new IPEndPoint(serverAddress,serverPort));
        Console.WriteLine("Connected to server!");

        // Sending message to the server
        string clientMessage = "Hello, server!";
        byte[] temp = Encoding.ASCII.GetBytes(clientMessage);
        clientSocket.Send(temp);

        // Receiving message from the server
        byte[] temp2 = new byte[1024];
        int serverBytes = clientSocket.Receive(temp2);
        string serverMessage = Encoding.ASCII.GetString(temp2, 0, serverBytes);
        Console.WriteLine("Received response from server: " + serverMessage);

        // Closing the connection
        clientSocket.Shutdown(SocketShutdown.Both);
        clientSocket.Close();
    }
}

