using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using HopfieldNeuralNetwork;

namespace Signature
{
    public partial class mainDialog : Form
    {
        NeuralNetwork network;
        List<Neuron> initial;
        Bitmap img;

        int n = 2500;
        int k = 50;
        int th = 90;

        public mainDialog()
        {
            network = new NeuralNetwork(n);

            InitializeComponent();
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Load Image";
                openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; ; *.png";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    learnDialog learn = new learnDialog();

                    if (learn.ShowDialog() == DialogResult.OK)
                    {
                        int t = learn.Value;


                        Bitmap temp = new Bitmap(openFile.FileName);
                        List<Neuron> pattern = new List<Neuron>(n);

                        int midColor = Math.Abs((int)(Color.Black.ToArgb() / 2));

                        for (int i = 0; i < temp.Width; i++)
                        {
                            for (int j = 0; j < temp.Height; j++)
                            {
                                Neuron n = new Neuron();
                                int p = Math.Abs(temp.GetPixel(i, j).ToArgb());
                                p = Math.Abs(temp.GetPixel(i, j).ToArgb());
                                if (p < midColor)
                                {
                                    temp.SetPixel(i, j, Color.White);
                                    n.State = NeuronStates.AlongField;
                                }
                                else
                                {
                                    temp.SetPixel(i, j, Color.Black);
                                    n.State = NeuronStates.AgainstField;
                                }
                                pattern.Add(n);
                            }
                        }

                        pictureBox1.Image = temp;

                        for (int i = 0; i < t; i++)
                        {
                            network.AddPattern(pattern);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            network.Run(initial);

            List<Neuron> res = network.Neurons;
            Bitmap temp = new Bitmap(k, k);

            int midColor = Math.Abs((int)(Color.Black.ToArgb() / 2));

            int i = 0;
            int j = 0;

            foreach (Neuron n in res)
            {
                if (j >= k) { j = 0; i++; }
                if (n.State == NeuronStates.AlongField)
                {
                    temp.SetPixel(i, j, Color.White);
                }
                else
                {
                    temp.SetPixel(i, j, Color.Black);
                }
                j++;
            }

            pictureBox3.Image = temp;
        }


        private void compare_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Title = "Load Image";
                openFile.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; ; *.png";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    List<Neuron> initialState = new List<Neuron>(n);

                    Bitmap temp = new Bitmap(openFile.FileName);

                    int midColor = Math.Abs((int)(Color.Black.ToArgb() / 2));

                    for (int i = 0; i < temp.Width; i++)
                    {
                        for (int j = 0; j < temp.Height; j++)
                        {
                            Neuron n = new Neuron();
                            int p = Math.Abs(temp.GetPixel(i, j).ToArgb());
                            p = Math.Abs(temp.GetPixel(i, j).ToArgb());
                            if (p < midColor)
                            {
                                temp.SetPixel(i, j, Color.White);
                                n.State = NeuronStates.AlongField;
                            }
                            else
                            {
                                temp.SetPixel(i, j, Color.Black);
                                n.State = NeuronStates.AgainstField;
                            }
                            initialState.Add(n);
                        }
                    }
                    pictureBox2.Image = temp;
                    initial = initialState;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int xMouse = e.X;
            int yMouse = e.Y;

            label1.Text = "Image 1";
            label2.Text = "(" + xMouse.ToString() + "," + yMouse.ToString() + ")";

            Bitmap img = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(img, pictureBox1.ClientRectangle);
            Color pixel = img.GetPixel(xMouse, yMouse);
            label3.Text = "GRAY: " + pixel.R.ToString();
            img.Dispose();

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "...";
            label2.Text = "...";
            label3.Text = "...";
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int xMouse = e.X;
            int yMouse = e.Y;

            label1.Text = "Image 2";
            label2.Text = "(" + xMouse.ToString() + "," + yMouse.ToString() + ")";

            Bitmap img = new Bitmap(pictureBox2.ClientSize.Width, pictureBox2.Height);
            pictureBox1.DrawToBitmap(img, pictureBox2.ClientRectangle);
            Color pixel = img.GetPixel(xMouse, yMouse);
            label3.Text = "GRAY: " + pixel.R.ToString();
            img.Dispose();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "...";
            label2.Text = "...";
            label3.Text = "...";
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            int xMouse = e.X;
            int yMouse = e.Y;

            label1.Text = "Result Image";
            label2.Text = "(" + xMouse.ToString() + "," + yMouse.ToString() + ")";

            Bitmap img = new Bitmap(pictureBox3.ClientSize.Width, pictureBox3.Height);
            pictureBox1.DrawToBitmap(img, pictureBox3.ClientRectangle);
            Color pixel = img.GetPixel(xMouse, yMouse);
            label3.Text = "GRAY: " + pixel.R.ToString();
            img.Dispose();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "...";
            label2.Text = "...";
            label3.Text = "...";
        }
    }
}