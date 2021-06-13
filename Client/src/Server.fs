module Server

open Fable.Remoting.Client
open SharedModels


let api =
    Remoting.createApi()
    |> Remoting.buildProxy<IHeroismApi>