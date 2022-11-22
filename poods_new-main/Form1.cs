using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pood
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\pood2\pooas\poods_new-main\Appdata\Tooded_DataBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;//adapter
        OpenFileDialog openfiledialog1;
        public Form1()
        {
            InitializeComponent();
            openfiledialog1 = new OpenFileDialog //laiendus, mille abil saab fotosid üles laadida
            {
                RestoreDirectory = true,
                Title = "Sirvige tekstifaile",
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
            };
            Naita_Andmed();
            Naita_Andmedd();
        }
        public void Kustuta_andmed()
        {
            Toode_txt.Text = "";
            Hind_txt.Text = "";
            Kogus_txt.Text = "";
            ComboBox.Items.Clear();
        }
        public void Kustuta_andmedd()
        {
            Toode_txt.Text = "";
            Hind_txt.Text = "";
            Kogus_txt.Text = "";
            ComboBox.Items.Clear();
        }
        private void Lisa_kat_btn_Click(object sender, EventArgs e)
        {
            connect.Open();
            cmd = new SqlCommand("INSERT INTO Kategooria (Kategooria_nimetus) VALUES (@kat)",connect);
            cmd.Parameters.AddWithValue("@kat", ComboBox.Text);
            cmd.ExecuteNonQuery();
            connect.Close();
            Kustuta_andmed();
            Naita_Kat();
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
            if (Toode_txt.Text.Trim() != String.Empty && Kogus_txt.Text.Trim() != String.Empty && Hind_txt.Text.Trim() != String.Empty && ComboBox.SelectedItem != null)
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO ToodeTable (ToodeNimetus,Kogus,Hind,Pilt,KategooriaID) VALUES (@toode,@kogus,@hind,@pilt,@kate)", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text); //format andmebaasis ja vormis võrdsed.
                    cmd.Parameters.AddWithValue("@pilt", Toode_txt.Text + ".jpg");//format.
                    cmd.Parameters.AddWithValue("@kate", ComboBox.SelectedIndex + 1); // ID andmebaasist võtta.
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

        private void Kustuta_button_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM ToodeTable WHERE Id = @rowID";

            using (SqlCommand deleteRecord = new SqlCommand(sql,connect))
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
        int Id;
        private void btn_kustuta_kat_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT Id FROM Kategooria WHERE Kategooria_nimetus=@kat",connect);
            connect.Open();
            cmd.Parameters.AddWithValue("@kat", ComboBox.Text);
            cmd.ExecuteNonQuery();
            Id = Convert.ToInt32(cmd.ExecuteScalar());
            connect.Close();
            if (Id != 0)
            {
                cmd = new SqlCommand("DELETE FROM Kategooria WHERE Id = @id", connect);
                connect.Open();
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();
                connect.Close();
                Kustuta_andmed();
                Naita_Andmed();
                MessageBox.Show("Andmed Kategooria on kustutatud!");
            }
            else
            {
                MessageBox.Show("Vale!");
            }
        }

        SaveFileDialog save;
        Random rand = new Random();
        private void PictureAdd_button_Click(object sender, EventArgs e)
        {
            /*openfiledialog1.InitialDirectory = @"C:\Users\opilane.TTHK\Pictures";
            if(openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openfiledialog1.FileName);
                Toode_Pb.Load(openfiledialog1.FileName);
                Bitmap finalImg = new Bitmap(Toode_Pb.Image, Toode_Pb.Width,Toode_Pb.Height);
                Toode_Pb.Image = finalImg;
                Toode_Pb.Show();
                string destinationFile;
                try
                {
                    destinationFile = @"..\..\pictures\" + Toode_txt.Text + ext;
                    File.Copy(openfiledialog1.FileName, destinationFile);
                }
                catch (Exception)
                {
                    destinationFile = @"..\..\pictures\" + Toode_txt.Text + ext;
                    File.Copy(openfiledialog1.FileName, destinationFile);
                }
            }*/
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

        private void Laienda_button_Click(object sender, EventArgs e)
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;//kui andmed puuduvad reas
            Toode_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Kogus_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Hind_txt.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Toode_Pb.Image = Image.FromFile(@"..\..\Images\" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            string v = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            ComboBox.SelectedIndex = Int32.Parse(v) - 1;
        }

        private void uuenda_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text != "" && Kogus_txt.Text != "" && Hind_txt.Text != "" && ComboBox.Text !=null)
            {
                    cmd = new SqlCommand("UPDATE ToodeTable SET ToodeNimetus=@toode,Kogus=@kogus,Hind=@hind,Pilt=@pilt WHERE Id=@id", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@id", Id);
                    cmd.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    cmd.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind", Hind_txt.Text.Replace(",",".")); //format andmebaasis ja vormis võrdsed.
                    string file_pilt = Toode_txt.Text + ".jpg";
                    cmd.Parameters.AddWithValue("@pilt", file_pilt);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Kustuta_andmed();
                    Naita_Andmed();
                    MessageBox.Show("Andmed uuendatud");
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }

        public void Naita_Andmedd()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM Bonus", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView2.DataSource = dt_toode;
            dataGridView2.Columns[0].Visible = false;

            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Bonus_txt.Text.Trim() != String.Empty && Bonus_hind.Text.Trim() != String.Empty)
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO Bonus (Bonus,Hind) VALUES (@bonus1,@hind1)", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@bonus1", Bonus_txt.Text);
                    cmd.Parameters.AddWithValue("@hind1", Bonus_hind.Text); //format andmebaasis ja vormis võrdsed.
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Kustuta_andmedd();
                    Naita_Andmedd();

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bonus_txt.Text != "" && Bonus_hind.Text != "" )
            {
                cmd = new SqlCommand("UPDATE Bonus SET Bonus=@bonus1,Hind=@hind1 WHERE Id=@id", connect);
                connect.Open();
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@bonus1", Bonus_txt.Text);
                cmd.Parameters.AddWithValue("@hind1", Bonus_hind.Text.Replace(",", ".")); //format andmebaasis ja vormis võrdsed.
                cmd.ExecuteNonQuery();
                connect.Close();
                Kustuta_andmedd();
                Naita_Andmedd();
                MessageBox.Show("Andmed uuendatud");
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
                return;

            string sql1 = "DELETE FROM Bonus WHERE Id = @rowID1";

            using (SqlCommand deleteRecord1 = new SqlCommand(sql1, connect))
            {
                connect.Open();
                int selectedIndex1 = dataGridView2.SelectedRows[0].Index;
                int rowID1 = Convert.ToInt32(dataGridView2[0, selectedIndex1].Value);

                deleteRecord1.Parameters.Add("@rowID1", SqlDbType.Int).Value = rowID1;
                deleteRecord1.ExecuteNonQuery();

                dataGridView2.Rows.RemoveAt(selectedIndex1);
                connect.Close();
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView2.Rows[e.RowIndex].Cells[0].Value;//kui andmed puuduvad reas
            Bonus_txt.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            Bonus_hind.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(); //avab pea form
            admin.Show();
            Hide();
        }

        public void Naita_Andmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM ToodeTable", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.DataSource = dt_toode;


            Toode_Pb.Image = Image.FromFile("../../Images/about.png");

            connect.Close();

            Naita_Kat();

            
        }
    }
}