# Chat Application using C# - Client-Server Architecture

This is a simple chat application that enables communication between multiple clients using multithreading and a server using C# programming language. The program consists of two parts, the client-side and the server-side code.

### Client-side code:

The client-side code is written using Windows Forms Application. The Form1 class contains the code to establish a connection with the server and send messages to it. When the client starts, it tries to connect to the server at the IP address "127.0.0.1" and port number "8488". The form contains a text box to enter the message and two buttons, one to send the message and the other to receive messages from the server. When the send button is clicked, the message is sent to the server using the NetworkStream class. When the receive button is clicked, the client receives the message from the server and displays it on the form.

### Server-side code:

The server-side code is written using Console Application. The Program class contains the code to start the server and listen for incoming client requests. When a client connects to the server, a new thread is created to handle the communication between the client and the server. The handleClinet class contains the code to handle each client request separately. It creates a list of all the connected clients and broadcast messages to all the clients except the sender when a message is received.

### How to use:
To run the application, first, run the server-side code and then run the client-side code. Multiple clients can connect to the server and communicate with each other using this chat application.
