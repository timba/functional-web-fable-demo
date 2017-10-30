module Move.State

open Elmish;

open Types

let init _ = 
    { 
        position = (100, 100)
        color = "Red"
    }, 
    Cmd.none

let update (msg: Msg) (model: Model) : (Model*Cmd<Msg>) =
  match msg with
  | Move (x, y)    -> { model with position = (x-80, y-80) }, Cmd.none
  | Recolor        -> model, Cmd.ofMsg (Color (randomColor()))
  | Color newColor -> { model with color = newColor }, Cmd.none
