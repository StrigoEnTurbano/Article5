namespace PhotoTour

/// Generated.
module HaywayCrossroad =
    type 'attraction HaywayCrossroad when 'attraction :> Attraction(attraction) =
        inherit AttractionCrossroad<'attraction>(attraction)

    type ЗаповедникБасеги private () =
        inherit HaywayCrossroad<Attraction.ЗаповедникБасеги>(Attractions.ЗаповедникБасеги)
        static member val instance = ЗаповедникБасеги()

    type СкульптураОлень private () =
        inherit HaywayCrossroad<Attraction.СкульптураОлень>(Attractions.СкульптураОлень)
        static member val instance = СкульптураОлень()

    type УтёсСтепанаРазина private () =
        inherit HaywayCrossroad<Attraction.УтёсСтепанаРазина>(Attractions.УтёсСтепанаРазина)
        static member val instance = УтёсСтепанаРазина()

    type НабережнаяБрюгге private () =
        inherit HaywayCrossroad<Attraction.НабережнаяБрюгге>(Attractions.НабережнаяБрюгге)
        static member val instance = НабережнаяБрюгге()

    type ЖигулёвскиеГоры private () =
        inherit HaywayCrossroad<Attraction.ЖигулёвскиеГоры>(Attractions.ЖигулёвскиеГоры)
        static member val instance = ЖигулёвскиеГоры()

    type ДворецЗемледельцев private () =
        inherit HaywayCrossroad<Attraction.ДворецЗемледельцев>(Attractions.ДворецЗемледельцев)
        static member val instance = ДворецЗемледельцев()

    type ХребетЯлангас private () =
        inherit HaywayCrossroad<Attraction.ХребетЯлангас>(Attractions.ХребетЯлангас)
        static member val instance = ХребетЯлангас()

    type ЗаповедникБасеги with

        member this.СкульптураОлень = СкульптураОлень.instance
        member this.НабережнаяБрюгге = НабережнаяБрюгге.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type СкульптураОлень with

        member this.ЗаповедникБасеги = ЗаповедникБасеги.instance
        member this.УтёсСтепанаРазина = УтёсСтепанаРазина.instance
        member this.НабережнаяБрюгге = НабережнаяБрюгге.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type УтёсСтепанаРазина with

        member this.СкульптураОлень = СкульптураОлень.instance
        member this.ЖигулёвскиеГоры = ЖигулёвскиеГоры.instance

    type НабережнаяБрюгге with

        member this.ЗаповедникБасеги = ЗаповедникБасеги.instance
        member this.СкульптураОлень = СкульптураОлень.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type ЖигулёвскиеГоры with

        member this.УтёсСтепанаРазина = УтёсСтепанаРазина.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance
        member this.ХребетЯлангас = ХребетЯлангас.instance

    type ДворецЗемледельцев with

        member this.ЗаповедникБасеги = ЗаповедникБасеги.instance
        member this.СкульптураОлень = СкульптураОлень.instance
        member this.НабережнаяБрюгге = НабережнаяБрюгге.instance
        member this.ЖигулёвскиеГоры = ЖигулёвскиеГоры.instance
        member this.ХребетЯлангас = ХребетЯлангас.instance

    type ХребетЯлангас with

        member this.ЖигулёвскиеГоры = ЖигулёвскиеГоры.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

[<AutoOpen>]
module HaywayCrossroadAuto =
    type Attraction.ЗаповедникБасеги with

        member this.ViaHayway = HaywayCrossroad.ЗаповедникБасеги.instance

    type Attraction.СкульптураОлень with

        member this.ViaHayway = HaywayCrossroad.СкульптураОлень.instance

    type Attraction.УтёсСтепанаРазина with

        member this.ViaHayway = HaywayCrossroad.УтёсСтепанаРазина.instance

    type Attraction.НабережнаяБрюгге with

        member this.ViaHayway = HaywayCrossroad.НабережнаяБрюгге.instance

    type Attraction.ЖигулёвскиеГоры with

        member this.ViaHayway = HaywayCrossroad.ЖигулёвскиеГоры.instance

    type Attraction.ДворецЗемледельцев with

        member this.ViaHayway = HaywayCrossroad.ДворецЗемледельцев.instance

    type Attraction.ХребетЯлангас with

        member this.ViaHayway = HaywayCrossroad.ХребетЯлангас.instance

/// Generated.
module RailroadCrossroad =
    type 'attraction RailroadCrossroad when 'attraction :> Attraction(attraction) =
        inherit AttractionCrossroad<'attraction>(attraction)

    type ЗаповедникБасеги private () =
        inherit RailroadCrossroad<Attraction.ЗаповедникБасеги>(Attractions.ЗаповедникБасеги)
        static member val instance = ЗаповедникБасеги()

    type СкульптураОлень private () =
        inherit RailroadCrossroad<Attraction.СкульптураОлень>(Attractions.СкульптураОлень)
        static member val instance = СкульптураОлень()

    type УтёсСтепанаРазина private () =
        inherit RailroadCrossroad<Attraction.УтёсСтепанаРазина>(Attractions.УтёсСтепанаРазина)
        static member val instance = УтёсСтепанаРазина()

    type НабережнаяБрюгге private () =
        inherit RailroadCrossroad<Attraction.НабережнаяБрюгге>(Attractions.НабережнаяБрюгге)
        static member val instance = НабережнаяБрюгге()

    type ЖигулёвскиеГоры private () =
        inherit RailroadCrossroad<Attraction.ЖигулёвскиеГоры>(Attractions.ЖигулёвскиеГоры)
        static member val instance = ЖигулёвскиеГоры()

    type ДворецЗемледельцев private () =
        inherit RailroadCrossroad<Attraction.ДворецЗемледельцев>(Attractions.ДворецЗемледельцев)
        static member val instance = ДворецЗемледельцев()

    type ХребетЯлангас private () =
        inherit RailroadCrossroad<Attraction.ХребетЯлангас>(Attractions.ХребетЯлангас)
        static member val instance = ХребетЯлангас()

    type ЗаповедникБасеги with

        member this.СкульптураОлень = СкульптураОлень.instance
        member this.НабережнаяБрюгге = НабережнаяБрюгге.instance

    type СкульптураОлень with

        member this.ЗаповедникБасеги = ЗаповедникБасеги.instance
        member this.УтёсСтепанаРазина = УтёсСтепанаРазина.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type УтёсСтепанаРазина with

        member this.СкульптураОлень = СкульптураОлень.instance

    type НабережнаяБрюгге with

        member this.ЗаповедникБасеги = ЗаповедникБасеги.instance
        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type ЖигулёвскиеГоры with

        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type ДворецЗемледельцев with

        member this.СкульптураОлень = СкульптураОлень.instance
        member this.НабережнаяБрюгге = НабережнаяБрюгге.instance
        member this.ЖигулёвскиеГоры = ЖигулёвскиеГоры.instance
        member this.ХребетЯлангас = ХребетЯлангас.instance

    type ХребетЯлангас with

        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

[<AutoOpen>]
module RailroadCrossroadAuto =
    type Attraction.ЗаповедникБасеги with

        member this.ViaRailroad = RailroadCrossroad.ЗаповедникБасеги.instance

    type Attraction.СкульптураОлень with

        member this.ViaRailroad = RailroadCrossroad.СкульптураОлень.instance

    type Attraction.УтёсСтепанаРазина with

        member this.ViaRailroad = RailroadCrossroad.УтёсСтепанаРазина.instance

    type Attraction.НабережнаяБрюгге with

        member this.ViaRailroad = RailroadCrossroad.НабережнаяБрюгге.instance

    type Attraction.ЖигулёвскиеГоры with

        member this.ViaRailroad = RailroadCrossroad.ЖигулёвскиеГоры.instance

    type Attraction.ДворецЗемледельцев with

        member this.ViaRailroad = RailroadCrossroad.ДворецЗемледельцев.instance

    type Attraction.ХребетЯлангас with

        member this.ViaRailroad = RailroadCrossroad.ХребетЯлангас.instance

/// Generated.
module FlightCrossroad =
    type 'attraction FlightCrossroad when 'attraction :> Attraction(attraction) =
        inherit AttractionCrossroad<'attraction>(attraction)

    type СкульптураОлень private () =
        inherit FlightCrossroad<Attraction.СкульптураОлень>(Attractions.СкульптураОлень)
        static member val instance = СкульптураОлень()

    type ДворецЗемледельцев private () =
        inherit FlightCrossroad<Attraction.ДворецЗемледельцев>(Attractions.ДворецЗемледельцев)
        static member val instance = ДворецЗемледельцев()

    type СкульптураОлень with

        member this.ДворецЗемледельцев = ДворецЗемледельцев.instance

    type ДворецЗемледельцев with

        member this.СкульптураОлень = СкульптураОлень.instance

[<AutoOpen>]
module FlightCrossroadAuto =
    type Attraction.СкульптураОлень with

        member this.ViaFlight = FlightCrossroad.СкульптураОлень.instance

    type Attraction.ДворецЗемледельцев with

        member this.ViaFlight = FlightCrossroad.ДворецЗемледельцев.instance
