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
