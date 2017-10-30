module Move.Subscriptions

open System
open Elmish
open Fable.Import.Browser

open Types

let mousemove _ =
    let sub dispatch = 
        window.addEventListener_mousemove (
                (fun evt -> 
                    let x:int = Convert.ToInt32(evt.clientX)
                    let y:int = Convert.ToInt32(evt.clientY)
                    dispatch (Move (x,y))
                    null), true )
    Cmd.ofSub sub

let mouseclick _ =
    let sub dispatch = 
        window.addEventListener_click (
                (fun _ -> 
                    dispatch Recolor
                    null), 
                true )
    Cmd.ofSub sub

let subscriptions model =
    Cmd.batch [
        mousemove model
        mouseclick model
    ]
