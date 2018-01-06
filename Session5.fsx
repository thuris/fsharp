(*
TODO
- Handle line thickness generally
- Handle line color generally
x in assemble html, use the line list input
*)

(*
suppose the turtle is now in Postion something
support you receive "MOVE 50" and the angle is 0
what should be the line?
take a single move instruction, and transform that into a html file
State = Position, Orientation, Pen Up / Down / Whatever else
the function we need is probably something like this:
State -> Logo Instruction -> State + Line
*)

type Logo = 
    | Move of int // how many pixels

open System.IO

let path = "../sampleAttempt.htm"

let completeCanvas htmlString =
    File.WriteAllText (path, htmlString) 

type Coordinate = { 
    X:int
    Y:int
    }

type Line = {
    Begin:Coordinate
    End:Coordinate
    }


let createLine (line:Line) : string =
    sprintf """<line x1="%i" y1="%i" x2="%i" y2="%i" style="stroke:rgb(255,0,0);stroke-width:2" /> """ line.Begin.X line.Begin.Y line.End.X line.End.Y

[ "A";"B";"C" ] |> String.concat ""

[ "A";"B";"C" ] 
|> Seq.fold (fun accumulated block -> accumulated + " ! " + block) "THIS IS WHAT I GOT: "


let assembleHtml (lines: list<Line>) : string =
    let content = 
        Seq.map (fun line -> createLine line) lines
        |> String.concat ""  
    let setCanvas = """<svg height="400" width="400">""" + content + """</svg>"""
    setCanvas


let line1 = {
    Begin = { X = 10; Y = 10 }
    End = { X = 100; Y = 100}
    }

let line2 = {
    Begin = { X = 50; Y = 10 }
    End = { X = 120; Y = 50}
    }

let input = [ line1; line2 ]

input 
|> assembleHtml 
|> completeCanvas

// completeCanvas """<svg height="210" width="500">
//   <line x1="0" y1="0" x2="200" y2="200" style="stroke:rgb(255,0,0);stroke-width:2" />
// </svg>"""

(*
 <svg height="210" width="500">
  <line x1="0" y1="0" x2="200" y2="200" style="stroke:rgb(255,0,0);stroke-width:2" />
</svg> 
*)