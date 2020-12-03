using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private void statistique_Click(object sender, EventArgs e)
        {

        }

        private void produit_button_Click(object sender, EventArgs e)
        {
        }

        private void Statistique_Label_Click(object sender, EventArgs e)
        {

        }

        private void TableauBord_Load(object sender, EventArgs e)
        {

        }

        private void GestionProduitsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GestionProduitsB_Click(object sender, EventArgs e)
        {
            MainPanel.Hide();
            GestionProduitsPanel.Show();
        }

        private void GestionFournisseursB_Click(object sender, EventArgs e)
        {
            MainPanel.Hide();
            GestionFoursPanel.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            GestionProduitsPanel.Hide();
            MainPanel.Show();
        }

        private void TabBordB2_Click(object sender, EventArgs e)
        {
            GestionFoursPanel.Hide();
            MainPanel.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void TabBordB3_Click(object sender, EventArgs e)
        {
            AjProdPanel.Hide();
            MainPanel.Show();
        }

        private void GobackB_Click(object sender, EventArgs e)
        {
            AjProdPanel.Hide();
            GestionProduitsPanel.Show();
        }

        private void AjProdB_Click(object sender, EventArgs e)
        {
            GestionProduitsPanel.Hide();
            AjProdPanel.Show();
        }

        private void TabBordB4_Click(object sender, EventArgs e)
        {
            AjFournPanel.Hide();
            MainPanel.Show();
        }

        private void AjFournB_Click(object sender, EventArgs e)
        {
            GestionFoursPanel.Hide();
            AjFournPanel.Show();
        }

        private void GobackB2_Click(object sender, EventArgs e)
        {
            AjFournPanel.Hide();
            GestionFoursPanel.Show();
        }

        private void ListeProd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void TabBordB5_Click(object sender, EventArgs e)
        {
            ListeProdPane.Hide();
            MainPanel.Show();
        }

        private void GobackB3_Click(object sender, EventArgs e)
        {
            ListeProdPane.Hide();
            GestionProduitsPanel.Show();
        }

        private void ListeProdB_Click(object sender, EventArgs e)
        {
            GestionProduitsPanel.Hide();
            ListeProdPane.Show();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            ProDestPane.Hide();
            GestionProduitsPanel.Show();
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TabBordB6_Click(object sender, EventArgs e)
        {
            ProDestPane.Hide();
            MainPanel.Show();
        }

        private void ProdDestB_Click(object sender, EventArgs e)
        {
            GestionProduitsPanel.Hide();
            ProDestPane.Show();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TabBordB7_Click(object sender, EventArgs e)
        {
            ListeFournsPanel.Hide();
            MainPanel.Show();
        }

        private void GobackB6_Click(object sender, EventArgs e)
        {
            ListeFournsPanel.Hide();
            GestionFoursPanel.Show();
        }

        private void ListeFournB_Click(object sender, EventArgs e)
        {
            GestionFoursPanel.Hide();
            ListeFournsPanel.Show();
        }
    }
}
