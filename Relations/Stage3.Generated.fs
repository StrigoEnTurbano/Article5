namespace PhotoTour

/// Generated.
module HaywayRelationExts =
    type Attraction.ЗаповедникБасеги with

        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
        member this.НабережнаяБрюгге = Attraction.НабережнаяБрюгге.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.СкульптураОлень with

        member this.ЗаповедникБасеги = Attraction.ЗаповедникБасеги.instance
        member this.УтёсСтепанаРазина = Attraction.УтёсСтепанаРазина.instance
        member this.НабережнаяБрюгге = Attraction.НабережнаяБрюгге.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.УтёсСтепанаРазина with

        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
        member this.ЖигулёвскиеГоры = Attraction.ЖигулёвскиеГоры.instance

    type Attraction.НабережнаяБрюгге with

        member this.ЗаповедникБасеги = Attraction.ЗаповедникБасеги.instance
        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.ЖигулёвскиеГоры with

        member this.УтёсСтепанаРазина = Attraction.УтёсСтепанаРазина.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance
        member this.ХребетЯлангас = Attraction.ХребетЯлангас.instance

    type Attraction.ДворецЗемледельцев with

        member this.ЗаповедникБасеги = Attraction.ЗаповедникБасеги.instance
        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
        member this.НабережнаяБрюгге = Attraction.НабережнаяБрюгге.instance
        member this.ЖигулёвскиеГоры = Attraction.ЖигулёвскиеГоры.instance
        member this.ХребетЯлангас = Attraction.ХребетЯлангас.instance

    type Attraction.ХребетЯлангас with

        member this.ЖигулёвскиеГоры = Attraction.ЖигулёвскиеГоры.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

/// Generated.
module RailroadRelationExts =
    type Attraction.ЗаповедникБасеги with

        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
        member this.НабережнаяБрюгге = Attraction.НабережнаяБрюгге.instance

    type Attraction.СкульптураОлень with

        member this.ЗаповедникБасеги = Attraction.ЗаповедникБасеги.instance
        member this.УтёсСтепанаРазина = Attraction.УтёсСтепанаРазина.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.УтёсСтепанаРазина with

        member this.СкульптураОлень = Attraction.СкульптураОлень.instance

    type Attraction.НабережнаяБрюгге with

        member this.ЗаповедникБасеги = Attraction.ЗаповедникБасеги.instance
        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.ЖигулёвскиеГоры with

        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.ДворецЗемледельцев with

        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
        member this.НабережнаяБрюгге = Attraction.НабережнаяБрюгге.instance
        member this.ЖигулёвскиеГоры = Attraction.ЖигулёвскиеГоры.instance
        member this.ХребетЯлангас = Attraction.ХребетЯлангас.instance

    type Attraction.ХребетЯлангас with

        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

/// Generated.
module FlightRelationExts =
    type Attraction.СкульптураОлень with

        member this.ДворецЗемледельцев = Attraction.ДворецЗемледельцев.instance

    type Attraction.ДворецЗемледельцев with

        member this.СкульптураОлень = Attraction.СкульптураОлень.instance
