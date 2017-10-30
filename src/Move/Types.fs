module Move.Types

open System 

type Model = 
    { 
        position: (int * int) 
        color: string 
    }

type Msg = 
      Move of int * int 
    | Recolor
    | Color of string


let colors = [
    "White"
    "Silver"
    "Gray"
    "Black"
    "Red"
    "Maroon"
    "Yellow"
    "Olive"
    "Lime"
    "Green"
    "Aqua"
    "Teal"
    "Blue"
    "Navy"
    "Fuchsia"
    "Purple"
]

let len = colors |> List.length

let random = Random()

let randomColor() =
    colors |> List.item (random.Next(len-1))
