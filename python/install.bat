@echo off
echo Installation process...

echo Installing dependencies from requirements.txt...
pip install --force-reinstall -r requirements.txt
pip install torch torchvision torchaudio --index-url https://download.pytorch.org/whl/cu118

echo Installing package...
pip install -e .

echo Done.
pause