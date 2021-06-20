namespace SharedModels
    module Utils =
        let (<&>) f g = (fun x -> f x && g x)
