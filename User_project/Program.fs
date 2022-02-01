﻿namespace Synthesizer

open System.IO
//open SFML.Audio
//open SFML.System
open System.Diagnostics // needed to play song on MAC OS
open System.Numerics
open Synthesizer



module Program =
    let synth = Synth()
    let input = synth.Add [synth.Note Whole Note.A 2; synth.Note Whole Note.A 3; synth.Note Whole Note.A 4; synth.Note Whole Note.A 5]
    printfn "Wanted:   %A" [CalcNoteFreq(Note.A, 2).Output; CalcNoteFreq(Note.A, 3).Output; CalcNoteFreq(Note.A, 4).Output; CalcNoteFreq(Note.A, 5).Output]
    synth.WriteToWav "A345.wav" [input]
    let output = synth.Fourier 44100. input
    let freq = FrequencyAnalysis.LocalMaxValuesIndices 0.25 output
    let amplitudes = output |> Map.filter (fun f _ -> List.contains f freq)
    //printfn "%f %f %f %f" (List.average input) (List.average output) (List.sum input) (List.sum output)
    printfn "Obtained: %A" freq
    printfn "Amplitudes: %A" amplitudes
    synth.PreviewMap "A 3,4,5 Analysis" output |> ignore
