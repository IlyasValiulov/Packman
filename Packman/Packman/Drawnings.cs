using System.Drawing.Drawing2D;

namespace Packman;

public class Drawnings
{
    int picture_width;
    int picture_height;
    public int panel_width = 30;
    public int panel_height = 30;
    public Drawnings(int picture_width, int picture_height)
    {
        this.picture_width = picture_width;
        this.picture_height = picture_height;
    }
    public void DrawFloor(Graphics g)
    {
        SolidBrush brush = new SolidBrush(Color.Black);
        g.FillRectangle(brush, 0, 0, picture_width, picture_height);
    }
    public void DrawWall(Graphics g, int x, int y)
    {
        SolidBrush brush = new SolidBrush(Color.Blue);
        int cornerRadius = 7;
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddArc(x, y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(x + panel_width - cornerRadius * 2, y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(x + panel_width - cornerRadius * 2, y + panel_height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(x, y + panel_height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseFigure();
            g.FillPath(brush, path);
        }
    }
    public void DrawFloor(Graphics g, int x, int y)
    {
        SolidBrush brush = new SolidBrush(Color.Black);
        g.FillRectangle(brush, x, y, panel_width, panel_height);
    }
    public void DrawFloorWithPrice(Graphics g, int x, int y)
    {
        DrawFloor(g, x, y);
        SolidBrush brush = new SolidBrush(Color.Yellow);
        g.FillEllipse(brush, x + panel_width/2 - 5, y+panel_height/2 - 5, 10, 10);
    }
}
