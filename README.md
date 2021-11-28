# GhostBusters Homework Report

#Team Members: Driss Jaidi and Mohammed Chaouni

#Version 4

In this project we play a game when we click a cell on the grid a color is displayed (red maybe on the ghost, orange one or two cells away, yellow three or 4 cells away, green 5 or more cells away) where we will have probabilities to guide us to the ghost location and bust it to the win the game.

This small project contains five scripts:
Game.cs: contains all primary functions of the program
Tile.cs: contains the variables of the grid (one tile constitutes one cell of the grid)
WinLose.cs: contains the scripting for winning and losing scenarios
ProbabilityText.cs: testing ground for displaying the text
GameOverScreen.cs: testing ground for displaying the game over image

The two most important scripts of this program are
Game.cs that contains the following functions:
Placeghost(): places the ghost at a random x and y

PlaseNoisyReading(): places a noisy reading from the ghost at a random x and y to mask its hiding

JointProbability(): takes the color and distance from the ghost as arguments and returns a probability
PlaceColor(): places all the colors according to the JointProbability() function

CheckInputGrid(): checks the last clicked grid cell and uncovers it the changes all probabilities using the bayesian equation in many ifs and for looops
P(ghost) = (JointProbability(color, distance)*P(ghost|click))/P(color)  with P(color) = Numberofcoloredcells/90 and P(ghost) defined from the joint probability table. so the closer we are to the ghost the higher probabilities get the further we are the lowest they get.

it also stores the last check x position and last checked y position in order to be used in the WinLose script in order to see if they are the ghost coordinates or not to determine if its a win or loss.

