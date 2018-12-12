# UltimatePong2.0

#Dependencies

In order to run the game you will need a Raspberry Pi with a sensehat connected

# Installation

Clone the repo to your local machine. Then do the following
  1. Run PongControlsWebService.sln
    a) (This has the reciever for the broadcast controller)
    b) Start the program (it has to be a single startupproject - ControlsUdpReciever)
  2. Clone PongPiControllerBroadcast to the Raspberry pi.
    a. Make sure that you are on the same network as the pi
    b. Connect to the pi with putty or another terminal emulator
    c. Navigate where you want the file to be located
    d. Clone this project https://github.com/HashtagLegend/PongPiControllerUdpBroadcast.git
      - (the python script is also included in the project, but to make it easier to clone we've created another repo to clone from)
    e. Once its cloned, navigate to the folder
    f. Run the program with this command 
      - Python3 controller.py
  3. Open Powershell
    a. Navigate to the UltimatePong2.0/PongHtml folder
    b. Open it in VS Code (code .)
    c. We havent included node modules in our git repo, so run the npm install command from the VS Code terminal
    d. Run the comman: npm-run-all --parralel watch
  
  Now everything is up and running!
  
  # Playing the game
  
  1. Open the browser with the game page
  2. Login with your google account
    a. This will automaticly create a game profile
  3. Navigate to the Ultimate Pong tab
    a. Use the Raspberry pi to control the pong
    b. Rotate clockwise to move up
    c. Rotate counterclockwise to move down
    
  # Achievements
  
  It is possible to recieve achievements - try to get as many as possible
  
  # Multiplayer
  
  It is possible to play with friends, just use the keyboard (a and z keys) for player 2
  
  # Different levels of challenging AI
  
  Play against three levels of AI ranging from tough to nearly impossible
  
  # Leaderboards
  
  Compare your skills against your friends and climb to the top of the leaderboard - greatness awaits!
  
