namespace SharedModels

open Boards

module Heroes = 

    type HeroId = string

    type Hero = {
        Id: HeroId
        Name: string
        PictureSrc: string
        Level: uint
        CurrentBoard: Board option
        UnitPool: Map<Unit, uint>
        CardPicks: uint
    }