namespace Heroism.Shared

module Cards =

    [<Literal>] 
    let FarShootAttackDistance = 4u

    [< StructuralComparison; StructuralEquality >]
    type UnitFeature = 
    | Walker
    | Flier
    | Shooter of shootAttack : uint * farShootAttack: uint

    type UnitId = string


    type Unit = {
        Id : UnitId
        Feature : UnitFeature
        Name : string
        PictureSrc : string
        Health: uint
        Attack : uint
    }

    type Card = {
        Unit : Unit
        CommonHealth: uint
    }

    let card unit quantity = {
        Unit = unit
        CommonHealth = quantity * unit.Health
    }
