#load "Generator.Relations.Setup.fsx"
#load "Stage3.Handmade.fs"
#load "../MyAstHelpers.fsx"

open RecordExts
open UnionExts
open AstHelpers
open MyAstHelpers

let inline (^) f x = f x

open Fantomas.FCS
open Fantomas.FCS.Syntax
open Fantomas.FCS.Xml
open Fantomas.FCS.Text
open Fantomas.FCS.Text.Range
open Fantomas.FCS.SyntaxTrivia

"""type Q =
    static member val Q = 42"""
|> SourceText.ofString 
|> Parse.parseFile false <| []
|> fst

open PhotoTour
open Generator.Literals

module Sample3 =
    module HaywayRelationExts =
        type Attraction.ЗаповедникБасеги with
            member this.СкульптураОлень = Attraction.СкульптураОлень.instance

    open HaywayRelationExts

    Attractions.ЗаповедникБасеги.СкульптураОлень
    |> ignore

Code.fromModules [
    SynModuleOrNamespace.createNamespace Namespaces.root [
        let generateNet subtitle roads =
            let attractions = [
                for attraction in AttractionCards.all do
                    match Map.tryFind attraction.Id roads with
                    | None -> () 
                    | Some roads -> {| attraction with Roads = roads |}
            ]

            [Messages.generated]
            |> SynModuleDecl.NestedModule.create (Modules._RelationExts subtitle) [
                for attraction in attractions do
                    SynModuleDecl.Types.CreateByDefault [
                        SynTypeDefn.``type <name> with =`` $"{Modules.attraction}.{Syntaxify.name attraction}" [
                            for otherId in attraction.Roads do
                                let otherName =
                                    AttractionCards.all
                                    // Верно, пока на каждую точку приходится лишь одна карта.
                                    |> Seq.find ^ fun p -> p.Id = otherId
                                    |> Syntaxify.name

                                $"{Modules.attraction}.{otherName}.{Types.Attraction.instance}"
                                |> Ident.parseSynExprLong 
                                |> SynMemberDefn.Member.``member this.<name> =`` otherName
                        ]
                    ]
            ]

        generateNet Names.hayway AttractionRelations.hayways
        generateNet Names.railroad AttractionRelations.railroads
        generateNet Names.flight AttractionRelations.flights
    ]
]
|> fun content ->
    System.IO.File.WriteAllText(
        System.IO.Path.Combine(
            __SOURCE_DIRECTORY__
            , "Stage3.Generated.fs"
        )
        , content
    )