# Python-Yolo-Wrapper-for-Unity-interactions

## Introduction
This source code has been developped to allow python and these libraries communicate with Unity Engine. This use case is using Ultralytics's YoloV8 and is able to send position information to unity in order to create interactions and animations with it.

## Prerequisites
- Unity `2022.3.13f1` or later
- Python `3.8` or later
- Make sure you have a webcam or a video file to test the project
- This installation guide has been tested on Linux and MacOS, but it should work on Windows too with some modifications

## Installation
Clone this public repo with wherever you want
```bash
git clone https://github.com/mathis-lambert/python-yolo-wrapper-for-unity-interactions yolo_with_unity
cd yolo_with_unity
```
*It's not a docker project for now, but it should be later...*

init the project with these commands :
this will create a virtual env and install the dependencies
```bash
cd python
python3 -m venv venv
source venv/bin/activate
make install
```

## Usage
### Unity
Open the project with **Unity `2022.3.13f1`** or later. You can find the project in the folder `UnityProject/`.
- Click on the ADD button in the Unity Hub and select the folder `UnityProject/`
- Select the project and click on the OPEN button

### Python
#### Execute scripts
Open a terminal and run these commands :
This will run the script `src/pywui/main.py` with the --help option to show you the available options
```bash
cd python
source venv/bin/activate
pywui --help
```

##### Examples
Use your webcam
```bash
pywui --source 0
```

Show the webcam output
```bash
pywui --source 0 --show
```

Use video file
```bash
pywui --source path/to/video.mp4
```

**NOTE: `pywui`only runs the script main.py, if you want to run a script from the `scripts/` folder, you have to use `python` instead of `pywui`**
```bash 
python scripts/the_script_you_want.py
```

#### Execute the tests
Open a terminal and run these commands :
```bash
cd python
source venv/bin/activate
pywui-test
```

## Unity use case
The use case is simple, the python script will send the position of the detected object to Unity. Then Unity will move the object to the position sent by python.

### Python
Run the command :
```bash
pywui --model ./models/yolov8s-pose.pt --detect-method track --source 0 --conf 0.5 --filter
```

### Unity
- Open the scene `Assets/Scenes/PeopleInteraction.unity`
- Click on the play button
- You should see as many avatar as people detected by the python script and the avatars should move to the position of the people detected

## Current issues
- `python3` might not work, use `python` instead
- If you have an error with `pywui` command, try to run `source venv/bin/activate` again and then `pywui` should work
- If you have an error with `pywui-test` command, try to run `source venv/bin/activate` again and then `pywui-test` should work

## Collaborate
If you want to collaborate on this open source repo, you're free to do so.
- Fork the repo
- Create your own branch
- Develop your feature
- And with a PR describe the purpose of your feature


