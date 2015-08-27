module private WikiDataDotNet.Common
open System.Net
open System
open System.IO

let WikiDataRootUrl = "https://www.wikidata.org/w/api.php?format=json&action="

// Fetch the contents of a web page
let private fetch_url callback (url : string) =        
    let req = WebRequest.Create(Uri(url)) 
    use resp = req.GetResponse() 
    use stream = resp.GetResponseStream() 
    use reader = new IO.StreamReader(stream) 
    callback reader

let private url_to_string url = 
    fetch_url (fun reader -> reader.ReadToEnd()) url

let query_wiki_data action qs =
    let url = WikiDataRootUrl + action + "&" + qs
    url_to_string url

let is_not_null input =
    match box input with
        | null -> false
        | _ -> true