open System.Text.RegularExpressions
open System.Runtime.InteropServices
open System.Runtime.Remoting.Messaging

let nTides = "ACCTGGTGTG"

//first using fold
let foldEm = for i in ['A';'C';'G';'T'] do
    Seq.fold iterate (fun x -> x = i) nTides -> results
    |> printf "%i" results

//next iterating with match
let matchEm = for i in nTides do
    match i with
    |'A'
    |'C'
    |'G'
    |'T'

//finally recursion
let rec recursEm input = 
    if input = 0 then input
    else input + recursEm (input - 1)
// document markup language

type DocumentBlock =
    |Paragraph of string
    |Title of string

let formatAsHtml (text:DocumentBlock) = 
    match text with
    |Paragraph(text) -> "<p>" + text + "</p>" 
    |Title(text) -> "<h1>" + text + "</h1>"

let testText = Paragraph("Hello")
printfn "%s" (formatAsHtml testText)

let formatAsMkdn (text:DocumentBlock) = 
    match text with
    |Paragraph(text) -> text + "  " 
    |Title(text) -> "#" + text
