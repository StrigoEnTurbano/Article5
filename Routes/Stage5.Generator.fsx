#load "Generator.Routes.Setup.fsx"
#load "Stage5.Handmade.fs"
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

"""
type A = 
    member this.Q () = 42
"""
|> fun str -> Parse.parseFile false (SourceText.ofString str) []
|> fst

open PhotoTour
open Generator.Literals

module Sample =
    module HaywayRoute =
        type HaywayRoute<'crossroad, 'attraction, 'state>
            when 'crossroad :> AttractionCrossroad<'attraction> 
            and 'attraction :> Attraction 
            (crossroad, initialState, updater) =
            inherit AttractionRoute<'crossroad, 'attraction, 'state>(crossroad, initialState, updater)

        type 'content ДворецЗемледельцев (initialState, updater) =
            inherit HaywayRoute<HaywayCrossroad.ДворецЗемледельцев, Attraction.ДворецЗемледельцев, 'content>(HaywayCrossroad.ДворецЗемледельцев.instance, initialState, updater)
        
        type 'content ЗаповедникБасеги (initialState, updater) =
            inherit HaywayRoute<HaywayCrossroad.ЗаповедникБасеги, Attraction.ЗаповедникБасеги, 'content>(HaywayCrossroad.ЗаповедникБасеги.instance, initialState, updater)
        
        type 'content ДворецЗемледельцев with
            member this.ЗаповедникБасеги () =
                ЗаповедникБасеги(this.State, this.Updater)

    type HaywayCrossroad.ДворецЗемледельцев with
        member this.StartRoute (initalState, updater) =
            HaywayRoute.ДворецЗемледельцев(initalState, updater)

    type HaywayCrossroad.ЗаповедникБасеги with
        member this.StartRoute (initalState, updater) =
            HaywayRoute.ЗаповедникБасеги(initalState, updater)

    let attraction, state =
        Attractions.ДворецЗемледельцев.ViaHayway
            .StartRoute(42, fun state _ -> state + 1)
            .ЗаповедникБасеги()
            .StopRoute()

    do  let expected = 44
        if state <> expected then
            failwithf "Invalid state! %i instead of %i" state expected

    do  let expected = Attractions.ЗаповедникБасеги.Card
        let actual = attraction.Card
        if actual <> expected then
            failwithf "Invalid attraction.Card! %A instead of %A" actual expected

    [<System.Runtime.CompilerServices.ExtensionAttribute>]
    type Exts =
        [<System.Runtime.CompilerServices.ExtensionAttribute>]
        static member ДворецЗемледельцев' (_ : HaywayCrossroad.СкульптураОлень) = 
            HaywayCrossroad.ДворецЗемледельцев.instance

    Attractions.СкульптураОлень.ViaHayway.ДворецЗемледельцев'().ЖигулёвскиеГоры

Code.fromModules [
    SynModuleOrNamespace.createNamespace Namespaces.root [
        let synExpr = Ident.parseSynExprLong

        let generateNet subtitle roads = [
            let attractions = [
                for attraction in AttractionCards.all do
                    match Map.tryFind attraction.Id roads with
                    | None -> () 
                    | Some roads -> {| attraction with Roads = roads |}
            ]

            [Messages.generated]
            |> SynModuleDecl.NestedModule.create (Modules._Route subtitle) [
                SynModuleDecl.Types.CreateByDefault[
                    let crossroad, attraction, state =
                        let generic literal =
                            {|
                                AsString = literal
                                AsSynType = Ident.parseSynType $"'{literal}"
                            |}
                        generic "crossroad"
                        , generic "attraction"
                        , generic "state"

                    let info =
                        SynComponentInfo.CreateByDefault(
                            Ident.parseLong ^ Types._Route subtitle
                            , typeParams = (
                                SynTyparDecls.PostfixList.create [
                                    crossroad.AsString
                                    attraction.AsString
                                    state.AsString
                                ]
                                |> Some
                            )
                            , constraints = [
                                SynType.App.postfix Types.attractionCrossroad attraction.AsSynType
                                |> SynTypeConstraint.WhereTyparSubtypeOfType.create crossroad.AsString

                                Ident.parseSynType Types.attraction
                                |> SynTypeConstraint.WhereTyparSubtypeOfType.create attraction.AsString 
                            ]
                        )
                    let ctor =
                        SynMemberDefn.ImplicitCtor.create ^ SynSimplePats.SimplePats.simple [
                            crossroad.AsString
                            Types.Route.initalState
                            Types.Route.updater
                        ]

                    SynTypeDefn.create info ctor [
                        SynMemberDefn.ImplicitInherit.create (
                            SynType.App.classicGeneric Types.attractionRoute [
                                crossroad.AsSynType
                                attraction.AsSynType
                                state.AsSynType
                            ]
                        ) [
                            synExpr crossroad.AsString
                            synExpr Types.Route.initalState
                            synExpr Types.Route.updater
                        ]
                    ]
                ]
                            
                for Syntaxify.Name attractionName in attractions do
                    SynModuleDecl.Types.CreateByDefault[
                        let info =
                            SynComponentInfo.CreateByDefault(
                                Ident.parseLong attractionName
                                , typeParams = Some ^ SynTyparDecls.SinglePrefix.create "state"
                            )
                        let ctor =
                            SynMemberDefn.ImplicitCtor.create ^ SynSimplePats.SimplePats.simple [
                                Types.Route.initalState
                                Types.Route.updater
                            ]
                        SynTypeDefn.create info ctor [
                            SynMemberDefn.ImplicitInherit.create (
                                SynType.App.classicGeneric (Types._Route subtitle) [
                                    Ident.parseSynType $"{Modules._Crossroad subtitle}.{attractionName}"
                                    Ident.parseSynType $"{Modules.attraction}.{attractionName}"
                                    Ident.parseSynType "'state"
                                ]
                            ) [
                                synExpr $"{Modules._Crossroad subtitle}.{attractionName}.{Types.Crossroad.instance}"
                                synExpr Types.Route.initalState
                                synExpr Types.Route.updater
                            ]
                        ]
                    ]

                for attraction in attractions do
                    SynModuleDecl.Types.CreateByDefault [
                        SynTypeDefn.``type '<arg> <name> with =`` "state" (Syntaxify.name attraction) [
                            for otherId in attraction.Roads do
                                let otherName =
                                    AttractionCards.all
                                    |> Seq.find ^ fun p -> p.Id = otherId
                                    |> Syntaxify.name

                                SynExpr.tuple [
                                    synExpr $"this.{Types.Route.State}"
                                    synExpr $"this.{Types.Route.Updater}"
                                ]
                                |> SynExpr.paren
                                |> SynExpr.app <| synExpr otherName
                                |> SynMemberDefn.Member.``member this.<name> (<args>)`` otherName []
                        ]
                    ]
            ]

            SynModuleDecl.NestedModule.createAutoOpen (Modules._RouteAuto subtitle) [
                for Syntaxify.Name attractionName in attractions do
                    SynModuleDecl.Types.CreateByDefault [
                        SynTypeDefn.``type <name> with =`` $"{Modules._Crossroad subtitle}.{attractionName}" [
                            synExpr $"{Modules._Route subtitle}.{attractionName}"
                            |> SynExpr.app ^ SynExpr.paren ^ SynExpr.tuple [
                                synExpr Types.Route.initalState
                                synExpr Types.Route.updater
                            ]
                            |> SynMemberDefn.Member.``member this.<name> (<args>)`` Types.Route.startRoute [
                                Types.Route.initalState
                                Types.Route.updater
                            ]
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
            , "Stage5.Generated.fs"
        )
        , content
    )