namespace GameState
open System.Collections.Generic
open System

module Say =
    let hello name =
        printfn "Hello %s" name

module PathFinder =
    type State<'a> =
        { 
            data: 'a;
            path: 'a list
        }

    let solve (start:'a) (goal:'a) (search:'a -> seq<'a>) =
        let mutable visited = Map.empty.Add(start, [start])
        let mutable queue = new Queue<'a list>()
        queue.Enqueue(visited.[start])
        let mutable found = false
        while not found && queue.Count > 0 do
            let current = queue.Dequeue()
            for adj in search current.Head do
                if not (visited.ContainsKey adj) then
                    let path = adj :: current
                    visited <- visited.Add(adj, path)
                    if adj = goal then
                        found <- true
                    else
                        queue.Enqueue(path)
        if found then
            visited.[goal]
                |> List.rev
                |> Some
        else
            None
