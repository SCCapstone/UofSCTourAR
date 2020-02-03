
# UofSCTourAR
This repository contains the files for our Capstone Senior Design project pertaining to CSCE 490 & 492.
*Still work in progress, more to come soon*

## Build Settings
 - File > Build Settings > Player Settings 
 - Make sure Company Name is UofSCTourAR
 - Update version if needed
 - Target minimum iOS version: 11.0 
 - Architecture: ARM64
 

## Technologies
  - Unity
  - iOS: 12.1.2 or later (*Soon to be iOS 13*)

Unity: 
  - Version 2019.2.11f1
  - iOS Build Support
  - Mac Build Support

Packages: 
  - AR Foundation: 2.1.4
  - AR Subsystems: 2.1.1
  - ARKit XR Plugin: 2.1.2
 
 
## Setup
 > Currently there are no one-time setup instructions for this app
 

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
 1. First, in the Unity Editor: Open the Test Runner by Navigating to Window -> General -> Test Runner.
 2. From the Test Runner popup window, select the "SceneLoader" test file.
 3. Click "Run Selected" inside the Test Runner window.
 
### Behavioral Tests
To run the UI tests on our project, begin by downloading and configuring the project according to the instructions above. 
In the Unity Editor, navigate to the Windows tab>AltUnityTester to open the AltUnityTester Editor. Within the Editor, expand the Assembly-CSharp-Editor.dll folder. Expand the Unity folder and select the tests you wish to run. To test within the Unity editor, select the Editor radio button, and click "Run Selected Tests".
 
## Authors
 
  Prithvi Tippabhatla - prithvi@email.sc.edu

  Ayla Nickerson - aylan@email.sc.edu

  Colby Hill - colbyah@email.sc.edu

  Wade Lewis - wclewis@email.sc.edu

  Joe Basile - jjbasile@email.sc.edu


