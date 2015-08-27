module WikiDataDotNet.Request
open Common
open Types
open System.Web
open Newtonsoft.Json

/// <summary>
/// Request a single entity from wiki data. Throws InvalidOp if entity can't be found
/// </summary>
/// <param name="id">The id you want to look up</param>
let request_entity (id : string) : Entity =
    let stringData = query_wiki_data "wbgetentities" ("ids=" + id)
    let data = JsonConvert.DeserializeObject<Data>(stringData)

    if (is_not_null data.entities) && data.entities.ContainsKey(id) then
        data.entities.[id]
    else
        invalidOp (sprintf "Could not find id %s" id)

/// <summary>
/// Request a set of entities
/// </summary>
/// <param name="ids">sequence of ids for the entities you want</param>
let request_entities (ids : seq<string>) : Map<string, Entity> =
    let idString = ids |> Seq.reduce (fun x y -> x + "|" + y)
    let data = JsonConvert.DeserializeObject<Data>(idString)
    if is_not_null data.entities then
        invalidOp (sprintf "Error loading entities %A" ids)
    data.entities

/// <summary>
/// Search wiki data for a given set of text
/// </summary>
/// <param name="langauge">langauge we are searching in</param>
/// <param name="text">text we are searching for</param>
let search (langauge : string) (text : string) : Search =
    let stringData = query_wiki_data "wbsearchentities" ("search=" + HttpUtility.UrlEncode(text) + "&language=" + HttpUtility.UrlEncode(langauge))
    JsonConvert.DeserializeObject<Search>(stringData)

/// <summary>
/// Search using english langauge
/// </summary>
/// <param name="text"></param>
let search_english (text : string) : Search =
    search "en" text