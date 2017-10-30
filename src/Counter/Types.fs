module Counter.Types

type Model = int * string

type Msg = 
    Increment 
  | Decrement
  | Value of int
  | Error

let parse text =
  match System.Int32.TryParse(text) with
  | (true, i) -> Some i
  | (false, _) -> None

let textToMsg text =
  match parse text with
  | Some i -> Value i
  | None -> Error

