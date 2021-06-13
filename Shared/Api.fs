namespace SharedModels

type IHeroismApi = {
    getActivePlayers: unit -> Async<User list>
}