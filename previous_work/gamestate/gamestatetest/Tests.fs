module Tests

open System
open Xunit
open GameState

[<Fact>]
let ``My test`` () =
    Assert.True(true)

[<Fact>]
let ``Plus or Minus`` () =
    let path =
        match PathFinder.solve 0 5 (fun f -> seq { yield f - 1; yield f + 1 }) with
        | Some p -> p
        | None -> []
        |> List.toSeq
    let expected:int list = [0; 1; 2; 3; 4; 5]
    Assert.Equal(expected, path)

let hanoi (towers:(int list)[]) =
    let count = Array.length towers
    seq {
        for i in 0 .. count do
            for j in 0 .. count do
                if i <> j && (not towers.[i].IsEmpty) && (towers.[j].IsEmpty || (towers.[i].Head < towers.[j].Head)) then
                    yield seq { 
                        for k in 0 .. count do 
                            if k = i then 
                                yield towers.[i].Tail
                            elif k = j then
                                yield towers.[i].Head :: towers.[j]
                            else
                                yield towers.[k]
                        }
                        |> Seq.toArray
    }

let buildHanoi towers discs =
    seq {
        yield [ 0 .. discs ]
        for i in 1 .. towers do
            yield []
    }
    |> Seq.toArray
                


[<Fact>]
let ``Hanoi 2x1`` () =
    let h = buildHanoi 2 1
    let g = Array.rev h
    let path = 
        match PathFinder.solve h g hanoi with
        | Some p -> p
        | None -> []
        |> List.toSeq
    let expected = List.toSeq [[|[0];[];[]|];[|[];[];[0]|]]
    Assert.Equal(expected, path)
