
# UofSCTourAR
This repository contains the files for our Capstone Senior Design project pertaining to CSCE 490 & 492.
*Still work in progress, more to come soon*

## Build Settings
 - File > Build Settings > Player Settings 
 - Make sure Company Name is UofSCTourAR
 - Update version if needed
 - Target minimum iOS version: 11.0 
 - Architecture: ARM64
 - You may need to add text in the "Allow Camera Access" and "Allow Location Access" fields that are marked with an *
 
 

## Technologies
  - Unity
  - iOS: 12.1.2 or iOS 13.4

Unity: 
  - Version 2019.3.0f6
  - iOS Build Support
  - Mac Build Support

Packages: 
  - AR Foundation: 3.0.1
  - AR Subsystems: 3.0.0
  - ARKit XR Plugin: 3.0.1
  - XR Interaction Tookit: (preview) 0.9.6
  - XR Management: 3.0.6
 
 
## Setup
 > Currently there are no one-time setup instructions for this app
 
## Project Settings: TODO

 

## Running
 1. First, connect a compatible iOS device running the version(s) specified above.
 2. To run the app, you will need to Select File -> Build And Run.
 3. The project will build in Unity, and then open XCode. 
 4. Make sure to select:
    - Your Team, under Signing & Capabilites.
    - Your connected iOS device, under Unity-iPhone -> *Your connected device*
 5. XCode will build the project and auto-run the application on your connect iOS device.
    - If the project is not able to build correctly in XCode, click the "Play" button to restart the build and run the application
 
## Deployment
 
## Testing

### Unit Tests
In order to run the Unit Tests for our project you will need to download and fully set up the project first. After that:
The Unit Tests are located here: TourAR/Assets/Editor/SceneLoaderTest.
 1. First, in the Unity Editor: Open the Test Runner by Navigating to Window -> General -> Test Runner.
 2. From the Test Runner popup window, select the "SceneLoader" test file.
 3. Click "Run Selected" inside the Test Runner window.
 **NOTE** : The SceneLoader script contains 16 unit tests. This script shows up as an option when you run the behavioral tests below, but if selected when running behavioral tests, all 16 unit tests will fail. Be sure to perform these tests separately to avoid conflict.
 
### Behavioral Tests
To run the UI tests on our project, begin by downloading and configuring the project according to the instructions above. 
UI Tests are located here: TourAR/Assets/Editor
 1. In the Unity Editor, navigate to the Windows tab>AltUnityTester to open the AltUnityTester Editor. 
 2. Within the Editor, expand the Assembly-CSharp-Editor.dll folder. 
 3. Expand the Unity folder and select the tests you wish to run. 
 4. Make sure the server port is 13000.
 5. Select "Play in Editor". YOU MUST SELECT THIS FROM THE ALTUNITYTESTER WINDOW, otherwise you will get a socket connection error and the tests will fail.
 6. Once the editor loads, reopen the AltUnityTester window, make sure the tests you want to run are selected, and click "run selected tests'. The tests will run in the editor and display the amount passed or failed. You can see details in the console after closing the editor.
 
 Video detailing how to run Behavioral Tests from the Unity editor: https://www.youtube.com/watch?v=1_ZcGvITnes 
 
## Authors
 
  Prithvi Tippabhatla - prithvi@email.sc.edu

  Ayla Nickerson - aylan@email.sc.edu

  Colby Hill - colbyah@email.sc.edu

  Wade Lewis - wclewis@email.sc.edu

  Joe Basile - jjbasile@email.sc.edu


