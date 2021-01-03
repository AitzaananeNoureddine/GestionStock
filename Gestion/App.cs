using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Gestion
{
    public partial class App : Form
    {
        public class Commande_alt
        {
            public int id;
            public string nom_produit, nom_fourn;
            public Nullable<int> quant;
            public DateTime Date_commande;
            public Nullable<DateTime> Date_livraison;
            public Commande_alt(int id, string nom_produit, string nom_fourn, Nullable<int> quant, DateTime Date_commande, Nullable<DateTime> Date_livraison)
            {
                this.id = id;
                this.nom_produit = nom_produit;
                this.nom_fourn = nom_fourn;
                this.quant = quant;
                this.Date_commande = Date_commande;
                this.Date_livraison = Date_livraison;
            }

            public override string ToString()
            {
                return id + "|" + nom_produit + "|" + nom_fourn + "|" + quant + "|" + Date_commande + "|" + Date_livraison;
            }
        }

        LinqToProjectDBDataContext ProjectDB = new LinqToProjectDBDataContext();
        public App()
        {
            InitializeComponent();
            MainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            GestionProduitsPanel.BackgroundImageLayout = ImageLayout.Stretch;
            GestionFoursPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ListeProdPane.BackgroundImageLayout = ImageLayout.Stretch;
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
        OpenFileDialog op = new OpenFileDialog();
        DialogResult dr = new DialogResult();
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            dr = DialogResult.No;
            if(op.ShowDialog() == DialogResult.OK)
            {
                op.Filter = "Les fichiers (*.jpg, *.jepg, *.png, *.gif, *.bmp) | *.jpg; *.jepg; *.png; *.gif; *.bmp";
                op.Title = "Choisir une image";
                dr = DialogResult.OK;
                pictureBox1.Image = Image.FromFile(op.FileName);
            }
        }

        private void TabBordB3_Click(object sender, EventArgs e)
        {
            AjProdPanel.Hide();
            MainPanel.Show();
        }

        private void GobackB_Click(object sender, EventArgs e)
        {
            NomProd.Text="";
            PrixProd.Text="";
            StatusProd.Text="Status";
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
            ProduitAChercher.Text = "";
            ListeProdPane.Hide();
            GestionProduitsPanel.Show();
        }

        private void ListeProdB_Click(object sender, EventArgs e)
        {
            GestionProduitsPanel.Hide();
            ListeProdPane.Show();
            ////// initializer le tableau
            SearchProdB_Click(null, null);
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
            SearchProdDestB_Click(null, null);
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
            SearchFournB_Click(null, null);
        }

        private void listeCommandesPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            ListeCommandesPanel.Hide();
            MainPanel.Show();

        }

        private void guna2ImageButton4_Click_1(object sender, EventArgs e)
        {
            ListeCommandesPanel.Hide();
            GestionFoursPanel.Show();
        }

        private void CommandesB_Click(object sender, EventArgs e)
        {
            GestionFoursPanel.Hide();
            ListeCommandesPanel.Show();
            /////// remplir le combobox //////
            List<string> list = new List<string>();
            var Q = from f in ProjectDB.Fournisseurs
                    select f.Nom;
            foreach (string s in Q) list.Add(s);
            ComboFourns.DataSource = list;
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            ListeCommandesPanel.Hide();
            MainPanel.Show();
        }

        private void guna2ImageButton9_Click(object sender, EventArgs e)
        {
            ListeCommandesPanel.Hide();
            GestionFoursPanel.Show();
        }

        private void ListeFournTab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchFournB_Click(object sender, EventArgs e)
        {
            string fournisseur = FournAChercher.Text;
            var Query = from f in ProjectDB.Fournisseurs
                        where f.Nom.Contains(fournisseur)
                        select f;
            List<Fournisseur> selected = new List<Fournisseur>();
            foreach (var f in Query) selected.Add(f);
            ListeFournTab.DataSource = selected;

        }

        private void FournAChercher_TextChanged(object sender, EventArgs e)
        {
            this.SearchFournB_Click(null, null);
        }

        private void SearchProdB_Click(object sender, EventArgs e)
        {
            string produit = ProduitAChercher.Text;
            var Query = from p in ProjectDB.Produits
                        where p.Nom.Contains(produit)
                        select p;
            List<Produit> selected = new List<Produit>();
            foreach (var p in Query) selected.Add(p);
            ProdTab.DataSource = selected;
        }
        private void ProduitAChercher_TextChanged(object sender, EventArgs e)
        {
            this.SearchProdB_Click(null, null);
        }

        private void ComboFourns_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fournisseur = ComboFourns.SelectedItem.ToString();
            var Query = from c in ProjectDB.Commandes
                        join f in ProjectDB.Fournisseurs on c.Fournisseur equals f.Id
                        join p in ProjectDB.Produits on c.Produit equals p.Id
                        where f.Nom.Equals(fournisseur)
                        select new
                        {
                            Id = c.Id,
                            Produit = p.Nom,
                            Fournisseur = f.Nom,
                            Quantité = c.Quant,
                            Date_commande = c.Date_commande,
                            Date_livraison = c.Date_livraison,
                        };
            List<Commande_alt> selected = new List<Commande_alt>();
            foreach (var c in Query) selected.Add(new Commande_alt(c.Id, c.Produit, c.Fournisseur, c.Quantité, c.Date_commande, c.Date_livraison));
            CommandesList.DataSource = selected;
        }

        private void ProdAchercher_TextChanged(object sender, EventArgs e)
        {
            SearchProdDestB_Click(null, null);
        }

        private void SearchProdDestB_Click(object sender, EventArgs e)
        {
            string produit = ProdAchercher.Text;
            var Query = from p in ProjectDB.Produits
                        where p.Status.Equals("non disponible")
                        where p.Nom.Contains(produit)
                        select p;
            List<Produit> selected = new List<Produit>();
            foreach (var p in Query) selected.Add(p);
            ProdDestTab.DataSource = selected;
        }
        private void AjProdform_Click(object sender, EventArgs e)
        {
          
            Produit pr = new Produit();
            pr.Nom = NomProd.Text;
            pr.Prix = Convert.ToInt32(PrixProd.Text);
            pr.Date_exp = ExpirProd.Value;
            pr.Status= StatusProd.Text;
         

            ProjectDB.Produits.InsertOnSubmit(pr);
            ProjectDB.SubmitChanges();
        }

        private void AnnulerProd_Click(object sender, EventArgs e)
        {
            NomProd.Text = "";
            PrixProd.Text = "";
            StatusProd.Text = "Status";
        }
    }
}
