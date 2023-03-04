## How to set up
Ensure that you have git installed. Also ensure that you have Unity 2021.3.17f1 installed. Later versions may work as well, but that is the version the game was developed in. We have not tested it in other versions. Be sure to clone the repository into a desired folder. 
Open the project using unity hub. It may prompt you to install some extra things if it is your first time using Unity hub. The first open will take much longer than the rest due to Unity downloading necessary files. 
You may also need to add the scenes to the build settings. You can find this in File > Build settings. There are three scenes to add: MainMenu, InstructionsScene, and TophatSurvivor. They need to be in this order in the list. 

## How to play test
Unity hub should open the game to the main menu screen. YOU NEED TO START FROM THIS SCENE. If it does not open this screen, you can find it at Project 1/Assets/Scenes/MainMenu.unity. 
![MainMenu Screen](DocumentationImages/MainMenuImage.png)

From here you have the option to either play a new game, load your previous save, check the instructions or quit the game. Your character will now spawn in the middle of the map to. Utilize WASD keys to move, and use your mouse cursor to aim your bullets. Enemies will spawn at different spots in the map and chase you. When they make contact with you, you will lose health, indicated at the bottom left. When you kill an enemy, they will drop an orb which will increase your character's experience and score. Once you reach 0 health, the game will end

![In Game Screen](DocumentationImages/InGameImage.png)

## Creating the Main menu
The main menu was built using the UI builder provided by Unity. Check to see if this is installed for you. If it is not, you must install it by adding com.unity.ui.builder and com.unity.ui. 
You can use our UI object in our MainMenu scene to create a similar system to start new game, load save, instructions and quit the game. You just need to edit the names of the scenes in the MainMenuController.cs file to open the correct scenes and load the correct information. 

## Creating Instructions
The instructions scene consists of a background, text on top of an image, and a few buttons. You can opt to use this entire scene for your instructions. You can opt to change the images of the background, and the image the text is layed over to match your game. You can do this by just changing the source images. The buttons will work no matter what, but is designed only for two pages of instructions. You can choose to edit the text game objects to suit the needs of the game. You can also change the videos of the demonstrations by changing the video clip in the corresponding VideoPlayer. 

![Change Video](DocumentationImages/ChangeVideoImage.png)

## Creating your HUD
Your HUD (Heads up display) is connected with your player. It consists of the health, level, and score. The hud is connected to the PlayerAttributes.cs script. You can find this in Project 1/Assets/Scripts. You can add this script to your player to ensure that they have specific attributes. With your HUD connected with this script in your player, whenever you make contact with an enemy you will lose HP, and when you pick up an XP or HP orb, you will gain experience, health and score. They XP and HP orbs need to have the tags "xp" and "hp" respectively to work. 

## Creating your pause menu and death screen screen
Both the pause menu and the death screen are very similar. They both consists of a panel that is initially set inactive. Based on different actions, they will become active (visible). The pause menu shows when the pause button or "escape" is pressed. The death screen appears when the player's health reaches 0. Both of them consists of buttons that will take you to the corresponding screens. You can change this in the Pausemenu.cs file to load whatever scenes you wish. 

## Saving
Saving is done by putting the stats of the player in a gameobject initially in the Mainmenu scene. This needs to be done to ensure the player can load and start a new game properly. You can create an empty object and attach a SaveManager script to it. You can find this script in Project 1/Assets/Scripts/Saving. Our Player object will interact with this object to get its attributes and saves. 