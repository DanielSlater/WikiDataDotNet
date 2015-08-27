module WikiDataDotNet.Test.RequestTests

open WikiDataDotNet.Request
open NUnit.Framework
open FsUnit
open System

[<Test>]
let ``request italy`` () =
    (request_entity "Q38").id |> should equal "Q38"

[<Test>]
let ``invalid request`` () =
    (fun () -> request_entity "notanid" |> ignore) |> should throw typeof<InvalidOperationException>

[<Test>]
let ``search returns results`` () =
    let result = search_english "headquarters of the united nations"
    printf "%A" result
    result.search.Length |> should equal 1

[<Test>]
let ``search with no results`` () =
    let result = search_english "325ngdsbjs;avn&14"
    printf "%A" result
    result.search.Length |> should equal 0