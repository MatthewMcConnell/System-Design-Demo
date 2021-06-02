# Game System Design Demo

## Game Description

This is a game where you are manually dealing with energy emitting particles in a nuclear plant. Particles will appear of different shapes and colours that you need to decrease the energy of. You decrease the energy of a particle by clicking on it.

However, each particle has a certain energy contained within based on the colour and shape of it (e.g. blue triangle = 2 + 3 = 5 energy contained within):

Shapes:
- Square = 1
- Triangle = 2
- Circle = 3

Colours:
- Red = 1
- Green = 2
- Blue = 3
- Yellow = 4

Be careful when clicking though, as clicking a particle too much will give it negative energy!

The nuclear plant has a max excess energy it can hold. Keep the excess energy below the max to survive. It's not all bad news though as after each level your excess energy is halved. Good luck!

## System Design

The three most important parts of the system are the Particle, Game Manager, and Level classes. The game manager creates a level object with a seed. The level object will then spawn particles in a level based on the seed. Finally, the particle reports back to the game manager when it's energy is emitted to allow the game manager to update the UI.

There are other things like enums (e.g. particle characteristics) and small scripts attached to objects (e.g. score class to update the energy). One other example of OOP is the inheritance and polymorphism used for Levels - there exists a batched level which inherits from the base level class but spawns particles in waves instead of all at once.

## Where can you play the game?

You can play the game on [itch.io](https://musical-spearman.itch.io/nuclear-particles)