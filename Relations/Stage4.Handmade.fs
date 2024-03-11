namespace PhotoTour

type UntypedAttractionCrossroad (attraction : Attraction) =
    member this.Card = attraction.Card
    member this.Attraction = attraction

type 'attraction AttractionCrossroad when 'attraction :> Attraction (attraction : 'attraction) =
    inherit UntypedAttractionCrossroad(attraction)
    member this.Attraction = attraction