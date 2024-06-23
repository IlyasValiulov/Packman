namespace Packman;

public partial class MainGameForm : Form
{
    Map map;
    Packman packman;
    Graphics gr;
    Drawnings d;
    NPC ghost1;
    NPC ghost2;
    NPC ghost3;
    NPC ghost4;
    Thread thread;
    public MainGameForm()
    {
        InitializeComponent();
        this.KeyDown += Form_KeyDown;

        map = new Map();
        map.LoadMap(GetPathProject() + "\\Maps\\map01.txt");
        
        d = new Drawnings(pictureBox.Width, pictureBox.Height);
        Bitmap bmp = new(pictureBox.Width, pictureBox.Height);
        gr = Graphics.FromImage(bmp);

        packman = new Packman(map);
        packman.SetBorders(pictureBox.Width, pictureBox.Height);
        packman.SetPosition(35, 35);

        ghost1 = new NPC(map, "\\images\\ghost.png", packman);
        ghost1.SetBorders(pictureBox.Width, pictureBox.Height);
        ghost1.SetPosition(305, 280);
        ghost2 = new NPC(map, "\\images\\ghost_blue.png", packman);
        ghost2.SetBorders(pictureBox.Width, pictureBox.Height);
        ghost2.SetPosition(305, 315);
        ghost3 = new NPC(map, "\\images\\ghost_orange.png", packman);
        ghost3.SetBorders(pictureBox.Width, pictureBox.Height);
        ghost3.SetPosition(280, 315);
        ghost4 = new NPC(map, "\\images\\ghost_fright.png", packman);
        ghost4.SetBorders(pictureBox.Width, pictureBox.Height);
        ghost4.SetPosition(332, 315);

        DrawMap();
        
        pictureBox.Image = bmp;
        pictureBox.Controls.Add(packman.packman);
        pictureBox.Controls.Add(ghost1.npc);
        pictureBox.Controls.Add(ghost2.npc);
        pictureBox.Controls.Add(ghost3.npc);
        pictureBox.Controls.Add(ghost4.npc);

        timer.Interval = 50; 
        timer.Enabled = true;
        timer.Tick += GhostMove;
    }
    public static string GetPathProject()
    {
        string[] path = Directory.GetCurrentDirectory().Split('\\');
        string pathNeed = "";
        for (int i = 0; i < path.Length - 3; i++)
        {
            pathNeed += path[i] + "\\";
        }
        return pathNeed;
    }
    private void DrawMap()
    {
        int x = 0;
        int y = 0;
        d.DrawFloor(gr);
        for (int i = 0; i < map.rows; i++)
        {
            for (int j = 0; j < map.cols; j++)
            {
                if (map.map[i, j] == 0)
                {
                    d.DrawWall(gr, x, y);
                }
                else if (map.map[i, j] == 1)
                {
                    d.DrawFloorWithPrice(gr, x, y);
                }
                else if (map.map[i, j] == 2) 
                {
                    d.DrawFloor(gr, x, y);
                }
                x += d.panel_width;
            }
            x = 0;
            y += d.panel_height;
        }
    }
    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (map.CountRemainderPrices() == 0)
        {
            labelWin.Visible = true;
            return;
        }
        if (packman.GetHealth() == 0)
        {
            return;
        }
        if (e.KeyCode == Keys.Up)
        {
            packman.Move(DirectionEnum.Up);
        }
        else if (e.KeyCode == Keys.Down)
        {
            packman.Move(DirectionEnum.Down);
        }
        else if (e.KeyCode == Keys.Left)
        {
            packman.Move(DirectionEnum.Left);
        }
        else if (e.KeyCode == Keys.Right)
        {
            packman.Move(DirectionEnum.Right);
        }
        DrawMap();
        labelScoreResult.Text = packman.GetScore().ToString();
    }
    public void GhostMove(object sender, EventArgs e)
    {
        if (map.CountRemainderPrices() == 0)
        {
            labelWin.Visible = true;
            return;
        }
        if (packman.GetHealth() == 0)
        {
            return;
        }
        ghost1.Move();
        ghost2.Move();
        ghost3.Move();
        ghost4.Move();
        switch (packman.GetHealth())
        {
            case 2:
                pictureBoxHeart3.Visible = false;
                break;
            case 1:
                pictureBoxHeart2.Visible = false;
                break;
            case 0:
                pictureBoxHeart1.Visible = false;
                labelLose.Visible = true;
                break;
        }
    }
}
