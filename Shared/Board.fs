namespace SharedModels

open System
open Utils

module GamePlay =
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

    type MoveType = | Reposition | Attack

    let private isFreeCell (board: Board) cell = board.[cell].IsNone

    let private isOccupiedCell (board: Board) cell = board.[cell].IsSome

    let private isNeighbourCell (originCell: Cell) (targetCell: Cell) = 
        Math.Abs(Column.Index originCell.Col - Column.Index targetCell.Col) <= 1
        &&
        Math.Abs(Row.Index originCell.Row - Row.Index targetCell.Row) <= 1

    let private isEnemyCard (originGameCard: GameCard) (targetGameCard: GameCard) = originGameCard.Side <> targetGameCard.Side 

    let private cellsList board = Map.toList board |> List.map fst

    let private enemiesCellsList (board: Board) (gameCard: GameCard) = 
        cellsList board 
            |> List.filter ( fun cell -> 
                            match board.[cell] with
                                | None -> false
                                | Some targetGameCard -> isEnemyCard gameCard targetGameCard  
                   )

    let ValidMoves (moveType: MoveType) originCell (board: Board) =
        match board.[originCell] with
        | None -> []
        | Some gameCard ->
            match moveType with
            | Reposition ->
                match gameCard.Card.Unit.Feature with
                    | Flier _ -> cellsList board |> List.filter (isFreeCell board) // Every free cell is available
                    | Walker _ | Shooter _ -> cellsList board |> List.filter (isNeighbourCell originCell <&> isFreeCell board) // Cell is free and is next to current
            | Attack ->
                match gameCard.Card.Unit.Feature with
                    | Shooter _ -> enemiesCellsList board gameCard // Every enemy on the board
                    | Walker _ | Flier _ -> enemiesCellsList board gameCard // Enemies that are on the neihbour cell
                                                |> List.filter (isNeighbourCell originCell)