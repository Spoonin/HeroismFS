namespace SharedModels

open Users 
open Heroes


type HeroActions = {
    Get : HeroId -> Async<Hero option>
    GetAvailable : Async<Hero list>
    GetOwn : Async<Hero list>
    Hire : HeroId -> Async<Hero option>
    Remove : HeroId -> Async<unit> 
}

type IHeroismApi = {
    GetActivePlayers: unit -> Async<User list>
    // HeroActions: HeroActions // TODO
}