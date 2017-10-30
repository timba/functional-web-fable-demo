module Navbar.State

open Elmish

open Navbar.Types

open App.Global

let update msg _ =
  match msg with
  | Navigate page -> page, Cmd.none

let init() = 
  Counter, Cmd.none