// functions

let add (x:int) y = x + y
add 1 2 

// "typical" languages: a function take 1 thing = arguments,
// gives you back one thing = output
let alsoAdd (x,y) = x + y
alsoAdd (1,2)
// this is a tuple

// what's the benefit?

// partial application
let add42 = add 42
add42 1

// piping
1 |> add42

// ? add42 with tuple form

let alsoAdd42 x = alsoAdd(x,42)

let f x y z = x + y + z
let g = f 1 

// typical pattern: have a fully expanded signature,
// then use it in specialized form using partial application

let isThisCharEqualTo (theChar:char) x = theChar = x
let isItAnA = isThisCharEqualTo 'A'

// Repository pattern
// Separate persistence from domain

// this is a Record: not a tuple, "immutable class" / named fields
type Customer = { Name:string; Age:int; }

let findCustomers (query: (Customer -> bool)) (dataSource:Customer seq)=
    dataSource |> Seq.filter (fun x -> query x)

// Name is a property on Customer, which we defined
let named name (customer:Customer) = (customer.Name = name)

// partial application
let findCustomersNamed name = findCustomers (named name)

let findCustomersWhoAreAdults = findCustomers (fun customer -> customer.Age >= 21)
// let findCustomersWhoAreAdults : Customer seq -> Customer seq = findCustomers (fun customer -> customer.Age >= 21)

// Fira Code: ligatures

let data = [ { Name = "Shawn"; Age = 1 }; { Name = "Mathias"; Age = 24 }]

data |> findCustomersNamed "Shawn"


//let test = findCustomersWhoAreAdults data |> Seq.toList

// records

type Foo = { Bar:string; Baz: int list }
// type NotFoo = { Bar:string; Baz: int list }
type AnotherFoo = {
    // another foo will ALWAYS contain these things
    // and they need to be supplied when you construct it
    This:int
    That:float
    Whatever:string
    }
    // if you ask for it, another foo will give you this,
    // based on the data "this" = itself contains
    with 
        member this.CapitalizedWhatever = 
        "CAPITALIZED: " + this.Whatever.ToUpperInvariant () 
        member this.IsAdult = this.This > 21
    
let isAdultDoneAnotherWay (x:AnotherFoo) = x.This > 21

let anotherFoo = { This = 1; That = 2.0; Whatever = "lowercase" }

let foo1 = { Foo.Bar = "BAR"; Baz = [ 1; 2; 3 ] }
let foo2 = { Bar = "BAR"; Baz = [ 1; 2; 3 ] }

// value-wise equality
// reference equality vs ??? equality
// Domain Driven Design
foo1 = foo2
let foo3 = { foo2 with Bar = "SOMETHING ELSE" }


// unit: what is it, why is it useful?

// F# is expression based
// methods/functions : return something
// vs. procedures : return nothing, they "do" something

let printSomething (x:int) =
    printfn "%i" x
    // return "void", which is denoted as "unit"

let result = printSomething 42

// "a unit of work has been completed"
// a side-effect is happening

// expression based means: everything evaluates to something
// or: you ALWAYS get back something

let print () =
    printfn "SOMETHING"

print ()

// unit, (), ignore, ignore ()

ignore ()

// this is used to placate the compiler, and be explicit:
// if you have an intentional side-effect in the middle of
// your code, this will suppress warnings: "yes, I mean it"
printfn "BAC" |> ignore


(*
C#-ish version
public void PrintIt(int x) 
{
    Console.WriteLine(x);
    // return 
}
var result = PrintIt(42);
*)

// generics
// mostly applies to containers: sometimes you want to work on
// "things", doesn't matter what the thing is

let myFilter = Seq.filter
// ' = tick marks a generic, "what this things is specifically doesn't matter"
let map = Seq.map

// 'a list is equivalent to list<'a>