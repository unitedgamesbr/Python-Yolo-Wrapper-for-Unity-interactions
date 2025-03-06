# Python-Yolo-Wrapper-for-Unity-interactions

## Introduction
This source code has been developped to allow python and these libraries communicate with Unity Engine. This use case is using Ultralytics's YoloV11 and is able to send position information to unity in order to create interactions and animations with it.

## Prerequisites
- Unity `2022.3.13f1` or later
- Python `3.12` 
- Make sure you have a webcam or a video file to test the project


## Automatic Method
### Automatic Install 

Take a look at our releases page, download our installer.
 
https://github.com/unitedgamesbr/Python-Yolo-Wrapper-for-Unity-interactions/releases

1. Unzip contents inside the folder you want to install pywui
2. Run install.bat
3. Wait for the Instalation to finish.

### Automatic Execution 

1. Run run.bat   
2. Select your camera  
3. Wait for the script to launch yolo

>This run.bat is configured to use the yolo11n-pose.pt model running on gpu, 0.8 confidence, dshow backend and predict detection method.

## Manual Method  
>If you for some reason prefer the manual install way, you can follow this guide.  
>Also you can use this to understand and edit the original .bat files.

## Installation


#### Manual Install

Clone this public repo with wherever you want
```bash
git clone https://github.com/unitedgamesbr/Python-Yolo-Wrapper-for-Unity-interactions.git pywui
cd pywui
```

To create a virtual env and install the dependencies

```bash
cd python
python3 -m venv venv
venv\Scripts\activate
install.bat
```
Then reinstall the Pytorch with CUDA support:

```bash
pip install --upgrade --force-reinstall  torchvision torchaudio --extra-index-url https://download.pytorch.org/whl/cu118
```

## Usage

### Python
#### Manual Execution
You can use these instructions to modify and create your own run.bat  
  
#### Execute scripts
Open a terminal and run these commands :
This will run the script `src/pywui/main.py` with the --help option to show you the available options
```bash
cd python
venv\Scripts\activate
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

Change the camera backend
default is dshow, if you are using a virtual camera or a camera not compatible with direct show, you can try microsoft media foundation:  
```bash
pywui --backend msmf
```

**NOTE: `pywui`only runs the script main.py, if you want to run a script from the `scripts/` folder, you have to use `python` instead of `pywui`**
```bash 
python scripts/the_script_you_want.py
```

#### Execute the tests
Open a terminal and run these commands :
```bash
cd python
venv\Scripts\activate
pywui-test
```

## Current issues
- `python3` might not work, use `python` instead
- If you have an error with `pywui` command, try to run `venv\Scripts\activate` again and then `pywui` should work
- If you have an error with `pywui-test` command, try to run `venv\Scripts\activate` again and then `pywui-test` should work

