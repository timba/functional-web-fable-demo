module Move.View

open Fable.Helpers.React
open Fable.Helpers.React.Props

let view (model:Types.Model) _ = 
    let (x, y) = model.position
    div [
        Style [
            Width 50
            Height 50
            BackgroundColor model.color
            Position "fixed"
            Left x
            Top y
            BorderRadius "25px"
            Border "1px solid black"
        ]
    ] [ ]
