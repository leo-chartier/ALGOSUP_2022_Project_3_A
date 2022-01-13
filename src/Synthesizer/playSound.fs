module playSound
    open System.IO
    open SFML.Audio
    open SFML.System

    let playWithOffset (stream:Stream) offset =
        let soundBuffer = new SoundBuffer(stream:Stream)
        let sound = new Sound(soundBuffer)
        let timeOffset = Time.FromSeconds(offset)
        sound.PlayingOffset <- timeOffset
        sound.Play()
        ignore (System.Console.ReadLine())

    let play stream =
        playWithOffset stream (float32(0.))

    let playWithOffsetFromPath (filePath:string) offset =
        let stream = read.readAndReturnStream(File.Open (filePath, FileMode.Open))
        playWithOffset stream offset 


        
    // let cutStart (data:float[]) (sampleRate:float) time = 
    //     data[sampleRate * time - ..]

    // let cutEnd (data:float[]) (sampleRate:float) time = 
    //     data[.. - sampleRate * time]
    
    