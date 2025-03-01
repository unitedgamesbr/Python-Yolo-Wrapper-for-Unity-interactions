from setuptools import setup, find_packages
from pathlib import Path


def parse_requirements(file_path: Path):
    """
    Parse a requirements.txt file, ignoring lines that start with '#' and any text after '#'.

    Args:
        file_path (str | Path): Path to the requirements.txt file.

    Returns:
        (List[str]): List of parsed requirements.
    """

    requirements = []
    for line in Path(file_path).read_text().splitlines():
        line = line.strip()
        if line and not line.startswith('#'):
            # ignore inline comments
            requirements.append(line.split('#')[0].strip())

    return requirements


print(find_packages(where='src'))

setup(
    name='pywui',
    description='Use Ultralytics YOLO V11    to take the control of scene objects in unity.',
    version='0.1',
    packages=find_packages(where='src'),
    url='https://github.com/unitedgamesbr/Python-Yolo-Wrapper-for-Unity-interactions/',
    install_requires=parse_requirements(
        Path(__file__).parent / 'requirements.txt'),
    entry_points={
        'console_scripts': [
            'pywui=pywui:main',
            'pywui-test=pywui:test'
        ]
    },
)
