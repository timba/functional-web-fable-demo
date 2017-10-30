module Counter.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

open Types

let view model dispatch = 
    let (num, e) = model
    div []
        [
          button [
            OnClick (fun _ -> dispatch Decrement) 
            Type "button" 
            ClassName "btn btn-danger" ] [str "Decrement"]

          div [ ClassName "output" ] [ str (sprintf "%i" num) ]

          button [
            OnClick (fun _ -> dispatch Increment) 
            Type "button"
            ClassName "btn btn-success"] [str "Increment"]
          
          br []
          str "Reset to:" 
          br []
          input [ OnChange (fun evt -> textToMsg !!(evt.target)?value |> dispatch) ] 
          br []
          span [ Style [Color "red"] ] [str e]
        ]