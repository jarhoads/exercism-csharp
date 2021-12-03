using System;

public class RailFenceCipher
{
    
    private readonly int height;
    public RailFenceCipher(int rails)
    {
        
        height = rails;
    }

    public string Encode(string input)
    {
        var encodedRails = BuildRails(input);
        var encoded = "";
        for (int i=0; i<encodedRails.GetLength(0); i++)
        {
            for (int j=0; j<encodedRails.GetLength(1); j++)
            {
                encoded += encodedRails[i,j];
            }
            
        }

        return encoded;
    }

    public string[,] BuildRails(string input)
    {
        var rail = new string[height, input.Length];
        var row = 0;
        var down = true;
        
        for (int c=0; c<input.Length; c++)
        {
            rail[row, c] = $"{input[c]}";

            if (row == 0) { down = true; }
            else if (row == height - 1) { down = false; }

            if (down) { row++; }
            else if (!down) { row--; }
            
        }   

        return rail;     
    }

    public string Decode(string input)
    {
        var markers = "";
        for (int i=0; i<input.Length; i++) { markers += "?"; }
        
        var markerRails = BuildRails(markers);
        var decodedRails = ReplaceMarkers(markerRails, input);
        var decoded = BuildDecoded(decodedRails);

        return decoded;
    }

    public string[,] ReplaceMarkers(string[,] markerRails, string encoded)
    {
        var cIdx = 0;
        for (int i=0; i<markerRails.GetLength(0); i++)
        {
            for (int j=0; j<markerRails.GetLength(1); j++)
            {
                if(markerRails[i,j] == "?") 
                { 
                    markerRails[i,j] = $"{encoded[cIdx]}";
                    cIdx++;
                }
            }
        }

        return markerRails;

    }

    public string BuildDecoded(string[,] rail)
    {
        var decoded = "";
        var down = true;
        int row = 0;
        for (int c=0; c<rail.GetLength(1); c++)
        {
            decoded += $"{rail[row, c]}";

            if (row == 0) { down = true; }
            else if (row == height - 1) { down = false; }

            if (down) { row++; }
            else if (!down) { row--; }
        }

        return decoded;
    }
}