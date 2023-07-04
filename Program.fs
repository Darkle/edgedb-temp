open EdgeDB

let client = EdgeDBClient()

let config =
    EdgeDBClientPoolConfig(SchemaNamingStrategy = INamingStrategy.DefaultNamingStrategy, ExplicitObjectIds = false)

let dbClient = EdgeDBClient(config)

[<CLIMutable>]
type Post =
    { myOptionalArrayOfStrings: string[] option }

[<EntryPoint>]
let main _ =
    task {
        try
            do! dbClient.ExecuteAsync("insert Post{myOptionalArrayOfStrings:=['hello', 'foo', 'bar']}")
        with err ->
            printfn "Error: %A" err
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously

    task {
        try
            let! results = dbClient.QuerySingleAsync<Post>("select Post{*} limit 1")

            printfn "Results: %A" results
        with err ->
            printfn "Error: %A" err
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously

    0
