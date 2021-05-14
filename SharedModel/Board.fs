namespace SharedModels

open System

type Column = | A | B | C | D | E | F
type Row = | One | Two | Three | Four
type Cell = { Col: Column; Row: Row }

type Board = Map<Cell, Card option>