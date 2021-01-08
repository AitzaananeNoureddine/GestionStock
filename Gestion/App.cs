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
            public int Id;
            public string Produit, Fournisseur;
            public Nullable<int> Quantité;
            public DateTime Date_commande;
            public Nullable<DateTime> Date_livraison;
            public Commande_alt(int id, string nom_produit, string nom_fourn, Nullable<int> quant, DateTime Date_commande, Nullable<DateTime> Date_livraison)
            {
                this.Id = id;
                this.Produit = nom_produit;
                this.Fournisseur = nom_fourn;
                this.Quantité = quant;
                this.Date_commande = Date_commande;
                this.Date_livraison = Date_livraison;
            }

            public override string ToString()
            {
                return Id + "|" + Produit + "|" + Fournisseur + "|" + Quantité + "|" + Date_commande + "|" + Date_livraison;
            }
        }

        readonly LinqToProjectDBDataContext ProjectDB = new LinqToProjectDBDataContext();
        string Image_id;
        Panel Hidden_pane;
        readonly string ProjectPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
        public App()
        {
            InitializeComponent();
            MainPanel.BackgroundImageLayout = ImageLayout.Stretch;
            GestionProduitsPanel.BackgroundImageLayout = ImageLayout.Stretch;
            GestionFoursPanel.BackgroundImageLayout = ImageLayout.Stretch;
            ListeProdPane.BackgroundImageLayout = ImageLayout.Stretch;
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
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Les fichiers (*.jpg, *.jepg, *.png, *.gif, *.bmp) | *.jpg; *.jepg; *.png; *.gif; *.bmp";
            op.Title = "Choisir une image";
            if (op.ShowDialog() == DialogResult.OK)
            {
                File.Copy(op.FileName, ProjectPath + @"\Img\" + op.SafeFileName, true);
                Image_id = op.SafeFileName;
                image_id_box.Text = Image_id;
                image_id_box.Visible = true;
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
            list.Sort();
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
        private void SearchFournB_Click(object sender, EventArgs e)
        {
            ListeFournTab.Visible = true;
            string fournisseur = FournAChercher.Text;
            var Query = from f in ProjectDB.Fournisseurs
                        where f.Nom.Contains(fournisseur)
                        select f;
            List<Fournisseur> selected = new List<Fournisseur>();
            foreach (var f in Query) selected.Add(f);
            if (selected.Count != 0)
            {
                ListeFournTab.DataSource = selected;
                ModDelColumns(ListeFournTab);
                ListeFournTab.Columns["Modifier"].Width = 70;
                ListeFournTab.Columns["Supprimer"].Width = 70;
                ListeFournTab.Columns["Modifier"].DefaultCellStyle.Padding = new Padding(5);
                ListeFournTab.Columns["Supprimer"].DefaultCellStyle.Padding = new Padding(5);
                for (int i=0;i<selected.Count;i++) ListeFournTab.Rows[i].Height = 40;
            }
            else ListeFournTab.Visible = false;

        }
        private void FournAChercher_TextChanged(object sender, EventArgs e)
        {
            this.SearchFournB_Click(null, null);
        }
        private void SearchProdB_Click(object sender, EventArgs e)
        {
            ProdTab.Visible = true;
            string produit = ProduitAChercher.Text;
            var Query = from p in ProjectDB.Produits
                        where p.Nom.Contains(produit)
                        select p;
            List<Produit> selected = new List<Produit>();
            foreach (var p in Query) selected.Add(p);
            ProdTab.DataSource = selected;
            ProdTab.Columns["Image"].Visible = false;
            if (selected.Count != 0)
            {
                LoadImages(ProdTab, selected.Count);
                ModDelColumns(ProdTab);
            }
            else ProdTab.Visible = false;
        }
        private void ModDelColumns(DataGridView DG)
        {
            //////////////////////
            DataGridViewButtonColumn btnColumn1 = new DataGridViewButtonColumn();
            btnColumn1.Name = "Modifier";
            btnColumn1.Text = "Mod";
            btnColumn1.UseColumnTextForButtonValue = true;
            btnColumn1.DefaultCellStyle.Padding = new Padding(30);
            btnColumn1.FlatStyle = FlatStyle.Flat;
            btnColumn1.DefaultCellStyle.ForeColor = Color.FromArgb(0, 182, 244);
            /*btnColumn1.DefaultCellStyle.BackColor = Color.White;*/
            if(!DG.Columns.Contains("Modifier")) DG.Columns.Add(btnColumn1);
            ///////////
            DataGridViewButtonColumn btnColumn2 = new DataGridViewButtonColumn();
            btnColumn2.Name = "Supprimer";
            btnColumn2.Text = "Supp";
            btnColumn2.UseColumnTextForButtonValue = true;
            btnColumn2.DefaultCellStyle.Padding = new Padding(30);
            btnColumn2.FlatStyle = FlatStyle.Flat;
            btnColumn2.DefaultCellStyle.ForeColor = Color.FromArgb(214, 40, 40);
            /*btnColumn2.DefaultCellStyle.BackColor = Color.White;*/
            if (!DG.Columns.Contains("Supprimer")) DG.Columns.Add(btnColumn2);
            //////////////////////
        }
        private void ProduitAChercher_TextChanged(object sender, EventArgs e)
        {
            this.SearchProdB_Click(null, null);
        }

        private void ComboFourns_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommandesList.Visible = true;
            CommandesList.Rows.Clear();
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
            foreach (var c in Query) selected.Add(new Commande_alt(c.Id,c.Produit,c.Fournisseur,c.Quantité,c.Date_commande,c.Date_livraison));
            if (selected.Count != 0)
            {
                for (int i = 0; i < selected.Count; i++)
                {
                    CommandesList.Rows.Add();
                    CommandesList.Rows[i].Cells["Id"].Value = selected[i].Id;
                    CommandesList.Rows[i].Cells["Produit"].Value = selected[i].Produit;
                    CommandesList.Rows[i].Cells["Fournisseur"].Value = selected[i].Fournisseur;
                    CommandesList.Rows[i].Cells["Quantité"].Value = selected[i].Quantité;
                    CommandesList.Rows[i].Cells["Date_commande"].Value = selected[i].Date_commande;
                    CommandesList.Rows[i].Cells["Date_livraison"].Value = selected[i].Date_livraison;
                }
            }
            else
            {
                CommandesList.Visible = false;
            }
        }

        private void ProdAchercher_TextChanged(object sender, EventArgs e)
        {
            SearchProdDestB_Click(null, null);
        }

        private void SearchProdDestB_Click(object sender, EventArgs e)
        {
            ProdDestTab.Visible = true;
            string produit = ProdAchercher.Text;
            DateTime now = DateTime.Now;
            var Query = from p in ProjectDB.Produits
                        where now.CompareTo(p.Date_exp.Value) > 0
                        where p.Nom.Contains(produit)
                        where p.Status.Equals("disponible")
                        select p;
            var Query2 = from v in ProjectDB.Ventes
                         join p in ProjectDB.Produits
                         on v.Produit equals p.Id
                         where p.Nom.Contains(produit)
                         select p;
            List<Produit> selected = new List<Produit>();
            foreach (var p in Query) selected.Add(p);
            foreach (var p in Query2) if (!selected.Contains(p)) selected.Add(p);
            ProdDestTab.DataSource = selected;
            ProdDestTab.Columns["Image"].Visible = false;
            if (selected.Count != 0)
            {
                LoadImages(ProdDestTab, selected.Count);
                ModDelColumns(ProdDestTab);
            }
            else ProdDestTab.Visible = false;
        }
        private void LoadImages(DataGridView dg,int count)
        {
            DataGridViewImageColumn img_column = new DataGridViewImageColumn();
            img_column.Name = "Img";
            img_column.HeaderText = "Image";
            img_column.ImageLayout = DataGridViewImageCellLayout.Stretch;
            if (!dg.Columns.Contains("Img"))
            {
                dg.Columns.Add(img_column);
                dg.Columns["Img"].DisplayIndex = 2;
            }
            System.Drawing.Image img=null;
            dg.Columns["Img"].Width = 130;
            for (int i = 0; i < count; i++)
            {
                try
                {
                    dg.Rows[i].Height = 100;
                    img = System.Drawing.Image.FromFile(ProjectPath + @"\Img\" + dg.Rows[i].Cells["Image"].Value);
                    dg.Rows[i].Cells["Img"].Value = img;
                } catch (FileNotFoundException)
                {
                    dg.Rows[i].Cells["Img"].Value = null;
                } catch (OutOfMemoryException e) 
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        private void AjProdform_Click(object sender, EventArgs e)
        {
            NomProd.Text = NomProd.Text.Trim();
            if (NomProd.Text!="" && ExpirProd.Text!="" && StatusProd.Text!="")
            {
                Produit pr = new Produit();
                pr.Nom = NomProd.Text;
                pr.Image = Image_id;
                try
                {
                    pr.Prix = Convert.ToInt32(PrixProd.Text);
                    if (DateTime.Now.CompareTo(ExpirProd.Value) > 0) throw new Exception();
                    else pr.Date_exp = ExpirProd.Value;
                    pr.Status = StatusProd.Text;
                    ProjectDB.Produits.InsertOnSubmit(pr);
                    ProjectDB.SubmitChanges();
                    MessageBox.Show("le produit a bien été enregisté");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Entrez un prix valide");
                }
                catch (Exception)
                {
                    MessageBox.Show("la date que vous avez saisie est non valide");
                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis");
            }
        }

        private void AnnulerProd_Click(object sender, EventArgs e)
        {
            NomProd.Text = "";
            PrixProd.Text = "";
            StatusProd.Text = "Status";
            image_id_box.Visible = false;
        }
        private void ProdTab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ModDelBackEnd(sender, e);
        }
        int _id;
        private void ModDelBackEnd(object sender , DataGridViewCellEventArgs e)
        {
            var _sender = (DataGridView)sender;
            int id=0;
            if (_sender.Rows[e.RowIndex].Cells["Id"]!=null) id = (int)_sender.Rows[e.RowIndex].Cells["Id"].Value;
            _id = id;
            if(_sender.Columns[e.ColumnIndex].Name == "Modifier")
            {
                if (_sender.Name.Equals("ProdTab") || _sender.Name.Equals("ProdDestTab"))
                {
                    if (_sender.Name.Equals("ProdTab"))
                    {
                        ListeProdPane.Hide();
                        Hidden_pane = ListeProdPane;
                    }
                    else if (_sender.Name.Equals("ProdDestTab"))
                    {
                        ProDestPane.Hide();
                        Hidden_pane = ProDestPane;
                    }
                    var Query = from p in ProjectDB.Produits
                                where p.Id.Equals(id)
                                select p;
                    Produit ToAlter = Query.First();
                    ProdNom.Text = ToAlter.Nom.Trim();
                    ProdPrix.Text = ToAlter.Prix.ToString();
                    ProdStatus.SelectedIndex = ProdStatus.FindString(ToAlter.Status.Trim());
                    ProdExpDate.Value = (DateTime)ToAlter.Date_exp;
                    ProdImageId.Text = ToAlter.Image;
                    ProdImageId.Visible = true;
                    ModProdPane.Show();
                }
                else if (_sender.Name.Equals("ListeFournTab"))
                {
                    ListeFournsPanel.Hide();
                    var Query = (from f in ProjectDB.Fournisseurs
                                 where f.Id.Equals(id)
                                 select f).First();
                    NomFourn.Text = Query.Nom.Trim();
                    AdresseFourn.Text = Query.Adresse.Trim();
                    ContactFourn.Text = Query.Contact.Trim();
                    ModFournPane.Show();
                }
            }
            else if (_sender.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                DialogResult dr = MessageBox.Show("Voulez vous vraiment supprimer l'element de la BD ?", "Supprimer", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    if (_sender.Name.Equals("ProdTab") || _sender.Name.Equals("ProdDestTab"))
                    {
                        var Query = (from p in ProjectDB.Produits
                                     where p.Id.Equals(id)
                                     select p).First();
                        var Query2 = (from c in ProjectDB.Commandes
                                      where c.Produit.Equals(id)
                                      select c).FirstOrDefault();
                        if(Query2!=null) ProjectDB.Commandes.DeleteOnSubmit(Query2);
                        ProjectDB.Produits.DeleteOnSubmit(Query);
                        ProjectDB.SubmitChanges();
                        SearchProdDestB_Click(null, null);
                        SearchProdB_Click(null, null);
                    }
                    else if (_sender.Name.Equals("ListeFournTab"))
                    {
                        var Query = (from p in ProjectDB.Fournisseurs
                                     where p.Id.Equals(id)
                                     select p).First();
                        var Query2 = (from c in ProjectDB.Commandes
                                      where c.Produit.Equals(id)
                                      select c).FirstOrDefault();
                        if(Query2!=null) ProjectDB.Commandes.DeleteOnSubmit(Query2);
                        ProjectDB.Fournisseurs.DeleteOnSubmit(Query);
                        ProjectDB.SubmitChanges();
                        SearchFournB_Click(null, null);
                    }
                }
            }
        }
        private void guna2Button19_Click(object sender, EventArgs e)
        {
            ModProdPane.Hide();
            MainPanel.Show();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            ProdNom.Clear();
            ProdPrix.Clear();
            ProdImageId.Visible = false;
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            var Query = (from pr in ProjectDB.Produits
                         where pr.Id.Equals(_id)
                         select pr).FirstOrDefault();
            ProdNom.Text = ProdNom.Text.Trim();
            if (ProdNom.Text != "" && ProdExpDate.Text != "" && ProdStatus.Text != "")
            {
                try
                {
                    if (DateTime.Now.CompareTo(ProdExpDate.Value) > 0) throw new Exception();
                    else Query.Date_exp = ProdExpDate.Value;
                    Query.Prix = Convert.ToInt32(ProdPrix.Text);
                    Query.Nom = ProdNom.Text;
                    Query.Image = ProdImageId.Text;
                    Query.Status = ProdStatus.Text;
                    ProjectDB.SubmitChanges();
                    SearchProdDestB_Click(null, null);
                    SearchProdB_Click(null, null);
                    MessageBox.Show("le produit a bien été modifié");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Entrez un prix valide");
                }
                catch (Exception)
                {
                    MessageBox.Show("la date que vous avez saisie est non valide");
                }
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis");
            }
        }

        private void ProdUploadImageB_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Les fichiers (*.jpg, *.jepg, *.png, *.gif, *.bmp) | *.jpg; *.jepg; *.png; *.gif; *.bmp";
            op.Title = "Choisir une image";
            if (op.ShowDialog() == DialogResult.OK)
            {
                File.Copy(op.FileName, ProjectPath + @"\Img\" + op.SafeFileName, true);
                Image_id = op.SafeFileName;
                ProdImageId.Text = Image_id;
                ProdImageId.Visible = true;
            }
        }

        private void ListeFournTab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ModDelBackEnd(sender, e);
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            NomFourn.Clear();
            AdresseFourn.Clear();
            ContactFourn.Clear();
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            ModFournPane.Hide();
            MainPanel.Show();
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            ModFournPane.Hide();
            ListeFournsPanel.Show();
        }

        private void ModFournB_Click(object sender, EventArgs e)
        {
            if(NomFourn.Text!="" && AdresseFourn.Text!="" && ContactFourn.Text != "")
            {
                var Query = (from f in ProjectDB.Fournisseurs
                             where f.Id.Equals(_id)
                             select f).First();
                Query.Nom = NomFourn.Text.Trim();
                Query.Adresse = AdresseFourn.Text.Trim();
                Query.Contact = ContactFourn.Text.Trim();
                ProjectDB.SubmitChanges();
                SearchFournB_Click(null, null);
                MessageBox.Show("Le fournisseur a bien été modifié");
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis");
            }
        }

        private void guna2ImageButton4_Click_2(object sender, EventArgs e)
        {
            ModProdPane.Hide();
            Hidden_pane.Show();
        }

        private void ProdDestTab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ModDelBackEnd(sender, e);
        }
    }
}