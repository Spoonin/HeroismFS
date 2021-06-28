namespace SharedModels

module Cards =

    type UnitAbility = {
        Health: uint
        Attack : uint
    }

    [<Literal>] 
    let FarShootAttackDistance = 4u

    [< StructuralComparison; StructuralEquality >]
    type UnitFeature = 
    | Walker of ability : UnitAbility
    | Shooter of UnitAbility * shootAttack : uint * farShootAttack: uint
    | Flier of UnitAbility // * returnsAfterHit : bool

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
        CommonHealth: uint
    }
