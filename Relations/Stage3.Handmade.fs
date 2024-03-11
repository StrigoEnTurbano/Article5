namespace PhotoTour

module AttractionRelations =
    let hayways, railroads, flights = 
        let hayways = [
            15, [16; 18; 20]
            16, [17; 18; 20]
            17, [19]
            18, [20]
            19, [20; 21]
            20, [21]
        ]
    
        let railroads = [
            15, [16; 18]
            16, [17; 20]
            17, []
            18, [20]
            19, [20]
            20, [21]
        ] 
    
        let simpleRoads input = 
            seq {
                for a, bs in input do
                    for b in bs do
                        a, b
                        b, a
            }
            |> Seq.groupBy fst
            |> Seq.map ^ fun (place, items) ->
                place
                , items |> Seq.map snd |> set
            |> Map.ofSeq
    
        simpleRoads hayways
        , simpleRoads railroads
        , Map.ofSeq [
            let all = set [16; 20]
            for item in all do
                item, all.Remove item
        ]