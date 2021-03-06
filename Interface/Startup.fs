namespace Interface

open Spectre.Console.Cli

open Interface.Commands

module Startup =
    let application =
        let cli = CommandApp()

        // TODO: check the names because they are not so clear to reason about
        //       it is a weak commands structure than it has to be
        cli.Configure
            (fun config ->
                config
                    .AddCommand<FetchCollectionAssets.Command.Handler>("collection-assets")
                    .WithDescription("fetch collection assets")
                |> ignore)

        cli

    [<EntryPoint>]
    let main argv = application.Run argv
