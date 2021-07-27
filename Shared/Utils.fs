namespace Heroism.Shared
    open Microsoft.FSharp.Reflection
   
    module Utils =
        let (<&>) f g = (fun x -> f x && g x)


        let UnionCasesSeq<'T>() =
            FSharpType.GetUnionCases(typeof<'T>)
            |> Seq.map (fun x -> FSharpValue.MakeUnion(x, Array.zeroCreate(x.GetFields().Length)) :?> 'T)
