module FableApp

open Fable.Core
open Fable.Import
open Fable.Import.React
open Elmish
open Elmish.React
open Elmish.Debug
open Fable.Helpers.React.Props
open Fable.Import.Browser
open Fable.Core.JsInterop

module R = Fable.Helpers.React

let init() =
    0, Cmd.none

type Model = int

type Msg = Increment | Decrement

let update msg count =
  match msg with
  | Increment -> count + 1, Cmd.none
  | Decrement -> count - 1, Cmd.none

let view model dispatch = 
    R.div []
        [
          R.button [ OnClick (fun _ -> dispatch Decrement) ] [R.str "-"]
          R.div [] [ R.str (sprintf "%A" model) ]
          R.button [ OnClick (fun _ -> dispatch Increment) ] [R.str "+"]
        ]

Program.mkProgram init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.withDebuggerAt (Debugger.ConnectionOptions.Remote ("localhost", 8000))
|> Program.run