namespace Heroism.Server

open System
open Heroism.Shared
open Cards
open Boards
open Battle

module GamePlay =
    let private quantity commonHealth helthByUnit =
        Math.Ceiling (float commonHealth / float helthByUnit) |> uint

    let applyDamage damage targetCard =
        if damage >= targetCard.CommonHealth then None else Some {targetCard with CommonHealth = targetCard.CommonHealth - damage}

    let private damageTarget (attackerCard: Card) (targetCard: Card) (distance: uint) = 
        let {Attack = attack; Health = healthByUnit} = attackerCard.Unit
        match attackerCard.Unit.Feature with
        | Flier | Walker ->
            if distance = 1u 
            then applyDamage ((quantity attackerCard.CommonHealth healthByUnit) * attack) targetCard |> Ok
            else Error "Invalid move - Target is too far"
        | Shooter (shootAttack, farShootAttack) ->
            if distance = 1u
            then applyDamage ((quantity attackerCard.CommonHealth healthByUnit) * attack) targetCard |> Ok
            else if distance < FarShootAttackDistance then applyDamage ((quantity attackerCard.CommonHealth healthByUnit) * shootAttack) targetCard |> Ok
            else applyDamage ((quantity attackerCard.CommonHealth healthByUnit) * farShootAttack) targetCard |> Ok
                
    let private doMove (board: Board) (move: Move): Result<Board, string> = 
        match move with
        | {Type = Reposition; OriginCell = originCell; TargetCell = targetCell} ->
            match (board.[originCell], board.[targetCell]) with
            | (None, _) -> Error "Invalid move - origin cell must be a card"
            | (_, Some _) -> Error "Invalid move - target cell must be empty"
            | (card, None) -> Map.add originCell None board
                            |> Map.add targetCell card
                            |> Ok
        | {Type = Attack; OriginCell = originCell; TargetCell = targetCell} ->
            match (board.[originCell], board.[targetCell]) with
            | (None, _) | (_, None) -> Error "Invalid move - origin and target cells must be cards"
            | (Some attacker, Some target) ->
                let rowDistance = Math.Abs (Row.Index originCell.Row - Row.Index targetCell.Row)
                let colDistance = Math.Abs (Column.Index originCell.Col - Column.Index targetCell.Col)
                let distance = Math.Min (rowDistance, colDistance) |> uint
                let updTargetCard = damageTarget attacker.Card target.Card distance
                match updTargetCard with
                | Ok mbCard -> 
                    match mbCard with
                    | None -> Map.add targetCell None board |> Ok // killed unit
                    | Some card -> Map.change targetCell (fun _ -> Some (Some {target with Card = card})) board 
                                    |> Ok

                | Error x -> Error x // Invalid attacker move
                
    let ReduceBoard (board: Board) (moves: Move list) =
        List.fold (fun boardState move -> match boardState with
                                          | Error x -> Error x
                                          | Ok board -> doMove board move 
                  ) (Ok board) moves
    