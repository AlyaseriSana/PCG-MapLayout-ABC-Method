using System;
using System.Drawing;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MapABC
{
    class Room
    {
    static int w = 30;
    static int h = 30;
    static int D = w / 3;
    static float D1 = D / 2;
    private float D2 = D / 3;

    public int width = w;
    public int Hight = h;
    SolidBrush ColorWhiteBrush = new SolidBrush(Color.White);
    Pen ColorBlackPen = new Pen(Color.Black, 2);
    Pen ColorRedPen = new Pen(Color.Red, 3);
    Pen ColorWhitePen = new Pen(Color.White, 2);
    public void NormalRoomSize1(PaintEventArgs e1, int X, int Y) // Door Up   Size 1
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF PP1 = new PointF(X, Y);
        PointF PP2 = new PointF(X + w, Y);
        PointF PP3 = new PointF(X + w, Y + h);
        PointF[] CurvePoint = { PP1, PP2, PP3 };
        //g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.FillPolygon(ColorWhiteBrush, CurvePoint);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        g.DrawLine(ColorBlackPen, X, Y, X + w, Y + h);
        g.DrawLine(ColorWhitePen, p1, p2);

    }
    public void NormalRoomSize2(PaintEventArgs e1, int X, int Y) // Door left and right
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D, Y + w);
        PointF p4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF p5 = new PointF(X, Y + D);
        PointF p6 = new PointF(X, Y + 2 * D); //  is represented how many cloulmns should move
        PointF p7 = new PointF(X + h, Y + D);
        PointF p8 = new PointF(X + h, Y + 2 * D); // is represented how many cloulmns should move, it will be same row
        g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);

        g.DrawLine(ColorWhitePen, p1, p2);
        g.DrawLine(ColorWhitePen, p3, p4);
        
        g.DrawLine(ColorWhitePen, p7, p8);

    }
    public void NormalRoomSize3(PaintEventArgs e1, int X, int Y) // Door Down and up
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D, Y + w);
        PointF p4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF p5 = new PointF(X + D, Y + D);
        PointF p6 = new PointF(X + 2 * D, Y + 2 * D);
        g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        g.DrawLine(ColorBlackPen, X, Y, X + w, Y + h);
        g.DrawLine(ColorWhitePen, p5, p6); // line in the meddle of the squer 

        g.DrawLine(ColorWhitePen, p1, p2);
        g.DrawLine(ColorWhitePen, p3, p4);

    }

    public void NormalRoomSize4(PaintEventArgs e1, int X, int Y) // Door Right
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + h, Y + D);
        PointF p2 = new PointF(X + h, Y + 2 * D); // is represented how many cloulmns should move, it will be same row
        g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        g.DrawArc(ColorBlackPen, X + D1, Y + D1, w, h, 45.0f, 270.0f);
        g.DrawLine(ColorWhitePen, p1, p2);

    }
    public void NormalRoomSize5(PaintEventArgs e1, int X, int Y) // Door Up and dawn
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D, Y + w);
        PointF p4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        g.DrawLine(ColorWhitePen, p1, p2);
        g.DrawLine(ColorWhitePen, p3, p4);

    }

    public void NormalRoomSize6(PaintEventArgs e1, int X, int Y) // Door Up and dawn and left
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D, Y + w);
        PointF p4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF p5 = new PointF(X, Y + D);
        PointF p6 = new PointF(X, Y + 2 * D); //  is represented how many cloulmns should move
        g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        g.DrawLine(ColorWhitePen, p1, p2); //up
        g.DrawLine(ColorWhitePen, p3, p4); // dawn
        g.DrawLine(ColorWhitePen, p5, p6); // left 

    }

    public void NormalRoomSize7(PaintEventArgs e1, int X, int Y) // four doors
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D, Y + w);
        PointF p4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF p5 = new PointF(X, Y + D);
        PointF p6 = new PointF(X, Y + 2 * D); //  is represented how many cloulmns should move
        PointF p7 = new PointF(X + h, Y + D);
        PointF p8 = new PointF(X + h, Y + 2 * D); // is represented how many cloulmns should move, it will be same row
        g.FillRectangle(ColorWhiteBrush, X, Y, w, h);
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        g.DrawLine(ColorWhitePen, p1, p2);
        g.DrawLine(ColorWhitePen, p3, p4);
        g.DrawLine(ColorWhitePen, p5, p6);
        g.DrawLine(ColorWhitePen, p7, p8);

    }
    public void PolygonSize8(PaintEventArgs e1, int X, int Y) // Doors all sides and draw 
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D1, Y + (D / 2));
        PointF p2 = new PointF(X + D1, Y + (D / 2) + w - D); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D1 + (2 * D), Y + D1);
        PointF p4 = new PointF(X + D1 + (2 * D), Y + D1 + w - D);
        // Doors points
        PointF Do1 = new PointF(X + D, Y);
        PointF Do2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF Do3 = new PointF(X + D, Y + w);
        PointF Do4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF Do5 = new PointF(X, Y + D);
        PointF Do6 = new PointF(X, Y + 2 * D); //  is represented how many cloulmns should move
        PointF Do7 = new PointF(X + h, Y + D);
        PointF Do8 = new PointF(X + h, Y + 2 * D); // is represented how many cloulmn
        g.FillRectangle(ColorWhiteBrush, X + D1, Y, w - D, h);
        g.FillRectangle(ColorWhiteBrush, X + D1 - D1, Y + D1, w, h - D);
        g.DrawRectangle(ColorBlackPen, X + D1, Y, w - D, h);
        g.DrawRectangle(ColorBlackPen, X + D1 - D1, Y + D1, w, h - D);
        g.DrawLine(ColorWhitePen, p1, p2); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p1, p3); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p2, p4); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p3, p4);// delete the internal lines 

        // Draw the doors 

        g.DrawLine(ColorWhitePen, Do1, Do2);
        g.DrawLine(ColorWhitePen, Do3, Do4);
        g.DrawLine(ColorWhitePen, Do5, Do6);
        g.DrawLine(ColorWhitePen, Do7, Do8);

    }

    public void PolygonSize9(PaintEventArgs e1, int X, int Y) // Doors Up and Down
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D1, Y + (D / 2));
        PointF p2 = new PointF(X + D1, Y + (D / 2) + w - D); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D1 + (2 * D), Y + D1);
        PointF p4 = new PointF(X + D1 + (2 * D), Y + D1 + w - D);
        // Doors points
        PointF Do1 = new PointF(X + D, Y);
        PointF Do2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF Do3 = new PointF(X + D, Y + w);
        PointF Do4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF Do5 = new PointF(X, Y + D);
        PointF Do6 = new PointF(X, Y + 2 * D); //  is represented how many cloulmns should move
        PointF Do7 = new PointF(X + h, Y + D);
        PointF Do8 = new PointF(X + h, Y + 2 * D); // is represented how many cloulmn
        g.FillRectangle(ColorWhiteBrush, X + D1, Y, w - D, h);
        g.FillRectangle(ColorWhiteBrush, X + D1 - D1, Y + D1, w, h - D);
        g.DrawRectangle(ColorBlackPen, X + D1, Y, w - D, h);
        g.DrawRectangle(ColorBlackPen, X + D1 - D1, Y + D1, w, h - D);
        g.DrawLine(ColorWhitePen, p1, p2); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p1, p3); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p2, p4); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p3, p4);// delete the internal lines 

        // Draw the doors 

        g.DrawLine(ColorWhitePen, Do1, Do2);
        g.DrawLine(ColorWhitePen, Do3, Do4);
        //g.DrawLine(ColorWhitePen, Do5, Do6);
        // g.DrawLine(ColorWhitePen, Do7, Do8);

    }

    public void PolygonSize10(PaintEventArgs e1, int X, int Y) // Doors left and right
    {
        Graphics g = e1.Graphics;
        PointF p1 = new PointF(X + D1, Y + (D / 2));
        PointF p2 = new PointF(X + D1, Y + (D / 2) + w - D); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D1 + (2 * D), Y + D1);
        PointF p4 = new PointF(X + D1 + (2 * D), Y + D1 + w - D);
        // Doors points
        PointF Do1 = new PointF(X + D, Y);
        PointF Do2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF Do3 = new PointF(X + D, Y + w);
        PointF Do4 = new PointF(X + 2 * D, Y + w); // is represented how many cloulmns should move, it will be same row
        PointF Do5 = new PointF(X, Y + D);
        PointF Do6 = new PointF(X, Y + 2 * D); //  is represented how many cloulmns should move
        PointF Do7 = new PointF(X + h, Y + D);
        PointF Do8 = new PointF(X + h, Y + 2 * D); // is represented how many cloulmn
        g.FillRectangle(ColorWhiteBrush, X + D1, Y, w - D, h);
        g.FillRectangle(ColorWhiteBrush, X + D1 - D1, Y + D1, w, h - D);
        g.DrawRectangle(ColorBlackPen, X + D1, Y, w - D, h);
        g.DrawRectangle(ColorBlackPen, X + D1 - D1, Y + D1, w, h - D);
        g.DrawLine(ColorWhitePen, p1, p2); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p1, p3); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p2, p4); // delete the internal lines 
        g.DrawLine(ColorWhitePen, p3, p4);// delete the internal lines 

        // Draw the doors 

        // g.DrawLine(ColorWhitePen, Do1, Do2);
        //g.DrawLine(ColorWhitePen, Do3, Do4);
        g.DrawLine(ColorWhitePen, Do5, Do6);
        g.DrawLine(ColorWhitePen, Do7, Do8);

    }



    public void HallWays11(PaintEventArgs e1, int X, int Y)
    {
        Graphics g = e1.Graphics;
        PointF pp1 = new PointF(X, Y);
        PointF pp2 = new PointF(X + D, Y + D);
        PointF pp3 = new PointF(X + D, Y + 2 * D);
        PointF pp4 = new PointF(X, Y + 3 * D);
        PointF pp5 = new PointF(X + 3 * D, Y + 3 * D);
        PointF pp6 = new PointF(X + 2 * D, Y + 2 * D);
        PointF pp7 = new PointF(X + 2 * D, Y + D);
        PointF pp8 = new PointF(X + 3 * D, Y);
        PointF[] curvePoints = { pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8 };
        // for Doors
        PointF p1 = new PointF(X + D, Y);
        PointF p2 = new PointF(X + 2 * D, Y); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D, Y + 3 * D);
        PointF p4 = new PointF(X + 2 * D, Y + 3 * D);
        g.FillPolygon(ColorWhiteBrush, curvePoints);
        g.DrawPolygon(ColorBlackPen, curvePoints);
        g.DrawLine(ColorBlackPen, pp1, pp4);
        g.DrawLine(ColorBlackPen, pp5, pp8);
        g.DrawLine(ColorWhitePen, p1, p2);
        g.DrawLine(ColorWhitePen, p3, p4);

    }
    public void HallWays12(PaintEventArgs e1, int X, int Y)
    {
        Graphics g = e1.Graphics;
        PointF pp1 = new PointF(X, Y);
        PointF pp2 = new PointF(X, Y + 3 * D);
        PointF pp3 = new PointF(X + D, Y + 2 * D);
        PointF pp4 = new PointF(X + 2 * D, Y + 2 * D);
        PointF pp5 = new PointF(X + 3 * D, Y + 3 * D);
        PointF pp6 = new PointF(X + 3 * D, Y);
        PointF pp7 = new PointF(X + 2 * D, Y + D);
        PointF pp8 = new PointF(X + D, Y + D);
        PointF[] curvePoints = { pp1, pp2, pp3, pp4, pp5, pp6, pp7, pp8 };
        // for Doors
        PointF p1 = new PointF(X, Y + D);
        PointF p2 = new PointF(X, Y + 2 * D); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + 3 * D, Y + D);
        PointF p4 = new PointF(X + 3 * D, Y + 2 * D);
        g.FillPolygon(ColorWhiteBrush, curvePoints);
        g.DrawPolygon(ColorBlackPen, curvePoints);
        g.DrawLine(ColorBlackPen, pp1, pp6);
        g.DrawLine(ColorBlackPen, pp2, pp5);
        g.DrawLine(ColorWhitePen, p1, p2);
        g.DrawLine(ColorWhitePen, p3, p4);

    }



    public void EventRoomSize13(PaintEventArgs e1, int X, int Y) // Doors all sides 
    {
        Graphics g = e1.Graphics;
        // X = X + (int) D1;
        Y = Y + (int)D;
        //D2 = D1;
        PointF p0 = new PointF(X, Y);
        PointF p1 = new PointF(X, Y + 4 * D2);
        PointF p2 = new PointF(X + D2, Y + 4 * D2); // is represented how many cloulmns should move, it will be same row
        PointF p3 = new PointF(X + D2, Y + 5 * D2);
        PointF p4 = new PointF(X + 2 * D2, Y + 5 * D2);
        PointF p5 = new PointF(X + 2 * D2, Y + 6 * D2);
        PointF p6 = new PointF(X + 3 * D2, Y + 6 * D2);
        PointF p7 = new PointF(X + 3 * D2, Y + 7 * D2); //
        PointF p8 = new PointF(X + 7 * D2, Y + 7 * D2);
        PointF p9 = new PointF(X + 7 * D2, Y + 6 * D2);
        PointF p10 = new PointF(X + 8 * D2, Y + 6 * D2);
        PointF p11 = new PointF(X + 8 * D2, Y + 5 * D2);
        PointF p12 = new PointF(X + 9 * D2, Y + 5 * D2);
        PointF p13 = new PointF(X + 9 * D2, Y + 4 * D2);
        PointF p14 = new PointF(X + 10 * D2, Y + 4 * D2);
        PointF p15 = new PointF(X + 10 * D2, Y);
        PointF p16 = new PointF(X + 9 * D2, Y);
        PointF p17 = new PointF(X + 9 * D2, Y - D2);
        PointF p18 = new PointF(X + 8 * D2, Y - D2);
        PointF p19 = new PointF(X + 8 * D2, Y - 2 * D2);
        PointF p20 = new PointF(X + 7 * D2, Y - 2 * D2);
        PointF p21 = new PointF(X + 7 * D2, Y - 3 * D2);
        PointF p22 = new PointF(X + 3 * D2, Y - 3 * D2);
        PointF p23 = new PointF(X + 3 * D2, Y - 2 * D2);
        PointF p24 = new PointF(X + 2 * D2, Y - 2 * D2);
        PointF p25 = new PointF(X + 2 * D2, Y - D2);
        PointF p26 = new PointF(X + D2, Y - D2);
        PointF p27 = new PointF(X + D2, Y);

        PointF pp1 = new PointF(X, Y + D2);
        PointF pp2 = new PointF(X, Y + 3 * D2);
        PointF pp3 = new PointF(X + 10 * D2, Y + D2);
        PointF pp4 = new PointF(X + 10 * D2, Y + 3 * D2);
        PointF pp5 = new PointF(X + 4 * D2, Y - 3 * D2);
        PointF pp6 = new PointF(X + 6 * D2, Y - 3 * D2);
        PointF pp7 = new PointF(X + 4 * D2, Y + 7 * D2);
        PointF pp8 = new PointF(X + 6 * D2, Y + 7 * D2);
        PointF[] curvePoints = { p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27 };

        // Fill polygon to screen.
        g.FillPolygon(ColorWhiteBrush, curvePoints);
        g.DrawPolygon(ColorBlackPen, curvePoints);
        g.DrawLine(ColorWhitePen, pp1, pp2);
        g.DrawLine(ColorWhitePen, pp3, pp4);
        g.DrawLine(ColorWhitePen, pp5, pp6);
        g.DrawLine(ColorWhitePen, pp7, pp8);
    }

    public void ImagBorders(PaintEventArgs e1, int X, int Y, int w, int h)
    {
        Graphics g = e1.Graphics;
        g.DrawRectangle(ColorBlackPen, X, Y, w, h);
        PointF P1 = new PointF(X, Y + 2 * D1);
        PointF P2 = new PointF(X, Y + 4 * D1);
        PointF P3 = new PointF(X + w, Y + h - (2 * D1));
        PointF P4 = new PointF(X + w, Y + h - (4 * D1));
        g.DrawLine(ColorWhitePen, P1, P2);
        g.DrawLine(ColorWhitePen, P3, P4);
    }
    } // end of Class room 
}

