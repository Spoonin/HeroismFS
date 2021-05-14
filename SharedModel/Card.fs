namespace SharedModels

open System

type Card = {
    Id : string
    Unit : Unit
    Quantity : uint
}

type Unit = {
    Feature: UnitFeature
    Name : string
    PictureSrc : string
}

type UnitAbility = {
    Steps : uint
    Attack : uint
}


type UnitFeature = 
| Walker of ability : UnitAbility
| Shooter of UnitAbility * shootAttack : uint
| Flier of UnitAbility * returnsAfterHit : bool