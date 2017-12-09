//Dec 3

let xs = [-1; -3; -2]
let maxval =
    Seq.fold (fun state x -> if x >= state then x else state ) 0 xs 

let maxvalOption xs =
    Seq.fold (fun state x -> 
        match state with 
        | None -> Some x
        | Some localMax -> if x >= localMax then Some x else Some localMax
        ) None xs 

maxvalOption ["A"; "AB"]

Seq.