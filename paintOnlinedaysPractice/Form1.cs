using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace paintOnlinedaysPractice
{
    public partial class Form1 : Form
    {
        


        List<Shape> AllShapes= new List<Shape>();

        Shape shape = null;
        int Xpos = 0;
        int Ypos = 0;
       
       ColorDialog diloge= new ColorDialog();
        Color color = Color.Black;

        public enum TOOL
        {
            SELECT,
            CIRCLE,
            RECTANGLE,
            LINE,
            BAZIER,
            PENCIL,
            ROUNDED

        }
        TOOL choice=TOOL.SELECT;

        bool cheack = false;
       

        public Form1()
        {
            InitializeComponent();
            g = MainBox.CreateGraphics();

        }
        
        Graphics g;


        private void MainBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (shape != null && cheack == true)
            {
                shape.Draw(e.Graphics);
            }

            foreach (Shape s in AllShapes)
            {
                s.Draw(e.Graphics);
            }
            DoubleBuffered = true;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {

            choice = TOOL.RECTANGLE;
           
        }

        private void btncircle_Click(object sender, EventArgs e)
        {
            choice = TOOL.CIRCLE;
        }
        private void btnLine_Click(object sender, EventArgs e)
        {
            choice = TOOL.LINE;
        }

        private void RoundedRectangle_Click(object sender, EventArgs e)
        {
            choice = TOOL.ROUNDED;

        }

        private void btnBazier_Click(object sender, EventArgs e)
        {
            choice = TOOL.BAZIER;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            Guna2Button b=(Guna2Button)sender;
            color =b.FillColor;
            btnMainColor.FillColor = color;
        }

        private void FillColor_Click(object sender, EventArgs e)
        {
            //  FillColor.BackColor= btnMainColor.FillColor;
            //MessageBox.Show(FillColor.FillColor.ToString());
            //FillColor.BackColor= Color.Transparent;
            //choice = TOOL.FILL;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.Filter = "Image(*.jpg)|*.jpg|(*.*|*.*";
            if(sdf.ShowDialog() == DialogResult.OK)
            {
                if (MainBox.Image != null)
                {
                    MainBox.Image.Save(sdf.FileName);
                }
            }
          
        }

        private void colorChose_Click(object sender, EventArgs e)
        {
            diloge.ShowDialog();
            color=diloge.Color;
            btnMainColor.FillColor = color;
        }

        private void MainBox_MouseDown(object sender, MouseEventArgs e)
        {

            Xpos = e.X;
            Ypos = e.Y;
          
            switch (choice)
            {
                case TOOL.RECTANGLE:
                    shape = new RRectangle(0, 0, color);
                    break;
                case TOOL.CIRCLE:

                    shape = new Circle(0, color);
                    break;
                case TOOL.LINE:
                    shape = new Line(Xpos, Ypos, color);
                    break;
                case TOOL.BAZIER:
                    shape = new Bezier(Xpos, Ypos, Xpos, Ypos, Xpos, Ypos, color);

                    break;
                case TOOL.ROUNDED:
                    shape = new RoundRect(Xpos, Ypos, Xpos, Ypos, Xpos, Ypos,color);
                    break;
            }

            if (shape != null)
            {
                shape.X = Xpos;
                shape.Y = Ypos;
                cheack = true;

            }
        }

        private void MainBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (shape != null)
            {
                AllShapes.Add(shape);
                Invalidate();
                cheack = false;
                shape = null;
            }
        }

        private void MainBox_MouseMove(object sender, MouseEventArgs e)
        {
            FormLabel.Text = e.X.ToString() + ", " + e.Y.ToString() + "px";
            int a = e.X - Xpos;
            int b = e.Y - Ypos;
           
            if (shape != null)
            {
                switch (choice)
                {
                    case TOOL.RECTANGLE:
                        ((RRectangle)shape).Width = e.X - Xpos;
                        ((RRectangle)shape).Height = e.Y - Ypos;
                        ((RRectangle)shape).color = color;

                        ShapeLabel.Text = a.ToString() + " x " + b.ToString() + "px";
                        break;

                    case TOOL.CIRCLE:
                        ((Circle)shape).Radius = e.X - Xpos;
                        ((Circle)shape).color = color;
                        ShapeLabel.Text = a.ToString() + "x " + a.ToString() + "px";
                        break;
                    case TOOL.LINE:
                        ((Line)shape).X1 = e.X;
                        ((Line)shape).Y1 = e.Y;
                        ((Line)shape).color = color;
                        // ShapeLabel.Text = a.ToString() + "x " + b.ToString() + "px";
                        break;
                    case TOOL.BAZIER:
                        ((Bezier)shape).C1 = Convert.ToInt32(e.X * 1.5);
                        ((Bezier)shape).C2 = Convert.ToInt32(e.Y * 1.6);
                        ((Bezier)shape).C3 = Convert.ToInt32(e.X * 0.5);
                        ((Bezier)shape).C4 = Convert.ToInt32(e.Y * 2.5);
                        ((Bezier)shape).E1 = Convert.ToInt32(e.X + 1.1);
                        ((Bezier)shape).E2 = Convert.ToInt32(e.Y * 2.7);
                        //   ShapeLabel.Text = a.ToString() + "x " + b.ToString() + "px";
                        ((Bezier)shape).color = color;
                        break;
                    case TOOL.ROUNDED:
                        ((RoundRect)shape).X1 = Convert.ToInt32(e.X * 2);
                        ((RoundRect)shape).Y1 =Ypos;
                        ((RoundRect)shape).X2 = Convert.ToInt32(e.X * 2);
                        ((RoundRect)shape).Y2 =Convert.ToInt32(e.Y * 1.5);
                        ((RoundRect)shape).X3 = Xpos;
                        ((RoundRect)shape).Y3 = Convert.ToInt32(e.Y * 1.5);
                        ((RoundRect)shape).color = color;
                        break;
                }
               Invalidate();
                MainBox.Refresh();


            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           
           Bitmap bmp = new Bitmap(MainBox.ClientSize.Width, MainBox.ClientSize.Height);
            MainBox.DrawToBitmap(bmp,new Rectangle(0, 0, MainBox.ClientSize.Width, MainBox.ClientSize.Height));
            SaveFileDialog dialogue = new SaveFileDialog();
            dialogue.Title = "New Image";
            dialogue.DefaultExt = "jpeg";
            dialogue.Filter = "JPEG files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
            dialogue.FilterIndex = 2;
            if (dialogue.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(dialogue.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Image Saved Successfully");
            }
        }

      

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            {
                openFileDialog1.Title = "Browse Image Files";
                openFileDialog1.DefaultExt = "jpeg";
                openFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg";
                openFileDialog1.FilterIndex = 2;
            }
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MainBox.ImageLocation = openFileDialog1.FileName;

            }
        }

        private void eraserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            g.Clear(MainBox.BackColor);
            MainBox.BackColor = Color.White;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

