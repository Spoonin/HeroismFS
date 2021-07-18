namespace SharedModels
open Games
open Boards

module Heroes = 

    type HeroId = string

    type Hero = {
        Id: HeroId
        Name: string
        PictureSrc: string
        Level: uint
        CurrentGame: (Game * PlayerSide)  option
        UnitPool: Map<Unit, uint>
    }