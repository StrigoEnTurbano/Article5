#load "Generator.Relations.Setup.fsx"
#load "../Relations/Stage3.Handmade.fs"
#load "../Relations/Stage3.Generated.fs"
#load "../Relations/Stage4.Handmade.fs"
#load "../MyAstHelpers.fsx"

open Fantomas.FCS
open Fantomas.FCS.Syntax
open Fantomas.FCS.Xml
open Fantomas.FCS.Text
open Fantomas.FCS.Text.Range
open Fantomas.FCS.SyntaxTrivia

open RecordExts
open UnionExts
open AstHelpers
open MyAstHelpers

open Generator.Literals
open PhotoTour

let inline (^) f x = f x

"""
type 'a HaywayAbstractAttraction when 'a :> AbstractAttraction (baseAttraction : 'a) =
    member this.Card = baseAttraction.Card
    member this.Stop = baseAttraction
"""
|> SourceText.ofString 
|> Parse.parseFile false <| []
|> fst

module Check3 =
    open PhotoTour.HaywayRelationExts

    let sample = Attractions.ДворецЗемледельцев.ЗаповедникБасеги.НабережнаяБрюгге.СкульптураОлень.УтёсСтепанаРазина

module Sample4 =
    module HaywayCrossroad =
        type 'attraction HaywayCrossroad when 'attraction :> Attraction (attraction) =
            inherit AttractionCrossroad<'attraction>(attraction)
            
        type ДворецЗемледельцев private () =
            inherit HaywayCrossroad<Attraction.ДворецЗемледельцев>(Attractions.ДворецЗемледельцев)
            static member val instance = ДворецЗемледельцев()

    [<AutoOpen>]
    module HaywayCrossroadAuto =
        type Attraction.ДворецЗемледельцев with
            member this.ViaHayway = HaywayCrossroad.ДворецЗемледельцев.instance

    Attractions
        .ДворецЗемледельцев
        .ViaHayway
        .Attraction
    |> ignore

Code.fromModules [
    SynModuleOrNamespace.createNamespace Namespaces.root [
        let generateNet subtitle roads = [
            let attractions = [
                for attraction in AttractionCards.all do
                    match Map.tryFind attraction.Id roads with
                    | None -> () 
                    | Some roads -> {| attraction with Roads = roads |}
            ]

            [Messages.generated]
            |> SynModuleDecl.NestedModule.create (Modules._Crossroad subtitle) [
                SynModuleDecl.Types.CreateByDefault[
                    let attraction =
                        let literal = "attraction"
                        {|
                            AsSynType = Ident.parseSynType $"'{literal}"
                            AsString = literal      
                        |}

                    let info = 
                        SynComponentInfo.CreateByDefault(
                            Ident.parseLong ^ Types._Crossroad subtitle
                            , typeParams = Some ^ SynTyparDecls.SinglePrefix.create attraction.AsString
                            , constraints = [
                                Ident.parseSynType Types.attraction
                                |> SynTypeConstraint.WhereTyparSubtypeOfType.create attraction.AsString
                            ]
                        )
                    let ctor = 
                        SynSimplePats.SimplePats.simple [attraction.AsString]
                        |> SynMemberDefn.ImplicitCtor.create 
                    SynTypeDefn.create info ctor [
                        [Ident.parseSynExprLong attraction.AsString]
                        |> SynMemberDefn.ImplicitInherit.create
                            (SynType.App.classicGeneric Types.attractionCrossroad [attraction.AsSynType])
                    ]
                ]
                            
                for Syntaxify.Name attractionName in attractions do
                    SynModuleDecl.Types.CreateByDefault[
                        SynTypeDefn.``type <name> private () =`` attractionName [
                            [Ident.parseSynExprLong $"{Modules.attractions}.{attractionName}"]
                            |> SynMemberDefn.ImplicitInherit.create (
                                SynType.App.classicGeneric (Types._Crossroad subtitle) [
                                    Ident.parseSynType ^ $"{Modules.attraction}.{attractionName}"
                                ]
                            )

                            Ident.parseSynExprLong attractionName
                            |> SynExpr.app SynExpr.Const.unit
                            |> SynMemberDefn.Member.staticMemberVal Types.Crossroad.instance
                        ]
                    ]

                for attraction in attractions do
                    SynModuleDecl.Types.CreateByDefault [
                        SynTypeDefn.``type <name> with =`` (Syntaxify.name attraction) [
                            for otherId in attraction.Roads do
                                let otherName = 
                                    AttractionCards.all
                                    |> Seq.find ^ fun p -> p.Id = otherId
                                    |> Syntaxify.name

                                Ident.parseSynExprLong $"{otherName}.{Types.Crossroad.instance}"
                                |> SynMemberDefn.Member.``member this.<name> =`` ^ otherName
                        ]
                    ]
            ]

            // Нет зависимости от roads.
            SynModuleDecl.NestedModule.createAutoOpen (Modules._CrossroadAuto subtitle) [
                for Syntaxify.Name attractionName in attractions do
                    SynModuleDecl.Types.CreateByDefault [
                        SynTypeDefn.``type <name> with =`` $"{Modules.attraction}.{attractionName}" [
                            $"{Modules._Crossroad subtitle}.{attractionName}.{Types.Crossroad.instance}"
                            |> Ident.parseSynExprLong
                            |> SynMemberDefn.Member.``member this.<name> =`` ^ Types.Attraction.via_ subtitle
                        ]
                    ]
            ]
        ]

        yield! generateNet Names.hayway AttractionRelations.hayways
        yield! generateNet Names.railroad AttractionRelations.railroads
        yield! generateNet Names.flight AttractionRelations.flights
    ]
]
|> fun content ->
    System.IO.File.WriteAllText(
        System.IO.Path.Combine(
            __SOURCE_DIRECTORY__
            , "Stage4.Generated.fs"
        )
        , content
    )