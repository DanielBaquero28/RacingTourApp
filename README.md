<h1>Project: Racing Tour</h1>
<p><strong>Racing Tour is a racing game made for those who seek speed and lack of fear to fail on their first attempts because of it's game mode. Have fun !</strong></p>
<img src="/images/racingtourlogo.png" alt="Racing Tour Logo" align="middle">
<body>
<h2>Introduction</h2>
You can download the app in the Landing Page
<br>
<strong>Landing Page: </strong><a href="https://835407.wixsite.com/racingtour">Click here</a>
<h2>Installation</h2>
<ol>
<li>Head to the landing of Racing Tour, which is found above</li>
<li>Click on the "GET THE APP" button, which will head to the RacingTourBuildApp.rar file in OneDrive</li>
<li>Click on the folder and download it</li>
<li>After downloading it, unzip the file</li>
<li>For last, click on the folder saved in your PC and open the Racing Tour.exe file</li>
<li>Enjoy the game!</li>
</ol>
<img src="/images/racingtourss.jpeg" alt="Racing Tour In-Game" align="middle">
<h2>Usage</h2>
<ul>
<li>In the app you will find exactly what you have to do in each step</li>
<li>To move the car use the arrow keys or use W(accelerate), A(Left), S(Brake), D(Right) keys.</li>
</ul>
<h2>Contributing</h2>
Please refer to each project's style and contribution guidelines for submitting patches and additions. In general, we follow the "fork-and-pull" Git workflow.
<br>
<ol>
<br>
<li>Fork the repo on GitHub</li>
<li>Clone the project to your own machine</li>
<li>Commit changes to your own branch</li>
<li>Push your work back up to your fork</li>
<li>Submit a Pull request so that we can review your changes</li>
</ol>
NOTE: Be sure to merge the latest from "upstream" before making a pull request! Thanks in advance.
<h2>Story behind Racing Tour</h2>
<h3>Why did I create it ?</h3>
<p>
I'm going to start off by saying that I love video games, I've been a fan since a very young age and now with what I've learned these past 2 years I could finally make one of my own.

One of my other passions is mixed reality, and Unity3D is a very nice platform to develop this kind of technology. In the spirit of learning, I used Unity3D as the engine of the game to become more familiar with it and cover some ground in mixed reality.

So RACING TOUR was really the mix of wanting to make a video game and wanting to know more about the tools that are required to develop mixed reality. I hope everyone likes it.
</p>
<h3>Timeline</h3>
<p>
First things first, I'd like to say that it was a very challenging development process, one of the most challenging things I've ever done. Having that said, let's get to the timeline.
</p>
<p>
I had around six weeks to develop the app from scratch. So I had to start right away. During the first week I worked on the design of the game. I started creating the map and the track from scratch with the help of the game engine Unity. So as I wanted the map to have a rural aspect, I began to create mountains. This is done in Unity by adding a GameObject called "Terrain", then you setup a height and start using your mouse wherever you want to have a mountain. In my map, I created about 5 or 6 mountains, and then I imported some trees and bushes from the Unity Asset Store and added them in the rest of the map. 
</p>
<p>
After some of polishing, the map was done. Right after the map was ready, I began to start creating the track. So I used a tool from the terrain gameobject that defined the layers of the map, and defined the track was another layer which was above the terrain. Then I created the texture of the road, and started drawing the path of the road. Right after this, I put some rocky elevated walls that surrounded the track, to keep on with the rural aspect. After A LOT of pollishing, the track was finally done. 
</p>
<p>
The next 3-4 weeks were all about game development. So first I imported a car from the standard assets package provided by Unity. It came with all of the design of the car and the scripts required in order to move correctly with all of the physics already applied. After that, I started managing the camera that was going to keep along with the car no matter where it went or what the car did, so I had to start coding in C# to make the camera steady. Then I created some triggers to manage the time of the race, I added one when the user got to the half-point of the track and another when he/she reached the finish line.
</p>
<p>
Then I had to code the race time that will show up on the UI. Not only the race time, but also code to show the best time when the user got to the finish line faster than before, if it didn't get before the current best time it'll not do anything. As the only game mode of the game is time trial, I had to make the user reach the finish line before a specific time. So I had to code that if the user hasn't reached the finish line before a minute, game over, and had to retry to win. As the race only has one lap, I also had to set that when the lap is equal to 1 the game was finished. 
</p>
<p>
After that I added other view modes for the user, which were switched to by typing the c key. I added two other view modes besides the normal, one of those was a far view mode to see exactly what's ahead and another that felt like the user was in driver's seat. I also added some music to the game and sound effects for the countdown to start the race. At that point, the game already had a great aspect and was almost ready. I felt that the game needed to have a more realistic aspect so I added something called "skybox", which is how the sky of the game will look; which gave the feeling that it was in the sunset.
</p>
<p>
So when the game itself was done, I started creating the rest of the scenes, which were: User Sign Up, User Login, User Data Recollection(Full name, Username), Main Menu, Track Selection(In this case only one track), Instructions Scene, Game Scene(the one we already created), Retry Scene, and for last the scene when you win. The User Sign Up scene was all about authentication, so I created some UI text boxes to receive the input of the user's email and password. The authentication system was created with Google Firebase whereI had to create a script in order to create the user in the authentication system. The login scene is in charge of verifying if the user exists and if the credentials are correct, I had to create a script as well to check if everything is ok in the authentication system. 
</p>
<p>
When the user is authenticated, the user is asked to fill out the form asking for his/her name and username, which will be stored in the Firebase Real-time database along with it's email. The Main Menu scene, as the options to play, to select a track, to quit or to log out. If you would want to select a track, you would be taken to the track selection scene, and pick a track. After that you'll be taken to the Instructions scene, where the user will know that if you don't reach the finish line before the minute you'll loose and have to try again. During the Game scene, if you loose, the Retry scene will take place, and will give you the chance to start over the race, go to the main menu or quit the game, but if you reach the finish line, the Win scene will show up, the car would stop, and another sound track will play.
</p>
<p>
That's pretty much how to game was created, you can see a demo of the game<a href="https://www.youtube.com/watch?v=fS6jzxupNGY"> here</a>, or you can download the game in our landing page, <a href="https://835407.wixsite.com/racingtour">click here</a>. I really hope you enjoy the first game I've ever done. Thank you !
</p>
<h2>Licensing</h2>
<p>
MIT License

Copyright (c) 2020 Daniel Baquero Arias

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
</p>
</body>
<br>
<br>
<footer>
Made by: <strong>Daniel Baquero - <a href="https://github.com/DanielBaquero28">Github</a> - <a href="https://www.linkedin.com/in/daniel-alejandro-baquero-arias-106a45195/">LinkedIn</a></strong>
</footer>
</html>
