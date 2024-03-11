namespace PhotoTour

/// Generated.
module HaywayRoute =
    type HaywayRoute<'crossroad, 'attraction, 'state>
        when 'crossroad :> 'attraction AttractionCrossroad and 'attraction :> Attraction
        (crossroad, initialState, updater) =
        inherit AttractionRoute<'crossroad, 'attraction, 'state>(crossroad, initialState, updater)

    type 'state ЗаповедникБасеги(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.ЗаповедникБасеги, Attraction.ЗаповедникБасеги, 'state>(
                HaywayCrossroad.ЗаповедникБасеги.instance,
                initialState,
                updater
            )

    type 'state СкульптураОлень(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.СкульптураОлень, Attraction.СкульптураОлень, 'state>(
                HaywayCrossroad.СкульптураОлень.instance,
                initialState,
                updater
            )

    type 'state УтёсСтепанаРазина(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.УтёсСтепанаРазина, Attraction.УтёсСтепанаРазина, 'state>(
                HaywayCrossroad.УтёсСтепанаРазина.instance,
                initialState,
                updater
            )

    type 'state НабережнаяБрюгге(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.НабережнаяБрюгге, Attraction.НабережнаяБрюгге, 'state>(
                HaywayCrossroad.НабережнаяБрюгге.instance,
                initialState,
                updater
            )

    type 'state ЖигулёвскиеГоры(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.ЖигулёвскиеГоры, Attraction.ЖигулёвскиеГоры, 'state>(
                HaywayCrossroad.ЖигулёвскиеГоры.instance,
                initialState,
                updater
            )

    type 'state ДворецЗемледельцев(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.ДворецЗемледельцев, Attraction.ДворецЗемледельцев, 'state>(
                HaywayCrossroad.ДворецЗемледельцев.instance,
                initialState,
                updater
            )

    type 'state ХребетЯлангас(initialState, updater) =
        inherit
            HaywayRoute<HaywayCrossroad.ХребетЯлангас, Attraction.ХребетЯлангас, 'state>(
                HaywayCrossroad.ХребетЯлангас.instance,
                initialState,
                updater
            )

    type 'state ЗаповедникБасеги with

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

        member this.НабережнаяБрюгге() =
            НабережнаяБрюгге(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state СкульптураОлень with

        member this.ЗаповедникБасеги() =
            ЗаповедникБасеги(this.State, this.Updater)

        member this.УтёсСтепанаРазина() =
            УтёсСтепанаРазина(this.State, this.Updater)

        member this.НабережнаяБрюгге() =
            НабережнаяБрюгге(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state УтёсСтепанаРазина with

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

        member this.ЖигулёвскиеГоры() =
            ЖигулёвскиеГоры(this.State, this.Updater)

    type 'state НабережнаяБрюгге with

        member this.ЗаповедникБасеги() =
            ЗаповедникБасеги(this.State, this.Updater)

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state ЖигулёвскиеГоры with

        member this.УтёсСтепанаРазина() =
            УтёсСтепанаРазина(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

        member this.ХребетЯлангас() = ХребетЯлангас(this.State, this.Updater)

    type 'state ДворецЗемледельцев with

        member this.ЗаповедникБасеги() =
            ЗаповедникБасеги(this.State, this.Updater)

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

        member this.НабережнаяБрюгге() =
            НабережнаяБрюгге(this.State, this.Updater)

        member this.ЖигулёвскиеГоры() =
            ЖигулёвскиеГоры(this.State, this.Updater)

        member this.ХребетЯлангас() = ХребетЯлангас(this.State, this.Updater)

    type 'state ХребетЯлангас with

        member this.ЖигулёвскиеГоры() =
            ЖигулёвскиеГоры(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

[<AutoOpen>]
module HaywayRouteAuto =
    type HaywayCrossroad.ЗаповедникБасеги with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.ЗаповедникБасеги(initialState, updater)

    type HaywayCrossroad.СкульптураОлень with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.СкульптураОлень(initialState, updater)

    type HaywayCrossroad.УтёсСтепанаРазина with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.УтёсСтепанаРазина(initialState, updater)

    type HaywayCrossroad.НабережнаяБрюгге with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.НабережнаяБрюгге(initialState, updater)

    type HaywayCrossroad.ЖигулёвскиеГоры with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.ЖигулёвскиеГоры(initialState, updater)

    type HaywayCrossroad.ДворецЗемледельцев with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.ДворецЗемледельцев(initialState, updater)

    type HaywayCrossroad.ХребетЯлангас with

        member this.StartRoute(initialState, updater) =
            HaywayRoute.ХребетЯлангас(initialState, updater)

/// Generated.
module RailroadRoute =
    type RailroadRoute<'crossroad, 'attraction, 'state>
        when 'crossroad :> 'attraction AttractionCrossroad and 'attraction :> Attraction
        (crossroad, initialState, updater) =
        inherit AttractionRoute<'crossroad, 'attraction, 'state>(crossroad, initialState, updater)

    type 'state ЗаповедникБасеги(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.ЗаповедникБасеги, Attraction.ЗаповедникБасеги, 'state>(
                RailroadCrossroad.ЗаповедникБасеги.instance,
                initialState,
                updater
            )

    type 'state СкульптураОлень(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.СкульптураОлень, Attraction.СкульптураОлень, 'state>(
                RailroadCrossroad.СкульптураОлень.instance,
                initialState,
                updater
            )

    type 'state УтёсСтепанаРазина(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.УтёсСтепанаРазина, Attraction.УтёсСтепанаРазина, 'state>(
                RailroadCrossroad.УтёсСтепанаРазина.instance,
                initialState,
                updater
            )

    type 'state НабережнаяБрюгге(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.НабережнаяБрюгге, Attraction.НабережнаяБрюгге, 'state>(
                RailroadCrossroad.НабережнаяБрюгге.instance,
                initialState,
                updater
            )

    type 'state ЖигулёвскиеГоры(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.ЖигулёвскиеГоры, Attraction.ЖигулёвскиеГоры, 'state>(
                RailroadCrossroad.ЖигулёвскиеГоры.instance,
                initialState,
                updater
            )

    type 'state ДворецЗемледельцев(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.ДворецЗемледельцев, Attraction.ДворецЗемледельцев, 'state>(
                RailroadCrossroad.ДворецЗемледельцев.instance,
                initialState,
                updater
            )

    type 'state ХребетЯлангас(initialState, updater) =
        inherit
            RailroadRoute<RailroadCrossroad.ХребетЯлангас, Attraction.ХребетЯлангас, 'state>(
                RailroadCrossroad.ХребетЯлангас.instance,
                initialState,
                updater
            )

    type 'state ЗаповедникБасеги with

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

        member this.НабережнаяБрюгге() =
            НабережнаяБрюгге(this.State, this.Updater)

    type 'state СкульптураОлень with

        member this.ЗаповедникБасеги() =
            ЗаповедникБасеги(this.State, this.Updater)

        member this.УтёсСтепанаРазина() =
            УтёсСтепанаРазина(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state УтёсСтепанаРазина with

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

    type 'state НабережнаяБрюгге with

        member this.ЗаповедникБасеги() =
            ЗаповедникБасеги(this.State, this.Updater)

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state ЖигулёвскиеГоры with

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state ДворецЗемледельцев with

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

        member this.НабережнаяБрюгге() =
            НабережнаяБрюгге(this.State, this.Updater)

        member this.ЖигулёвскиеГоры() =
            ЖигулёвскиеГоры(this.State, this.Updater)

        member this.ХребетЯлангас() = ХребетЯлангас(this.State, this.Updater)

    type 'state ХребетЯлангас with

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

[<AutoOpen>]
module RailroadRouteAuto =
    type RailroadCrossroad.ЗаповедникБасеги with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.ЗаповедникБасеги(initialState, updater)

    type RailroadCrossroad.СкульптураОлень with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.СкульптураОлень(initialState, updater)

    type RailroadCrossroad.УтёсСтепанаРазина with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.УтёсСтепанаРазина(initialState, updater)

    type RailroadCrossroad.НабережнаяБрюгге with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.НабережнаяБрюгге(initialState, updater)

    type RailroadCrossroad.ЖигулёвскиеГоры with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.ЖигулёвскиеГоры(initialState, updater)

    type RailroadCrossroad.ДворецЗемледельцев with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.ДворецЗемледельцев(initialState, updater)

    type RailroadCrossroad.ХребетЯлангас with

        member this.StartRoute(initialState, updater) =
            RailroadRoute.ХребетЯлангас(initialState, updater)

/// Generated.
module FlightRoute =
    type FlightRoute<'crossroad, 'attraction, 'state>
        when 'crossroad :> 'attraction AttractionCrossroad and 'attraction :> Attraction
        (crossroad, initialState, updater) =
        inherit AttractionRoute<'crossroad, 'attraction, 'state>(crossroad, initialState, updater)

    type 'state СкульптураОлень(initialState, updater) =
        inherit
            FlightRoute<FlightCrossroad.СкульптураОлень, Attraction.СкульптураОлень, 'state>(
                FlightCrossroad.СкульптураОлень.instance,
                initialState,
                updater
            )

    type 'state ДворецЗемледельцев(initialState, updater) =
        inherit
            FlightRoute<FlightCrossroad.ДворецЗемледельцев, Attraction.ДворецЗемледельцев, 'state>(
                FlightCrossroad.ДворецЗемледельцев.instance,
                initialState,
                updater
            )

    type 'state СкульптураОлень with

        member this.ДворецЗемледельцев() =
            ДворецЗемледельцев(this.State, this.Updater)

    type 'state ДворецЗемледельцев with

        member this.СкульптураОлень() =
            СкульптураОлень(this.State, this.Updater)

[<AutoOpen>]
module FlightRouteAuto =
    type FlightCrossroad.СкульптураОлень with

        member this.StartRoute(initialState, updater) =
            FlightRoute.СкульптураОлень(initialState, updater)

    type FlightCrossroad.ДворецЗемледельцев with

        member this.StartRoute(initialState, updater) =
            FlightRoute.ДворецЗемледельцев(initialState, updater)
