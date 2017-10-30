module App.All

open Elmish
open Elmish.React
open Elmish.Debug
open Elmish.HMR

open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser

open Fable.Core.JsInterop
open Fable.Helpers.React

open App.State
open App.Types
open App.Global

importAll "./styles.css"

let root model dispatch =

    let mainHtml = 
        match model.currentPage with
        | Counter -> Counter.View.view model.counter (CounterMsg >> dispatch)
        | Move -> Move.View.view model.move (MoveMsg >> dispatch)

    div [] [
        Navbar.View.view model.currentPage (NavbarMsg >> dispatch)
        br []
        mainHtml
    ]

let subscription _ =
        Cmd.map MoveMsg (Move.Subscriptions.subscriptions 0)

Program.mkProgram init update root
|> Program.withSubscription subscription
|> Program.toNavigable (parseHash pageParser) urlUpdate
//|> Program.withHMR 
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.withDebugger
|> Program.run