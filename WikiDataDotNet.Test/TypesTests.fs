module WikiDataDotNet.Test.TypesTests

//open WikiDataDotNet.Helper
open NUnit.Framework
open FsUnit
open System.IO
open Newtonsoft.Json

[<Test>]
let ``deserialize entity`` () =
     use stream = new StreamReader ("../../../QueryResults/entity.json")
     let str = stream.ReadToEnd()
     let obj = JsonConvert.DeserializeObject<WikiDataDotNet.Types.Entity>(str)
     printf "%A" obj
     obj.id |> should equal "Q38"

[<Test>]
let ``deserialize data`` () =
     use stream = new StreamReader ("../../../QueryResults/data.json")
     let str = stream.ReadToEnd()
     let obj = JsonConvert.DeserializeObject<WikiDataDotNet.Types.Data>(str)
     printf "%A" obj
     obj.success |> should equal 1

[<Test>]
let ``deserialize search`` () =
     use stream = new StreamReader ("../../../QueryResults/search.json")
     let str = stream.ReadToEnd()
     let obj = JsonConvert.DeserializeObject<WikiDataDotNet.Types.Search>(str)
     printf "%A" obj
     obj.success |> should equal 1
