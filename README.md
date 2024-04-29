## Build on Unity
1. Clone the repo / Download the repo and unzip it
2. Open it with Unity
3. Select the Main Menu Scene as entry point to the game which is located in (Assets/Scenes/MainMenu.unity)
4. Select iPhone 11 as the simulator and click play
![螢幕截圖 2024-04-29 下午9 05 30](https://github.com/benwu030/Kaboom/assets/78753601/12a30aa0-d82a-4116-9206-c46018307bab)


## Build on Xcode (Please use Iphone11 simulator for testing)
1. Unzip the XcodeBuild folder
2. Open the "Unity-iPhone.xcodeproj" with Xcode
3. Select the simulator and click the build button


## Common Error when building
### Provisioning Profile
If you see below error, please enable automatically manage signing and choose your own team
![螢幕截圖 2024-04-29 下午8 46 19](https://github.com/benwu030/Kaboom/assets/78753601/d132b60b-620d-4ea6-b3df-b3401f3c1ccd) ![螢幕截圖 2024-04-29 下午8 46 45](https://github.com/benwu030/Kaboom/assets/78753601/8c6ce5e3-fd91-43c8-8b76-5a3a49e98e33)
### Simulator not visiblie in Xcode
If you cannot see the simulator in Xcode, please  enable Rosetta Destination Architecture in Xcode,
![螢幕截圖 2024-04-29 下午8 59 33](https://github.com/benwu030/Kaboom/assets/78753601/8c18aaa6-90c4-4793-8c6d-5d9ac50198d0)
Also, please set the target SDK to simulator in Unity
![螢幕截圖 2024-04-29 下午9 01 05](https://github.com/benwu030/Kaboom/assets/78753601/d514f8dd-ead6-408a-9d89-826c18a810ba)
