namespace HeroismFS

open SharedModels

module Server =

    let server: IHeroismApi = {
        getActivePlayers = fun () ->
            async {
                return [
                    { Id = "player1@email.com"; Heroes = [] }
                    { Id = "player2@email.com"; Heroes = [] }
                ]
            }
    }