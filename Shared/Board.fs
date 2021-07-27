namespace SharedModels

open Cards

module Boards =
    type Column = | A | B | C | D | E | F
        with static member Index col = Seq.findIndex (fun x -> x = col) (Utils.UnionCasesSeq<Column> ())
    type Row = | One | Two | Three | Four
        with static member Index row = Seq.findIndex (fun x -> x = row) (Utils.UnionCasesSeq<Row> ())
    type Cell = { Col: Column; Row: Row }


    type PlayerSide = | Odd | Even

    type GameCard = {
        Card: Card
        Side: PlayerSide
    }

    type Board = Map<Cell, GameCard option>
    
    let Empty: Board = Seq.allPairs (Utils.UnionCasesSeq<Column> ()) (Utils.UnionCasesSeq<Row> ()) 
                        |> Seq.map (fun colRowPair -> ({Col = fst colRowPair; Row = snd colRowPair}, None))
                        |> Map.ofSeq