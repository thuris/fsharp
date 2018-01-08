(*
TODO
Does this thing run?
Can we do Turn West, and not Turn(West)
Angles
mutable: by default, avoid?
*)

// Implementing highly simplified Logo turtle
open System
open System.IO
open System.Security.Cryptography
// First, the model of the domain of all possible turtles
// Possible directions the turtle can face (N, S, E, W -- implement 360-degree directions later)
type Direction = North | South | East | West 
type PenState = Up | Down
type Distance = int
type Command = 
    | Turn of Direction 
    | Go of Distance 
    | SetPen of PenState     
type Location = {X:int; Y:int}

type Turtle = {
    direction:Direction
    location:Location
    penState:PenState
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

let applyCommand (command:Command) (turtle:Turtle) =
    match command with 
    | Go(distance) ->
    // Calculate next position
        match (turtle.direction) with
        | North -> { turtle with location = { turtle.location with Y = (turtle.location.Y+distance) } }
        | South -> { turtle with location = { turtle.location with Y = (turtle.location.Y-distance) } }
        | East -> { turtle with location = { turtle.location with X = (turtle.location.X+distance) } }
        | West -> { turtle with location = { turtle.location with X = (turtle.location.X-distance) } }
    | Turn(newFacing) ->
// Update turtle direction 
        { turtle with direction = newFacing }
// Update turtle pen state
    | SetPen(newPenState) ->
        { turtle with penState = newPenState }

turtle 
|> applyCommand (Go 10)
|> applyCommand (Turn East)
|> applyCommand (Go 20)

[ 
    Go 10 
    Turn East
    Go 20 
] 
|> List.fold (fun turtle cmd -> applyCommand cmd turtle) turtle 

let rec turtlePairs (pairs:(Turtle*Turtle) list) (currentTurtle:Turtle) (commands: Command list) =
    match commands with
    // we are done, no more commands in the list
    | [] -> pairs |> List.rev
    // we have commands, let's take the first one
    | cmd :: rest ->
        let nextTurtle = applyCommand cmd currentTurtle
        let updatedPairs = (currentTurtle,nextTurtle) :: pairs
        turtlePairs updatedPairs nextTurtle rest

let testCommands = 
    [ 
        SetPen Down
        Go 10 
        Turn East
        Go 20 
    ] 
let test = turtlePairs [] turtle testCommands

// if pen down we add to list

type TurtlePair = Turtle * Turtle
let keepTurtlePairsToDraw (pairs:TurtlePair list) = 
    pairs
    |> List.filter (fun (before,_) ->
        before.penState = Down
        )

keepTurtlePairsToDraw test

let turtlePairsToLines (pairs:TurtlePair list) =
    pairs
    |> List.map (fun (before,after) ->
        {
            Begin = before.location
            End = after.location
        }
        )

test |> keepTurtlePairsToDraw |> turtlePairsToLines

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