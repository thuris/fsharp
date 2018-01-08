// computation expression

let myCode = 
    async {
        printfn "I AM STARTING"
        do! Async.Sleep 5000
        printfn "I AM DONE"
        return "THIS IS THE RESULT"
        }

myCode |> Async.RunSynchronously

let combinedCode = 
    async {
        printfn "START THE WHOLE THING"
        let x = 123
        let! result = myCode
        let! again = myCode
        return 42
    }

combinedCode |> Async.RunSynchronously

let foo = 
    [
        myCode
        myCode
        myCode
    ]
    |> Async.Parallel
    |> Async.RunSynchronously

seq {
    yield 1
    yield 2
    yield! 
        seq { yield 1; yield 2; }
    }
