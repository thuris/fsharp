// can we do one pass and count as we go
// [ 'A'; 'C' ] |> count
// count -> format and print
// read file and count
// can we abstract this even more: given a string and a list of chars, count them and print them


// type annotation
// predicate
// type inference
//let isThisA (c:char) = 
  //  (c = 'A')

//let isThisTwo x = 
    //(x = 2)

// let isThisC = fun (c:char) -> if c = 'C' then true else false
let sample = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"

let isEqual (charToMatch:char) = fun (c:char) -> c = charToMatch

let countTotal (letter:char) =
    String.filter (isEqual letter) sample 
    |> String.length

// test
let totalA = countTotal 'A'
let totalC = countTotal 'C'
let totalG = countTotal 'G'
let totalT = countTotal 'T'

//printfn "%i %i %i %i" (countTotal 'A') (countTotal 'C') (countTotal 'G') (countTotal 'T')

//[ 1 .. 20 ] |> List.map (fun x -> x * x)

// can we use List.map to get the count for the 4 chars?
List.map (fun charToMatch -> countTotal charToMatch) [ 'A'; 'C'; 'G'; 'T' ]

//let add x y = x + y
//let div x y = x / y

add 1 2
div 4 2
2 |> div 4
// often the most important arg will be last in a function

2 
|> add 1 
|> add 2 
|> add 27




