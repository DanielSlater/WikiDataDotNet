WikiDataDotNet
============

WikiDataDotNet is an API for access data from WikiData http://www.wikidata.org/

This API is still in development if you find a bug, please report it or even better, create a patch and make a pull request. Contributions are very welcome.

Overview
--------

Provides the ability to get entities and search against WikiData.

To get an entity simply:

open WikiDataDotNet.Request
request_entity "Q38"

There are C# examples of usage in WikiDataDotNet.Samples.CSharp

I have plans to extend with an easy way to lookup and cache claims.
More info on my blog http://www.danielslater.net/2015/08/presenting-wikidatadotnet-client-api.html

Download and Installation
-------------------------

You can clone the source code from this repository to your local machine and compile it there. To use in one of your projects you will also need to include the Newtonsoft.Json.FSharp nuget package.

License
-------

WikiDataDotNet is licensed under the MIT LICENSE. A copy of the license can be found in the LICENSE file.
