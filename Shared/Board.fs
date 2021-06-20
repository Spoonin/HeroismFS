namespace SharedModels

open System
open Utils

module GamePlay =
    type Column = | A | B | C | D | E | F
        with static member Index col = [A;B;C;D;E;F]
    type Row = | One | Two | Three | Four
        with static member List = [One; Two; Three; Four]
    type Cell = { Col: Column; Row: Row }

    type PlayerSide = | Odd | Even

    type GameCard = {
        Card: Card
        Side: PlayerSide
    }

    type Board = Map<Cell, GameCard option>

    type MoveType = | Reposition | Attack

    let private isFreeCell (board: Board) cell = board.[cell].IsNone

    let private isNeighbourCell (originCell: Cell) (targetCell: Cell) = true

    let private cellsList board = Map.toList board |> List.map fst

    let ValidMoves (moveType: MoveType) originCell (board: Board) =
        match board.[originCell] with
        | None -> []
        | Some gameCard ->
            match moveType with
            | Reposition ->
                match gameCard.Card.Unit.Feature with
                    | Flier _ -> cellsList board |> List.filter (isFreeCell board) 
                    | Walker _ -> cellsList board |> List.filter (isNeighbourCell originCell <&> isFreeCell board)

