namespace Packman;

public class Packman
{
    public Label? packman = null;
    private Map map;
    private int x;
    private int y;
    private int width = 20;
    private int height = 19;
    private int picture_width;
    private int picture_height;
    private Image? usual_packman = null;
    private Image? eaten_packman = null;
    private int step = 8;
    private int panel_size;
    private int score = 0;
    private int health = 3;
    public Packman(Map map)
    {
        usual_packman = Image.FromFile(MainGameForm.GetPathProject() + "images\\paku.png");
        eaten_packman = Image.FromFile(MainGameForm.GetPathProject() + "images\\man.png");
        if (usual_packman == null || eaten_packman == null) return;
        packman = new Label();
        packman.Image = usual_packman;
        packman.BackColor = Color.Transparent;
        this.map = map;
        panel_size = map.panel_size;
    }
    public int GetScore()
    {
        return score;
    }
    public void ReduceHealth()
    {
        health -= 1;
    }
    public int GetHealth() { 
        return health;
    }
    public (int, int, int, int) GetCoordinates()
    {
        return (x, y, x + width, y + height);
    }
    public void SetPosition(int x, int y)
    {
        if (packman == null) return;
        this.x = x;
        this.y = y;
        packman.SetBounds(x, y, width, height);
    }
    private bool CheckPosition(DirectionEnum direction)
    {
        if (direction == DirectionEnum.Left)
        {
            int next_x_left = x - step;
            int i_up = y / panel_size;
            int i_down = (y + height) / panel_size;
            int j = next_x_left / panel_size;
            if (next_x_left < 0 && (map.map[i_up, map.cols - 1] == 1 || map.map[i_up, map.cols - 1] == 2))
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
            if (j == map.cols  && (map.map[i_up, 0] == 1 || map.map[i_up, 0] == 2))
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
    public void IsGetPrice()
    {
        int i = (y + height / 2) / panel_size;
        int j = (x + width / 2) / panel_size;
        if (map.map[i, j] == 2) return;
        if (i * panel_size + panel_size/2 > y && i * panel_size + panel_size / 2 < y + width && j * panel_size + panel_size / 2 > x && j * panel_size + panel_size / 2 < x + width)
        {
            map.map[i, j] = 2;
            score += 10;
            SetEatenPackman();
        }
    }
    public void SetUsualPackman()
    {
        if (packman == null) return;
        packman.Image = usual_packman;
    }
    public void SetEatenPackman()
    {
        if (packman == null) return;
        packman.Image = eaten_packman;
    }
    public void Move(DirectionEnum direction)
    {
        SetUsualPackman();
        switch(direction)
        {
            case DirectionEnum.Left:
                if (CheckPosition(direction))
                {
                    SetPosition(x - step, y);
                    IsGetPrice();
                }
                break;
            case DirectionEnum.Right:
                if (CheckPosition(direction))
                {
                    SetPosition(x + step, y);
                    IsGetPrice();
                }
                break;
            case DirectionEnum.Up:
                if (CheckPosition(direction))
                {
                    SetPosition(x, y - step);
                    IsGetPrice();
                }
                break;
            case DirectionEnum.Down:
                if (CheckPosition(direction))
                {
                    SetPosition(x, y + step);
                    IsGetPrice();
                }
                break;
        }
    }
    public void SetBorders(int width, int height)
    {
        picture_width = width; 
        picture_height = height;
    }
}
