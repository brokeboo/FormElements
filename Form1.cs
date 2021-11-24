using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElements
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pb;
        CheckBox cb1, cb2;
        RadioButton rb;
        bool t = false;
        public Form1()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";
            Image img = new Bitmap(@"..\..\Images\space.jpg");
            this.BackgroundImage = img;
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));
            tn.Nodes.Add(new TreeNode("PictureBox"));

            tn.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            tn.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstikast-TextBox"));
            tn.Nodes.Add(new TreeNode("Kaart-ToControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            //nupp
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(250, 350);
            btn.Height = 30;
            btn.Width = 100;
            btn.Click += Btn_Click;
            lbl = new Label();
            lbl.Text = "Elementide loomine #c abil";
            lbl.Size = new Size(600, 30);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseHover += Lbl_MouseLeave;
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);

            pb = new PictureBox();
            pb.Size = new Size(600, 600);
            pb.Location = new Point(150, 60);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = Image.FromFile(@"..\..\Images\unnamed.jpg");
            pb.DoubleClick += Pb_DoubleClick;

            
        }

        private void Pb_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.BackColor = Color.FromArgb(200, 10, 20);
        }
        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.BackColor = Color.Transparent;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                this.Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "PictureBox")
            {
                this.Controls.Add(pb);
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {
                //checkbox
                cb1 = new CheckBox();
                cb1.Location = new Point(300, 300);
                cb1.BackColor = Color.Transparent;
                cb1.Size = new Size(400, 200);
                cb1.Text = "click to make the text larger";

                cb1.CheckedChanged += Cb1_CheckedChanged;
                cb2 = new CheckBox();
                cb2.Size = new Size(100, 100);
                cb2.Image = Image.FromFile(@"..\..\Images\unnamed.jpg");
                cb2.CheckedChanged += Cb2_CheckedChanged;
                cb2.Location = new Point(200, 200);
                this.Controls.Add(cb1);
                this.Controls.Add(cb2);
            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                rb = new RadioButton();
                rb.Location = new Point(300, 300);
                rb.Size = new Size(400, 200);
                rb.CheckedChanged += Rb_CheckedChanged;
                this.Controls.Add(rb);
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad inputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    String text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekstikastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);

                    }

                }

                else
                {
                    MessageBox.Show("=(");
                }
                
            }
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Cb1_CheckedChanged(object sender, EventArgs e)
        {
            if(cb1.Checked)
            {
                cb1.Font = new Font("Bradley Hand ITC", 40);
            }
        }

        private void Cb2_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                this.Size = new Size(100, 100);
                t = false;
            }
            else
            {
                this.Size = new Size(700, 500);
                t = true;
            }
        }

    }
}
