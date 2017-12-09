open System.IO
open System.Collections
open System.Xml.Schema
open System.Runtime.InteropServices
open System.Runtime.InteropServices
open System.Web.UI.WebControls
open System.Text.RegularExpressions
open System.Web.Services.Protocols
open System.Security.Policy
open System.Windows.Forms.VisualStyles.VisualStyleElement

// FOLLOWING IS SLIGHTLY ABSTRACTED FROM NEEDING A SEPARATE CODE BLOCK FOR EACH LETTER
let ntCount =
    let inputString = "ACTGTGGACAGTGT"
    //let inputLength = String.length(inputString)
    //A=3 C=2 G=5 T=4
    let searchList = ['A'; 'C'; 'G'; 'T']
    for charToMatch in searchList do
        //let charToMatch = i
        let total =
            String.filter(fun x -> x = charToMatch) inputString 
            |> String.length
        printf "%i " total     

// FOLLOWING IS AN ATTEMPT AT REWRITING SEQ.FILTER
    let selectOrNot seqChar charToMatch = (seqChar = charToMatch)
    let inputString = "ACTGTGGACAGTGT" |> List.ofSeq
    let searchList = List.distinct ['A'; 'C'; 'G'; 'T']
    let outputString = List.empty
    let myFilter input charToMatch =
        for j in input do
            match selectOrNot j charToMatch with
                | true -> List.append outputString j
                | false -> ignore
        let total = List.length outputString
        printf "%i " total

    let search =
        for k in searchList do
            myFilter (inputString) k
    
    do search

// List
// Seq.fold    