namespace SharedModels
open Games
open Boards

module Heroes = 

    type HeroId = HeroId of string

    type Hero = {
        Id: HeroId
        Name: string
        PictureSrc: string
        Level: uint
        CurrentGame: Game  option
        UnitPool: Map<Unit, uint>
    }

    let hero id name pictureSrc level currentGame unitPool = 
        {
            Id = id
            Name = name
            PictureSrc = pictureSrc
            Level = level
            CurrentGame = currentGame
            UnitPool = unitPool
        }