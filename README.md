# T-REG-HMI

T-REG-HMI (Turing Reinforcement learning EGxperiment/ Human Machine Interaction) is a project arising from REG Hack Week 2023.
It is a companion to [T-REG](https://github.com/alan-turing-institute/T-REG) which uses Reinforcement Learning to try to teach a 3D model of a T.rex to walk.

The goal of T-REG-HMI is to produce a Unity scene containing the same 3D T.rex model as is used in T-REG, but to have it human-controlled, with the aim of creating a "beat-the-AI" game, where people can attempt to make the dinosaur walk further than the best effort from the RL agent.

This game can be deployed as either a browser-based web app, a VR app on the Oculus/Meta Quest 2, or (soon) as a remotely controlled webapp that could be played (for example) on a big screen, while controlled by a phone app.
Details of each of these are below:

## Webapp

The `main` branch of this repo represents the baseline Unity scene that can be build as a WebGL app that can be played on a browser, and controlled via a keyboard.
The keys to control the dinosaur are as follows:
```
"q": move left leg forward.
"w": move left leg back.
"o": move right leg forward.
"p": move right leg back.
"d": move tail left.
"f": move tail right.
"z": open jaw.
"x": close jaw.
```

Instructions on how to build and deploy this game on Azure can be found [here](Builds/README.md).


## VR app

The `VR2` branch of this repo includes the Unity "XR Interaction Toolkit" and the "Open XR" plugin, to allow it to work on the Oculus/Meta Quest 2.

The controls here are as follows:
```
left stick: move
right stick: turn (snap turns left and right)
trigger buttons: move leg forward (left and right)
grip buttons: move leg back (left and right)
"X", "A" buttons: move tail.
"Y", "B" buttons: open/close jaw.
```

## Remotely controlled app

TBD.
