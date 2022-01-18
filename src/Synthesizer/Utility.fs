namespace Synthesizer

module Utility = 
    let cutStart (data:float[]) (sampleRate:float) time = 
        data[int (sampleRate * time) .. data.Length]


    let cutEnd (data:float[]) (sampleRate:float) time = 
        data[0 .. data.Length - int (sampleRate * time)-1] //need to add another time for the end

    let add sounds =
        let size = sounds |> List.map List.length |> List.max
        let mean = 1. / (float (List.length sounds))
        let expand sound =
            List.append sound (Array.toList(Array.replicate (size - List.length sound) 0.))
        let rec addTwo (sounds: List<float> list) =
            match sounds with
            | a::b::rest -> addTwo ((List.map2 (+) a b)::rest)
            | [a] -> a
            | [] -> List.empty

        sounds |> List.map expand |> addTwo |> List.map ((*) mean)

    let cutCorners (data:List<float>) limit =
        let step = 1. / float limit
        let startVals = List.map2(fun x i -> x * step * i) data[..limit-1] [1. .. float limit]
        let endVals = List.map2(fun x i -> x * step * i) data[data.Length-limit..] [float limit .. -1. .. 1.]

        List.append (List.append startVals data[limit .. data.Length-limit-1]) endVals