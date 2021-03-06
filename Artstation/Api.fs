namespace Artstation

open FSharp.Json
open Newtonsoft.Json
open Newtonsoft.Json.Serialization

open Flurl.Http
open Flurl.Http.Configuration

module Api =
    let BaseUrl () =
        "https://www.artstation.com/"
            .ConfigureRequest(fun settings ->
                settings.JsonSerializer <-
                    NewtonsoftJsonSerializer(
                        JsonSerializerSettings(
                            ContractResolver = DefaultContractResolver(NamingStrategy = SnakeCaseNamingStrategy())
                        )
                    ))

    let jsonConfig =
        JsonConfig.create (jsonFieldNaming = Json.snakeCase)

    let parseJson data : 'TData =
        Json.deserializeEx<'TData> jsonConfig data
