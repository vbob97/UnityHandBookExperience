# Unity Hand Book Experience - Unity Project
Welcome to the Hand Book Experience Unity project! This project enables an immersive experience where a 3D book is opened and navigated(work in progres) using hand movements captured through motion tracking.

## Repository Overview

- **[Python Unity Hand Tracker](https://github.com/vbob97/PythonUnityHandTracker/tree/master)**
  - The Python repository provides the necessary code for hand tracking and capturing hand movements. This data is then sent to Unity for integration with the 3D book viewer.

## How It Works

1. **Hand Tracking**: The Python script uses the `cvzone` library to track hand movements in real-time through a webcam.

2. **Motion Capture**: Hand landmark data is captured and sent to the Unity application via a UDP socket connection.

3. **Unity 3D Book Viewer**: The Unity project utilizes the received hand movement data to control the opening and navigation of a 3D book.

## Setup

1. Clone this Unity repository to your local machine.

2. Open the Unity project and configure the UDP receiver to listen for hand movement data.

3. Run the Python script from the [Python Unity Hand Tracker](https://github.com/vbob97/PythonUnityHandTracker/tree/master) on a machine with a webcam.

4. Enjoy the immersive 3D book experience by interacting with the book using hand gestures!

## Requirements

- Unity (version X.X.X)
- Python 3.x
- OpenCV (cv2)
- cvzone library
- Webcam

For the Python script dependencies, please refer to the [Python Unity Hand Tracker](https://github.com/vbob97/PythonUnityHandTracker/tree/master) for the `requirements.txt` file.

## Configuration

- Adjust the UDP socket configuration in both the Python script and the Unity project to ensure seamless communication.

## Contributions and Issues

If you encounter any issues or have suggestions for improvement, feel free to open an issue in the respective repositories.

Happy reading and exploring the Unity Hand Book Experience!
