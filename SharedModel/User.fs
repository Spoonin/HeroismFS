module SharedModels

open System

type User = {
    Id : string
    Heroes : Hero list
}