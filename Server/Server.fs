namespace Heroism.Server

open Heroism.Shared

module Server =

    let server: IHeroismApi = {
        User = { GetActivePlayers = fun () ->
            async {
                return [
                    { Id = "player1@email.com"; Heroes = [] }
                    { Id = "player2@email.com"; Heroes = [] }
                ]
            }
        }

        Battle = {
            PlaceCard = fun (heroId: HeroId) (column: Column) (unit: Unit, quantity: uint) -> 
                async {
                    
                }  
        }
    }