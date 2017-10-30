module App.State

open Fable.Import.Browser

open Elmish
open Elmish.Browser.UrlParser
open Elmish.Browser.Navigation

open App.Types
open App.Global

let init _ =
  let counter, counterCmd = Counter.State.init()
  let move, moveCmd = Move.State.init()
  let page, navCmd = Navbar.State.init()

  { 
    currentPage = page
    counter = counter
    move = move
  }, Cmd.batch [ 
    Cmd.map CounterMsg counterCmd
    Cmd.map MoveMsg moveCmd
    Cmd.map NavbarMsg navCmd
  ]





let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map Counter (s "counter")
    map Move (s "move")
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    console.error("Error parsing url")
    model, Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
    { model with currentPage = page }, []









let update msg model =
  match msg with
  | CounterMsg msg' -> 
    let res, cmd = Counter.State.update msg' model.counter
    { model with counter = res }, Cmd.map CounterMsg cmd
  | MoveMsg msg' ->
    match model.currentPage with
    | Move ->
      let res, cmd = Move.State.update msg' model.move 
      { model with move = res }, Cmd.map MoveMsg cmd
    | _ -> 
      model, Cmd.none
  | NavbarMsg msg' -> 
    let res, cmd = Navbar.State.update msg' model.currentPage
    { model with currentPage = res }, Cmd.map NavbarMsg cmd
