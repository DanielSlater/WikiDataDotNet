module WikiDataDotNet.Types

type LangaugeValue = {
    language : string
    value : string
    }

type WikibaseEntityid = {
    ``entity-type``: string
    ``numeric-id``: int
    }

type DataValueValue =
    | DataValueValue of string
    | WikibaseEntityid

type DataValue ={
    value : Newtonsoft.Json.Linq.JToken
    ``type`` : string
    }

type MainSnak ={
    property : string
    snaktype : string
    datavalue : DataValue
    }

type Claim = {
    id : string
    rank : string
    ``type`` : string
    mainsnak : MainSnak
    }

type SiteLink = {
    site : string
    title : string
    badges : string list
    }

type Entity = {
    title : string
    id : string
    ns : int
    lastrevid : int
    modified : System.DateTime
    ``type`` : string
    labels : Map<string, LangaugeValue>
    aliases : Map<string, LangaugeValue list>
    descriptions : Map<string, LangaugeValue>
    claims : Map<string, Claim list>
    sitelinks : Map<string, SiteLink>
    }

type Data = {
    entities : Map<string, Entity>
    success : int
    }

type SearchInfo = {
    search : string
    }

type SearchResult = {
    id : string
    url : string
    description : string
    label : string
    }

type Search = {
    searchinfo : SearchInfo
    search : SearchResult list
    success : int
    }