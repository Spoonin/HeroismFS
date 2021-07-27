namespace Heroism.Server
open Heroism.Shared
open Heroes
open Boards
open Games

module Heroes =
    let private heroesList: Hero list = [
        hero "A" "A" "A" 5 ({Prepare }, PlayerSide.Even)
    ]
     
    let heroes: Map<HeroId, Hero> = Map.ofList heroesList