module Navbar.View

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Types 

open App.Global

let getAClass page current =
   if page = current then "nav-link active"
   else "nav-link"

let menuItem current target text dispatch = 
        li [ ClassName "nav-item" ] [
            a [ 
                getAClass current target |> ClassName
                Href (toHash target)
                //Href "#"
                //OnClick (fun _ -> dispatch (Navigate Counter)  ) 
              ] [ str text ]
        ]
  

let view model dispatch =
    ul [ ClassName "nav nav-pills"] [
        menuItem model Counter "Counter" dispatch
        menuItem model Move "Move" dispatch
    ]