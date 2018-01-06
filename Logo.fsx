// Implementing highly simplified Logo turtle
open System
open System.IO
// First, the model of the domain of all possible turtles
// Possible directions the turtle can face (N, S, E, W -- implement 360-degree directions later)
type Direction = North | South | East | West 
type PenState = Up | Down
type Distance = int
type Command = Turn of Direction | Go of Distance | SetPen of PenState     
type Location = {X:int; Y:int}

type Turtle = {
    mutable direction:Direction
    mutable location:Location
    mutable penState:PenState
    }
     
type Line = {Begin:Location; End:Location}
 
let startDir = North
let startLoc = {X = 0; Y = 0}
let startPen = Up
let turtle = {direction = startDir; location = startLoc; penState = startPen}
let commandList:Command list = []
// For example, Turn North, SetPen Down, Go 10
// Create an appendable list of lines. When move commands are evaluated, those happening when penState is Down will create an entry to the list
let linesToDraw:Line list = [] 
let createLine (line:Line) : string =
    sprintf """<line x1="%i" y1="%i" x2="%i" y2="%i" style="stroke:rgb(255,0,0);stroke-width:2" /> """ line.Begin.X line.Begin.Y line.End.X line.End.Y

// Iterate through a list of commands. If pen is down, draw a line
let parseCommands commands =
    for i in commands do match i with 
    | Distance ->
    // Calculate next position
        match direction with
        | North -> let turtle = {turtle with location.Y = (y+i)}
        | South -> let turtle = {turtle with location.Y = (y-i)}
        | East -> let turtle = {turtle with location.X = (x+i)}
        | West -> let turtle = {turtle with location.X = (x-i)}
        
        // Draw line? if pen is down, draw a line; if pen is up, move without drawing
        match turtle.penState with
        | Down -> 
            // If pen is down, create a line with previous loc as start point and new loc as end point
            List.concat linesToDraw newLine -> linesToDraw // Add a line from position to newPosition to the list of linesToDraw
        // "<line x1="position.x" y1="position.y" x2="newPosition.x" y2="newPosition.y" stroke: rgb(255, 0, 0), stroke-width:2>"
        | Up -> return unit
// Update turtle location before going on to the next command    
        let turtle = {turtle with position = newPosition}
    | Facing ->
// Update turtle direction 
        let newFacing = i
        let turtle = {turtle with facing = newFacing}
// Update turtle pen state
    | PenState ->
        let turtle = {turtle with penState = newPenState}

// After all commands have been executed, complete the canvas element with a "</svg>" tag
let path = "../sampleAttempt.htm"
let completeCanvas htmlString = 
    File.WriteAllText (path, htmlString) 

do parseCommands commandList