# Webcam Unity Calibration

This application is a helper application for OpenARK's calibration module. It uses 7 oritentations of 3x4 chessboard corners to compute a RT transform between real-world coordinates and Unity coordinates seen from the perspective of a Vuforia webcam feed.

At a Glance

  - **Technology stack**: Unity, C#
  - **Status**:  Beta 0.8

## Dependencies
Hardware
- Depth Camera
- RGB Camera
- 3x4 standard chessboard (3cm x 3cm black and white squares)

Software
- OpenARK 0.8
- Unity 5

## Installation

1. Download and install all software depedencies (Unity, OpenARK)
2. Clone repo to local machine
3. Run OpenARK's Calibration module and WebcamUnityCaliration

## Configuration

1. Print out a standard 3x4 chessboard (3cm x 3cm black and white squares)
2. Start OpenARK's Calibration module and GlassUnityCalibration at the same time
3. Unity will show a virtual 3x4 chessboard
4. Align the real chessboard with the virtual chessboard
5. Press 'space' in OpenARK to record coordinate pairing at current orientation
6. Press 'space' in Unity to move on to the next orientation
7. Once all 5 orientations have been recorded, OpenARK will output RT_Transform.txt which contains the calibartion matrices

## Known issues

A custom calibration between real world space and Unity space is best done for each person.

## Getting help

If you have questions, concerns, bug reports, etc, please file an issue in this repository's Issue Tracker.

## Getting involved

The Center for Augmented Cognition welcome interested industry partners to join our alliance to support the Open ARK platform. More information can be found on cac.berkeley.edu

----

## Credits and references

Bill Zhou, Will Huang
