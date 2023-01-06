# Telegram Clone 

To start with, 
Telegram is a cross-platform messenger for sending text messages, making audio and video calls <br>
(https://en.wikipedia.org/wiki/Telegram_(software)) <br>
The project was built to learn new to me websockets, improve skills in 
system design, interface design

## Project description
### Private chats
A private chat is initialized when sending a message from the contact list <br>
The first sent message creates a new chat within the message <br>
If a message receiver doesn't have a chat opened, unread messages will be collecting in the chat list <br>
#### The dialog between 2 people is presented below:
<p align="center">
  <img width="800" height="450" src="https://user-images.githubusercontent.com/73338488/210860186-200612d4-9eae-4634-8cea-fb4fa7c3a486.gif"/>
</p> 

### Group chats
A group chat can have from 1 to many chatting people in it <br>
A group chat is initialized by creating it via filling the form with the chat name and members <br>
If one of the members has a chat closed, unread messages will be collecting in the chat list <br>
#### The conversation between Simon, Brian and Alice is presented below:
<p align="center">
  <img width="800" height="450" src="https://user-images.githubusercontent.com/73338488/210863283-dcefb2c3-500e-4627-80a2-d394e6b2ac5f.gif"/>
</p>

### Additional features
* JWT authentication with access & refresh tokens
* Pretty similar to Telegram interactive interface

## Technologies
### Backend
* C# (ASP.NET Core)
* SignalR Core
* Entity Framework Core
* Insomnia
### Frontend
* HTML & CSS
* TypeScript
* React TS
* CSS Modules

## Challenges
* At the start of learning JWT authentication the problem was to find out why is the refresh token needed and <br>
why isn't the access token enough
* Designing database for both private and group chats
* It was challenging to make SignalR work properly on the frontend with simultaneous connections to the hub in different components
* A lot of challenging moments in interface design like a scroll for overflowing messages and etc

## How to run
* Clone the repo
* Change database (DBMS) in <strong>appsettings.json</strong> or leave as MSSQL in the following line: <br>
`
"DefaultConnection": "Data Source=`<strong>(localdb)\\MSSQLLocalDB</strong>`;Database=Telegram;Trusted_Connection=True;"
`
* Open <strong>Package Manager Console</strong> in Visual Studio and run <strong>update database</strong> <br>
* Go to <strong>telegram_client</strong> folder and run <strong>npm install</strong> to install packages from packages.json
* Run the project via IIS Express
* See you at <strong>https://localhost:44351</strong>

