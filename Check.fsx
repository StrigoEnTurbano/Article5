#r "nuget: FSharpx.Collections"
#r "nuget: Expecto"

#load "Routes\Generator.Routes.Setup.fsx"
#load "Routes\Stage5.Handmade.fs"
#load "Routes\Stage5.Generated.fs"

open PhotoTour
open FSharpx.Collections
open Expecto
open Expecto.Flip

do  let attraction, path = 
        Attractions.ДворецЗемледельцев.ViaHayway
            .StartRoute(PersistentVector.empty, fun state node -> state.Conj node.Crossroad.Card)
            .ЖигулёвскиеГоры()
            .ХребетЯлангас()
            .ДворецЗемледельцев()
            .ЖигулёвскиеГоры()
            .StopRoute()
    
    attraction
    |> Expect.equal "" Attractions.ЖигулёвскиеГоры


    let expectedPath = PersistentVector.ofSeq [
        AttractionCards.ДворецЗемледельцев
        AttractionCards.ЖигулёвскиеГоры
        AttractionCards.ХребетЯлангас
        AttractionCards.ДворецЗемледельцев
        AttractionCards.ЖигулёвскиеГоры
    ]
    path
    |> Expect.equal "" expectedPath

type 'a HaywayRoute.ЖигулёвскиеГоры with
    member this.Double n = 2 * n
    
do  let attraction, score = 
        Attractions.ДворецЗемледельцев.ViaHayway
            .StartRoute(0, fun state node ->
                match node with
                | :? HaywayRoute.ЖигулёвскиеГоры<int> as p -> 
                    p.Double state
                | _ ->
                    state + 1
            )
            .ЖигулёвскиеГоры()
            .ХребетЯлангас()
            .ДворецЗемледельцев()
            .ЖигулёвскиеГоры()
            .StopRoute()

    attraction 
    |> Expect.equal "" Attractions.ЖигулёвскиеГоры

    score
    |> Expect.equal "" ((1 * 2 + 1 + 1) * 2)