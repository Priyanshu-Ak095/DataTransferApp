Data Transfer App (WPF - Serial Port Communication)
This project is a simple WPF application for sending and receiving data over a Serial Port.
It simulates data transfer between the app and a terminal (like Hercules).

✨ Features
Send Data:

User can input a 16-digit numeric code.

After entering 16 digits, the data is automatically sent over Serial Port.

Receive Data:

Incoming data from the Serial Port is displayed in the second textbox.

Real-Time Communication:

Works with tools like Hercules Terminal and Virtual Serial Port for testing.

Input Validation:

Only allows numeric input (0-9).

Exactly 16 characters required before sending.

🛠 Technologies Used
C#

WPF (.NET Framework)

System.IO.Ports (Serial Communication)

🖥 Setup Instructions
Download and install Hercules Terminal.

Setup Virtual COM Ports using Eltima's Virtual Serial Port Driver.

Connect one COM port to Hercules and one to this WPF App.

Run the application.

Start sending and receiving data!
Author
Priyanshu-Ak095
