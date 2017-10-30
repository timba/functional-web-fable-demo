module Navbar.Types 

open App.Global

type Model = App.Global.Page

type Msg =
    | Navigate of Page