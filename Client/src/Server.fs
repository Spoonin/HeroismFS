module Server

open Fable.Remoting.Client
open Heroism.Shared


let api =
    Remoting.createApi()
    |> Remoting.buildProxy<IHeroismApi>