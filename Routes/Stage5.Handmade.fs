namespace PhotoTour

type UntypedAttractionRoute (crossroad : UntypedAttractionCrossroad) =
    member this.Card = crossroad.Card
    member this.Crossroad = crossroad

type AttractionRoute<'crossroad, 'attraction, 'state> 
        when 'crossroad :> 'attraction AttractionCrossroad 
        and 'attraction :> Attraction 
        (crossroad : 'crossroad, initialState : 'state, updater : 'state -> UntypedAttractionRoute -> 'state) =
    inherit UntypedAttractionRoute(crossroad)

    member this.Crossroad = crossroad
    member this.Updater = updater
    member this.State = updater initialState this

    member this.StopRoute () =
        this.Crossroad.Attraction, this.State