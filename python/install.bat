@echo off
echo Installation process...

echo Installing dependencies from requirements.txt...
pip install --force-reinstall -r requirements.txt

echo Installing package...
pip install -e .

echo Installing PyTorch CUDA 11.8
pip install --upgrade --force-reinstall  torchvision torchaudio --extra-index-url https://download.pytorch.org/whl/cu118

echo Done.
pause