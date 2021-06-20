namespace HeroismFS

open SharedModels

module Server =

    let server: IHeroismApi = {
        GetActivePlayers = fun () ->
            async {
                return [
                    { Id = "player1@email.com"; Heroes = [] }
                    { Id = "player2@email.com"; Heroes = [] }
                ]
            }
    }