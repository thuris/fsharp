open System.Text.RegularExpressions
open System.Runtime.InteropServices
open System.Runtime.Remoting.Messaging

let nTides = "ACCTGGTGTG"

//first using fold
let foldEm = for i in ['A';'C';'G';'T'] do
    Seq.fold iterate (fun x -> x = i) nTides -> results
    printf "%i" results

//next iterating with match
let matchEm = for i it nTides do
    match i with
    |'A'
    |'C'
    |'G'
    |'T'

//finally recursion
let rec recursEm input = 
    if input = 0 then input
    else input + recursEm (input - 1)