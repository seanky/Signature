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
    public partial class Form1 : Form
    {
        NeuralNetwork network;
        List<Neuron> initial;

        int n = 2500;
        int k = 50;
        int th = 90;

        public Form1()
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
                    Bitmap temp = new Bitmap(openFile.FileName);
                    List<Neuron> pattern = new List<Neuron>(n);

                    int midColor = Math.Abs((int)(Color.Black.ToArgb() / 2));

                    for (int i = 0; i < temp.Width; i++)
                    {
                        for(int j = 0; j < temp.Height; j++)
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
                    network.AddPattern(pattern);
                }
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            network.Run(initial);

            List<Neuron> res = network.Neurons;
            Bitmap temp = new Bitmap(k,k);

            int midColor = Math.Abs((int)(Color.Black.ToArgb() / 2));

            int i = 0;
            int j = 0;

            foreach(Neuron n in res)
            {
                if(j >= k) { j = 0; i++; }
                if(n.State == NeuronStates.AlongField)
                {
                    temp.SetPixel(i, j, Color.White);
                } else
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
    }
}
