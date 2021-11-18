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
        public Form1()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elementidega";
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

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
            pb = new PictureBox();
            pb.Size = new Size(50, 50);
            pb.Location = new Point(150, 60);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = Image.FromFile(@"..\..\Images\unnamed.jpg");
            pb.DoubleClick += Pb_DoubleClick;
        }

        private void Pb_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            if (e.Node.Text=="Nupp")
            {
                this.Controls.Add(btn);
            }
            else if(e.Node.Text=="Silt")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "PictureBox")
            {
                this.Controls.Add(pb);
            }
        }
    }
}
