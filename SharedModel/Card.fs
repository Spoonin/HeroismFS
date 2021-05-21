namespace SharedModels

open System

type Card = {
    Id : string
    Unit : Unit
    Quantity : uint
}

type UnitAbility = {
    Steps : uint
    Attack : uint
}

[< StructuralComparison; StructuralEquality >]
type UnitFeature = 
| Walker of ability : UnitAbility
| Shooter of UnitAbility * shootAttack : uint
| Flier of UnitAbility * returnsAfterHit : bool

type UnitId = string


type Unit = {
    Id : UnitId
    Feature : UnitFeature
    Name : string
    PictureSrc : string
}
