namespace SharedModels

open System

type HeroId = string

type Hero = {
    Id : HeroId
    Name : string
    PictureSrc : string
    Level : uint
    CurrentBoard : Board option
    UnitPool : Map<Unit, uint>
    CardPicks : uint
}

type HeroActions = {
    available : Async<Hero list>
    own : Async<Hero list>
    hire : HeroId -> Async<Hero option>
    remove : HeroId -> Async<unit>
    get : HeroId -> Async<Hero option>
}