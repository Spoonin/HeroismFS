namespace SharedModels

open System

type Hero = {
    Id : string
    Name : string
    PictureSrc : string
    Level : int
    Hand : Card list
}