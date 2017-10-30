module App.Types 

type Model = {
    currentPage: Navbar.Types.Model
    counter: Counter.Types.Model
    move: Move.Types.Model
  }

type Msg =
  | CounterMsg of Counter.Types.Msg
  | MoveMsg of Move.Types.Msg
  | NavbarMsg of Navbar.Types.Msg