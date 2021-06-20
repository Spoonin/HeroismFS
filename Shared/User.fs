namespace SharedModels

open Heroes

module Users =

    type User = {
        Id : string
        Heroes : Hero list
    }