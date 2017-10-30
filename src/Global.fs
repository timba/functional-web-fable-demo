module App.Global

type Page =
    | Counter
    | Move

let toHash page =
  match page with
  | Counter -> "#counter"
  | Move -> "#move"
