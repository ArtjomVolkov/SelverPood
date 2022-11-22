using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pood
{
    public partial class Form2_2_ : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\pood2\pooas\poods_new-main\Appdata\Tooded_DataBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;//adapter
        private NumericUpDown Kogus_txt;
        private NumericUpDown Hind_txt;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private PictureBox Toode_Pb;
        private System.Windows.Forms.ComboBox ComboBox;
        private Label Hind_lbl;
        private Label Kogus_lbl;
        private Label Toode_Lbl;
        private System.Windows.Forms.TextBox Toode_txt;
        private DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private Label label1;
        private PictureBox pictureBox2;
        OpenFileDialog openfiledialog1;
        public Form2_2_()
        {
            InitializeComponent();

            openfiledialog1 = new OpenFileDialog //laiendus, mille abil saab fotosid üles laadida
            {
                RestoreDirectory = true,
                Title = "Sirvige tekstifaile",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
            };
            Naita_Andmed();
            Naita_Andmed1();
        }
        public void Kustuta_andmed()
        {
            Toode_txt.Text = "";
            Hind_txt.Text = "";
            Kogus_txt.Text = "";
        }
        private void Lisa_kat_btn_Click(object sender, EventArgs e)
        {

        }
        public void Naita_Kat()
        {
            connect.Open();
            adapter_kat = new SqlDataAdapter("SELECT Kategooria_nimetus FROM Kategooria", connect);
            DataTable dt_kat = new DataTable();
            adapter_kat.Fill(dt_kat);
            foreach (DataRow nimetus in dt_kat.Rows)
            {
                ComboBox.Items.Add(nimetus["Kategooria_nimetus"]);
            }
            connect.Close();
        }


        private void Lisa_button_Click(object sender, EventArgs e)
        {

        }

        private void Kustuta_button_Click(object sender, EventArgs e)
        {

        }
        int Id;
        private void btn_kustuta_kat_Click(object sender, EventArgs e)
        {

        }

        SaveFileDialog save;
        Random rand = new Random();
        private void PictureAdd_button_Click(object sender, EventArgs e)
        {

        }

        private void Laienda_button_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void uuenda_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2_2_));
            this.Kogus_txt = new System.Windows.Forms.NumericUpDown();
            this.Hind_txt = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Toode_Pb = new System.Windows.Forms.PictureBox();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.Hind_lbl = new System.Windows.Forms.Label();
            this.Kogus_lbl = new System.Windows.Forms.Label();
            this.Toode_Lbl = new System.Windows.Forms.Label();
            this.Toode_txt = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Kogus_txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hind_txt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toode_Pb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Kogus_txt
            // 
            this.Kogus_txt.Location = new System.Drawing.Point(93, 96);
            this.Kogus_txt.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Kogus_txt.Name = "Kogus_txt";
            this.Kogus_txt.Size = new System.Drawing.Size(154, 20);
            this.Kogus_txt.TabIndex = 37;
            // 
            // Hind_txt
            // 
            this.Hind_txt.Cursor = System.Windows.Forms.Cursors.Default;
            this.Hind_txt.Location = new System.Drawing.Point(93, 129);
            this.Hind_txt.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Hind_txt.Name = "Hind_txt";
            this.Hind_txt.Size = new System.Drawing.Size(154, 20);
            this.Hind_txt.TabIndex = 36;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.No;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(769, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(10, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(418, 164);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick_1);
            // 
            // Toode_Pb
            // 
            this.Toode_Pb.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Toode_Pb.Cursor = System.Windows.Forms.Cursors.No;
            this.Toode_Pb.Location = new System.Drawing.Point(253, 65);
            this.Toode_Pb.Name = "Toode_Pb";
            this.Toode_Pb.Size = new System.Drawing.Size(165, 124);
            this.Toode_Pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Toode_Pb.TabIndex = 26;
            this.Toode_Pb.TabStop = false;
            // 
            // ComboBox
            // 
            this.ComboBox.Location = new System.Drawing.Point(0, 0);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(121, 21);
            this.ComboBox.TabIndex = 42;
            // 
            // Hind_lbl
            // 
            this.Hind_lbl.AutoSize = true;
            this.Hind_lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Hind_lbl.Location = new System.Drawing.Point(58, 131);
            this.Hind_lbl.Name = "Hind_lbl";
            this.Hind_lbl.Size = new System.Drawing.Size(29, 13);
            this.Hind_lbl.TabIndex = 23;
            this.Hind_lbl.Text = "Hind";
            // 
            // Kogus_lbl
            // 
            this.Kogus_lbl.AutoSize = true;
            this.Kogus_lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Kogus_lbl.Location = new System.Drawing.Point(50, 98);
            this.Kogus_lbl.Name = "Kogus_lbl";
            this.Kogus_lbl.Size = new System.Drawing.Size(37, 13);
            this.Kogus_lbl.TabIndex = 22;
            this.Kogus_lbl.Text = "Kogus";
            // 
            // Toode_Lbl
            // 
            this.Toode_Lbl.AutoSize = true;
            this.Toode_Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Toode_Lbl.Location = new System.Drawing.Point(10, 62);
            this.Toode_Lbl.Name = "Toode_Lbl";
            this.Toode_Lbl.Size = new System.Drawing.Size(77, 13);
            this.Toode_Lbl.TabIndex = 21;
            this.Toode_Lbl.Text = "Toode nimetus";
            // 
            // Toode_txt
            // 
            this.Toode_txt.Location = new System.Drawing.Point(93, 62);
            this.Toode_txt.Name = "Toode_txt";
            this.Toode_txt.Size = new System.Drawing.Size(154, 20);
            this.Toode_txt.TabIndex = 20;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView2.Location = new System.Drawing.Point(434, 65);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(316, 359);
            this.dataGridView2.TabIndex = 38;
            this.dataGridView2.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_RowHeaderMouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(244, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 59);
            this.button1.TabIndex = 39;
            this.button1.Text = "Lisa Ostukorv";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(127, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 59);
            this.button2.TabIndex = 40;
            this.button2.Text = "Tsekk";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "tsekk";
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(346, 195);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 59);
            this.button3.TabIndex = 41;
            this.button3.Text = "Kustuta Ostukorv";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(10, 195);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 59);
            this.button4.TabIndex = 43;
            this.button4.Text = "Selver E-Pood";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(434, 65);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(316, 355);
            this.listBox1.TabIndex = 44;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(85, 163);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 26);
            this.textBox2.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(10, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Total : ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(8, 129);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Form2_2_
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(758, 428);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.Kogus_txt);
            this.Controls.Add(this.Hind_txt);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Toode_Pb);
            this.Controls.Add(this.ComboBox);
            this.Controls.Add(this.Hind_lbl);
            this.Controls.Add(this.Kogus_lbl);
            this.Controls.Add(this.Toode_Lbl);
            this.Controls.Add(this.Toode_txt);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form2_2_";
            ((System.ComponentModel.ISupportInitialize)(this.Kogus_txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hind_txt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toode_Pb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Lisa_button_Click_1(object sender, EventArgs e)
        {
            if (Toode_txt.Text.Trim() != String.Empty && Kogus_txt.Text.Trim() != String.Empty && Hind_txt.Text.Trim() != String.Empty && ComboBox.SelectedItem != null)
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO ToodeTable (ToodeNimetus,Kogus,Hind,Pilt) VALUES (@toode,@kogus,@hind,@pilt)", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text); //format andmebaasis ja vormis võrdsed.
                    cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + ".jpg");//format.
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Kustuta_andmed();
                    Naita_Andmed();

                }
                catch (Exception)
                {

                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }

        private void Kustuta_button_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM ToodeTable WHERE Id = @rowID";

            using (SqlCommand deleteRecord = new SqlCommand(sql, connect))
            {
                connect.Open();
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                int rowID = Convert.ToInt32(dataGridView1[0, selectedIndex].Value);

                deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
                deleteRecord.ExecuteNonQuery();

                dataGridView1.Rows.RemoveAt(selectedIndex);
                connect.Close();
            }
        }

        private void PictureAdd_button_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            open.InitialDirectory = Path.GetFullPath(@"C:\Users\opilane\Downloads");
            if (open.ShowDialog() == DialogResult.OK)
            {
                save = new SaveFileDialog();
                save.FileName = Toode_txt.Text + ".jpg";
                save.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                save.InitialDirectory = Path.GetFullPath(@"C:\Users\opilane\source\repos\Volkov TARpv21\Pood1\Images");

                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName);
                    save.RestoreDirectory = true;
                    Toode_Pb.Image = Image.FromFile(save.FileName);
                }

            }
        }

        private void Laienda_button_Click_1(object sender, EventArgs e)
        {
            if (Toode_Pb.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Salvesta pildi...";
                savedialog.InitialDirectory = Path.GetFullPath(@"C:\\Users\\opilane\\source\\repos\\Volkov TARpv21\\Pood1\\Images");
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.jpg)|*.jpg";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Toode_Pb.Image.Save(savedialog.FileName, ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Pilt ei ole salvestanud!", "Viga",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        Bitmap bmp;
        Random rnd = new Random();
        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private double result = 0f;
        private double result1 = 0f;
        private int offset;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Times New Roman", 12);

            graphics.DrawString("Welcome to selver shop\n", new Font("Times New Roman", 18), new SolidBrush(Color.Black), 250, 30);

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                graphics.DrawString(listBox1.Items[i].ToString(), font, new SolidBrush(Color.Black), 60, 100 + offset);
                offset += 25;
            }

            /*Bitmap bmp = new Bitmap(dataGridView2.Width, dataGridView2.Height);
            dataGridView2.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView2.Width, dataGridView2.Height));
            e.Graphics.DrawImage(bmp, 60, 100);*/

            offset += 20;
            graphics.DrawString("Total summa".PadRight(30) + string.Format("{0:f2} $", result), font, new SolidBrush(Color.Black), 400, 200 + offset);
            offset += 40;
            var now = DateTime.Now;
            graphics.DrawString("Date of purchase : " + now.ToString("dd-MM-yyyy"), font, new SolidBrush(Color.Black), 500, 400 + offset);
            Image selver = Image.FromFile("../../Images/about.png");
            graphics.DrawImage(selver, 100, 350 + offset);
            offset += 20;
        }
        private void Result()
        {
            result += Convert.ToInt32(Kogus_txt.Text.ToString()) * Convert.ToInt32(Hind_txt.Text.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Toodenimetus: " + Toode_txt.Text + " " + "Kogus:" + Kogus_txt.Text + " " + "Hind:" + Hind_txt.Text + "\n");
            /*cmd = new SqlCommand("DELETE FROM ToodeTable WHERE Kogus=@kogus", connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
            cmd.ExecuteNonQuery();
            connect.Close();*/
            Result();
            textBox2.Text = string.Format("{0:f2} $", result);
            Kustuta_andmed();
            Naita_Andmed();
        }
        /*private void button1_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text.Trim() != String.Empty && Kogus_txt.Text.Trim() != String.Empty && Hind_txt.Text.Trim() != String.Empty )
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO Kassa (ToodeNimetus1,Kogus1,Hind1) VALUES (@toode1,@kogus1,@hind1)", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@toode1", Toode_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus1", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind1", Hind_txt.Text);//format andmebaasis ja vormis võrdsed.
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Result();
                    Kustuta_andmed();
                    Naita_Andmed1();


                }
                catch (Exception)
                {

                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }*/

        public void Naita_Andmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM ToodeTable", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.DataSource = dt_toode;


            Toode_Pb.Image = Image.FromFile("../../Images/about.png");

            connect.Close();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            Naita_Kat();


        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;//kui andmed puuduvad reas
            Toode_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Toode_Pb.Image = Image.FromFile(@"..\..\Images\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
        }


        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            result = 0;
            textBox2.Text = string.Format("{0:f2} $", result);
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;//kui andmed puuduvad reas
            Toode_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.selver.ee/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 day = new Form2();
            day.Show();
        }

        public void Naita_Andmed1()
        {
            connect.Open();
            DataTable dt_toode1 = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM Kassa", connect);
            adapter_toode.Fill(dt_toode1);
            dataGridView2.DataSource = dt_toode1;
            connect.Close();
            dataGridView2.Columns[0].Visible = false;


        }
    }
}
