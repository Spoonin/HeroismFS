module App

open Feliz
open Elmish
open SharedModels
open Users

type State = { ActiveUsers: Deferred<Result<User list, string>> }

type Msg =
    | LoadActiveUsers of AsyncOperationStatus<Result<User list, string>>

let init() = { ActiveUsers = HasNotStartedYet }, Cmd.ofMsg (LoadActiveUsers Started)

let update (msg: Msg) (state: State) =
    match msg with
    | LoadActiveUsers Started ->
        let loadActiveUsers = async {
            try
                let! users = Server.api.User.GetActivePlayers()
                return LoadActiveUsers (Finished (Ok users))
            with error ->
                Log.developmentError error
                return LoadActiveUsers (Finished (Error "Error while retrieving Counter from server"))
        }
        { state with ActiveUsers = InProgress }, Cmd.fromAsync loadActiveUsers
    | LoadActiveUsers (Finished users) ->
        { state with ActiveUsers = Resolved users }, Cmd.none

let renderUsers (users: Deferred<Result<User list, string>>)=
    match users with
    | HasNotStartedYet -> Html.none
    | InProgress -> Html.h1 "Loading..."
    | Resolved (Ok users) -> Html.ol (List.map (fun (user: User) -> Html.li user.Id) users)
    | Resolved (Error errorMsg) ->
        Html.h1 [
            prop.style [ style.color.crimson ]
            prop.text errorMsg
        ]

let fableLogo() = StaticFile.import "./imgs/fable_logo.png"

let render (state: State) (dispatch: Msg -> unit) =

    Html.div [
        prop.style [
            style.textAlign.center
            style.padding 40
        ]

        prop.children [

            Html.img [
                prop.src(fableLogo())
                prop.width 250
            ]

            Html.h1 "Heroism"


            renderUsers state.ActiveUsers
        ]
    ]