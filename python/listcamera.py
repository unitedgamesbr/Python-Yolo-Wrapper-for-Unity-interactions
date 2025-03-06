import cv2
import platform

def list_cameras():
    system = platform.system()
    cameras = []

    if system == "Windows":
        try:
            from pygrabber.dshow_graph import FilterGraph 
            graph = FilterGraph()
            devices = graph.get_input_devices() 
            for index, name in enumerate(devices):
                cameras.append((index, name))
        except ImportError:
            print("Instale 'pygrabber' para obter os nomes reais das cameras no Windows: pip install pygrabber")
    elif system == "Linux":
        import subprocess
        try:
            result = subprocess.run(["v4l2-ctl", "--list-devices"], capture_output=True, text=True)
            lines = result.stdout.split("\n")
            index = 0
            for i in range(len(lines)):
                if lines[i].strip() and not lines[i].startswith("\t"):
                    camera_name = lines[i].strip()
                    if (i + 1 < len(lines)) and lines[i + 1].startswith("\t/dev/video"):
                        cameras.append((index, camera_name))
                        index += 1
        except FileNotFoundError:
            print("Instale 'v4l2-utils' para listar cameras no Linux: sudo apt install v4l2-utils")
    elif system == "Darwin":
        print("No macOS, obter nomes de cameras requer métodos diferentes (AVFoundation).")

    return cameras

if __name__ == "__main__":
    cameras = list_cameras()
    if cameras:
        print("Cameras:")
        for cam_id, cam_name in cameras:
            print(f"ID: {cam_id} - Name: {cam_name}")
    else:
        print("Nenhuma camera encontrada.")
