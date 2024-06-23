namespace Packman;

public class NPC
{
    public Label npc;
    private Map map;
    private Packman packman;
    private int x;
    private int y;
    private int width = 20;
    private int height = 20;
    private int picture_width;
    private int picture_height;
    private int step = 8;
    private int panel_size;
    private DirectionEnum direction;
    public NPC(Map map, string filename, Packman packman)
    {
        Image? image_npc = Image.FromFile(MainGameForm.GetPathProject() + filename);
        if (image_npc == null) return;
        npc = new Label();
        npc.Image = image_npc;
        npc.BackColor = Color.Transparent;
        this.map = map;
        panel_size = map.panel_size;
        direction = DirectionEnum.Up;
        this.packman = packman;
    }
    public void SetBorders(int width, int height)
    {
        picture_width = width;
        picture_height = height;
    }
    public void SetPosition(int x, int y)
    {
        if (npc == null) return;
        this.x = x;
        this.y = y;
        npc.SetBounds(x, y, width, height);
    }
    private bool CheckPosition(DirectionEnum direction)
    {
        if (direction == DirectionEnum.Left)
        {
            int next_x_left = x - step;
            int i_up = y / panel_size;
            int i_down = (y + height) / panel_size;
            int j = next_x_left / panel_size;
            if (j == 0 && (map.map[i_up, map.cols - 1] == 1 || map.map[i_up, map.cols - 1] == 2))
            {
                x = panel_size * (map.cols - 1) + 20;
                return true;
            }
            if ((map.map[i_up, j] == 1 || map.map[i_up, j] == 2) && (map.map[i_down, j] == 1 || map.map[i_down, j] == 2)) return true;
            return false;
        }
        else if (direction == DirectionEnum.Right)
        {
            int next_x_right = x + width + step;
            int i_up = y / panel_size;
            int i_down = (y + height) / panel_size;
            int j = next_x_right / panel_size;
            if (j == map.cols && (map.map[i_up, 0] == 1 || map.map[i_up, 0] == 2))
            {
                x = 0;
                return true;
            }
            if ((map.map[i_up, j] == 1 || map.map[i_up, j] == 2) && (map.map[i_down, j] == 1 || map.map[i_down, j] == 2)) return true;
            return false;
        }
        else if (direction == DirectionEnum.Up)
        {
            int next_y_up = y - step;
            int i = next_y_up / panel_size;
            int j_left = x / panel_size;
            int j_right = (x + width) / panel_size;
            if (next_y_up < 10 && (map.map[map.rows - 1, j_left] == 1 || map.map[map.rows - 1, j_left] == 2))
            {
                y = panel_size * map.rows - 15;
                return true;
            }
            if ((map.map[i, j_left] == 1 || map.map[i, j_left] == 2) && (map.map[i, j_right] == 1 || map.map[i, j_right] == 2)) return true;
            return false;
        }
        else if (direction == DirectionEnum.Down)
        {
            int next_y_down = y + height + step;
            int i = next_y_down / panel_size;
            int j_left = x / panel_size;
            int j_right = (x + width) / panel_size;
            if (i == map.rows && (map.map[0, j_left] == 1 || map.map[0, j_left] == 2))
            {
                y = 0;
                return true;
            }
            if ((map.map[i, j_left] == 1 || map.map[i, j_left] == 2) && (map.map[i, j_right] == 1 || map.map[i, j_right] == 2)) return true;
            return false;
        }
        return false;
    }
    public void Move()
    {
        bool flag = false;
        switch (direction)
        {
            case DirectionEnum.Left:
                if (CheckPosition(direction))
                {
                    SetPosition(x - step, y);
                    flag = true;
                }
                break;
            case DirectionEnum.Right:
                if (CheckPosition(direction))
                {
                    SetPosition(x + step, y);
                    flag = true;
                }
                break;
            case DirectionEnum.Up:
                if (CheckPosition(direction))
                {
                    SetPosition(x, y - step);
                    flag = true;
                }
                break;
            case DirectionEnum.Down:
                if (CheckPosition(direction))
                {
                    SetPosition(x, y + step);
                    flag = true;
                }
                break;
        }
        if (flag == false)
        {
            Random random = new Random();
            direction = (DirectionEnum)(random.Next(1, 1000) % 4 + 1);
            Move();
        }
        if (TouchedPackman())
        {
            packman.ReduceHealth();
            SetPosition(305, 315);
        }
    }
    public bool TouchedPackman()
    {
        int x_c = x + width / 2;
        int y_c = y + height / 2;
        var coordinates = packman.GetCoordinates();
        if (x_c >= coordinates.Item1 && y_c >= coordinates.Item2 && x_c <= coordinates.Item3 && y_c <= coordinates.Item4) 
        {
            return true;
        }
        return false;
    }
}
