namespace SharedModels

open Users
open Cards
open Heroes
open Boards
open Games


type HeroActions = {
    Get : HeroId -> Async<Hero option>
    GetAvailable : Async<Hero list>
    GetOwn : Async<Hero list>
    Hire : HeroId -> Async<Hero option>
    Remove : HeroId -> Async<unit> 
}

type UserActions = {
    GetActivePlayers: unit -> Async<User list>
    FindPlayers: string -> Async<User list>
}

type BattleActions = {
    GetGame: HeroId -> Async<Game>
    PlaceCard: HeroId -> Column -> Card -> Async<Board>
    SetReady: HeroId -> Async<Game>
    DoMove: HeroId -> Cell -> Cell -> Async<Board>
}

type IHeroismApi = {
    User: UserActions
    Battle: BattleActions 
    // Hero: HeroActions // TODO
}