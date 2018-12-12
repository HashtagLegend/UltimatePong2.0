# UltimatePong2.0

## Dependencies

In order to run the game you will need a Raspberry Pi with a sensehat connected

## Installation

Clone the repo to your local machine. Then do the following
  **1.** Run PongControlsWebService.sln <br>
    **a.** (This has the reciever for the broadcast controller)<br>
    b. Start the program (it has to be a single startupproject - ControlsUdpReciever)
  2. Clone PongPiControllerBroadcast to the Raspberry pi.<br>
    a. Make sure that you are on the same network as the pi<br>
    b. Connect to the pi with putty or another terminal emulator<br>
    c. Navigate where you want the file to be located<br>
    d. Clone this project https://github.com/HashtagLegend/PongPiControllerUdpBroadcast.git<br>
    e. (the python script is also included in the project, but to make it easier to clone we've created another repo to clone from)<br>
    f. Once its cloned, navigate to the folder<br>
    g. Run the program with this command: Python3 controller.py  <br>
  3. Open Powershell
    a. Navigate to the UltimatePong2.0/PongHtml folder<br>
    b. Open it in VS Code (code .)<br>
    c. We havent included node modules in our git repo, so run the npm install command from the VS Code terminal<br>
    d. Run the comman: npm-run-all --parralel watch<br>
  
  Now everything is up and running!
  
  ## Playing the game
  
  1. Open the browser with the game page
  2. Login with your google account<br>
    a. This will automaticly create a game profile
  3. Navigate to the Ultimate Pong tab<br>
    a. Use the Raspberry pi to control the pong<br>
    b. Rotate clockwise to move up<br>
    c. Rotate counterclockwise to move down
    
  ## Achievements
  
  It is possible to recieve achievements - try to get as many as possible
  
  ## Multiplayer
  
  It is possible to play with friends, just use the keyboard (a and z keys) for player 2
  
  ## Different levels of challenging AI
  
  Play against three levels of AI ranging from tough to nearly impossible
  
  ## Leaderboards
  
  Compare your skills against your friends and climb to the top of the leaderboard - greatness awaits!
  
