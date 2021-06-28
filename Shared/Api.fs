namespace SharedModels

open Users
open Cards
open Heroes
open Boards


type HeroActions = {
    Get : HeroId -> Async<Hero option>
    GetAvailable : Async<Hero list>
    GetOwn : Async<Hero list>
    Hire : HeroId -> Async<Hero option>
    Remove : HeroId -> Async<unit> 
}

type UserActions = {
    GetActivePlayers: unit -> Async<User list>
}

type BattleActions = {
    PlaceCard: HeroId -> Column -> Card -> Async<Board>
    DoMove: Hero -> Cell -> Cell -> Async<Board>
}

type IHeroismApi = {
    User: UserActions
    Battle: BattleActions 
    // Hero: HeroActions // TODO
}