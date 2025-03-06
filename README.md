# Python-Yolo-Wrapper-for-Unity-interactions
# Português 🇧🇷 

## Introdução
Este código-fonte foi desenvolvido para permitir a comunicação entre Python e a Unity Engine utilizando bibliotecas especializadas. Neste caso, usamos o YoloV11 da Ultralytics para enviar informações de posição para a Unity, possibilitando a criação de interações e animações.

## Pré-requisitos
- Unity `2022.3.13f1` ou superior
- Python `3.12`
- Certifique-se de ter uma webcam ou um arquivo de vídeo para testar o projeto

## Método Automático

### Instalação Automática  

Acesse a página de lançamentos do nosso repositório e baixe o instalador:  
[Releases - Python-Yolo-Wrapper-for-Unity-interactions](https://github.com/unitedgamesbr/Python-Yolo-Wrapper-for-Unity-interactions/releases)  

1. Extraia os arquivos na pasta onde deseja instalar o **pywui**.  
2. Execute o arquivo `install.bat`.  
3. Aguarde a conclusão da instalação.  

### Execução Automática  

1. Execute o arquivo `run.bat`.  
2. Selecione a câmera que deseja usar.  
3. Aguarde o script iniciar o Yolo.  
>[!NOTE]
>O `run.bat` está configurado para usar o modelo `yolo11n-pose.pt` rodando na GPU, com confiança de 0.8, backend `dshow` e método de detecção `predict`.

---

## Método Manual  
>[!TIP]
> Caso prefira realizar a instalação manualmente, siga este guia.  
> Além disso, você pode utilizá-lo para compreender e modificar os arquivos `.bat` originais.

### Instalação Manual  

Clone este repositório público no diretório desejado:
```bash
git clone https://github.com/unitedgamesbr/Python-Yolo-Wrapper-for-Unity-interactions.git pywui
cd pywui
```

Crie um ambiente virtual e instale as dependências:
```bash
cd python
python3 -m venv venv
venv\Scripts\activate
install.bat
```

Reinstale o PyTorch com suporte a CUDA:
```bash
pip install --upgrade --force-reinstall torchvision torchaudio --extra-index-url https://download.pytorch.org/whl/cu118
```

---

## Uso

### Execução Manual (Python)  

Caso queira modificar ou criar seu próprio `run.bat`, siga estas instruções.

#### Executando os Scripts  
Abra um terminal e execute os seguintes comandos:  
Isso executará o script `src/pywui/main.py` com a opção `--help`, exibindo as opções disponíveis:
```bash
cd python
venv\Scripts\activate
pywui --help
```

#### Exemplos de Uso  

- Utilizar a webcam:
```bash
pywui --source 0
```

- Exibir a saída da webcam:
```bash
pywui --source 0 --show
```

- Utilizar um arquivo de vídeo:
```bash
pywui --source path/to/video.mp4
```

- Alterar o backend da câmera:  
O backend padrão é `dshow`. Caso esteja usando uma câmera virtual ou uma câmera incompatível com o DirectShow, tente o **Microsoft Media Foundation**:
```bash
pywui --backend msmf
```

> **Nota:** `pywui` executa apenas o script `main.py`. Para executar um script dentro da pasta `scripts/`, use `python` diretamente:
```bash
python scripts/nome_do_script.py
```

---

### Executando os Testes  

Abra um terminal e execute:
```bash
cd python
venv\Scripts\activate
pywui-test
```

---

## Problemas Conhecidos  

- O comando `python3` pode não funcionar em alguns sistemas. Caso ocorra um erro, utilize `python` no lugar.  
- Se o comando `pywui` não for reconhecido, tente rodar `venv\Scripts\activate` novamente antes de executá-lo.  
- Se houver erro ao executar `pywui-test`, ative o ambiente virtual novamente (`venv\Scripts\activate`) e tente rodá-lo novamente.  

# English 🇬🇧 

## Introduction
This source code has been developped to allow python and these libraries communicate with Unity Engine. This use case is using Ultralytics's YoloV11 and is able to send position information to unity in order to create interactions and animations with it.

## Prerequisites
- Unity `2022.3.13f1` or later
- Python `3.12` 
- Make sure you have a webcam or a video file to test the project


## Automatic Method
### Automatic Install 

Take a look at our releases page, download the installer.
 
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

