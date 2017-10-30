module Counter.State

open Elmish
open Types

let init() =
    (0, ""), Cmd.none

let update msg (count, _) =
  match msg with
  | Increment -> (count + 1, ""), Cmd.none
  | Decrement -> (count - 1, ""), Cmd.none
  | Value num -> (num, ""), Cmd.none
  | Error     -> (count, "Invalid value"), Cmd.none
