namespace Packman;

public class Map
{
    // 0-стена 1-место с призом 2-место без приза
    public int[,] map;
    public int rows;
    public int cols;
    public int panel_size = 30;
    public bool LoadMap(string filename)
    {
        if (!File.Exists(filename))
        {
            return false;
        }
        using (StreamReader reader = new StreamReader(filename))
        {
            string[] firstline = reader.ReadLine().Split(' ');
            rows = int.Parse(firstline[0]);
            cols = int.Parse(firstline[1]);
            map = new int[rows, cols];
            string[] line;
            int i = 0;
            while ((line = reader.ReadLine()?.Split(' ')) != null && i < rows)
            {
                if (line.Length != cols || line == null ) continue;
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = int.Parse(line[j]);
                }
                i++;
            }
        }
        return true;
    }
    public int CountRemainderPrices()
    {
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j =0; j < cols; j++)
            {
                if ((map[i, j] == 1))
                    count++;
            }
        }
        return count;
    }
}
