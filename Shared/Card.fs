namespace SharedModels

module Cards =

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

    type Card = {
        Id : string
        Unit : Unit
        Quantity : uint
    }
