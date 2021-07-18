namespace SharedModels

open Boards

module Games =

    type Game =
    | Prepare of waitingForOppenent: bool * board: Board
    | Battle of isMyTurn: bool * board: Board