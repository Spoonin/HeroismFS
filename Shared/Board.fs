namespace SharedModels

open Cards

module Boards =
    type Column = | A | B | C | D | E | F
        with static member Index col = List.findIndex (fun x -> x = col) [A;B;C;D;E;F]
    type Row = | One | Two | Three | Four
        with static member Index row = List.findIndex (fun x -> x = row) [One; Two; Three; Four]
    type Cell = { Col: Column; Row: Row }

    type PlayerSide = | Odd | Even

    type GameCard = {
        Card: Card
        Side: PlayerSide
    }

    type Board = Map<Cell, GameCard option>

    type BoardStatus = { EvenReady: bool; OddReady: bool }

    