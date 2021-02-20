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
using Syncfusion.XlsIO;
using System.Web;

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
        public class Vent_alt
        {
            public int Id, Prix;
            public double Profit;
            public int? Quant;
            public string Produit,Image;
            public DateTime? Date; /// date de vente

            public Vent_alt(int id, int prix, int? quant, double profit, string produit,string image, DateTime? date)
            {
                Id = id;
                Prix = prix;
                Quant = quant;
                Profit = profit;
                Produit = produit;
                Image = image;
                Date = date;
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
            ////// loading the combobox with data
            var Query = from f in ProjectDB.Fournisseurs
                        select f;
            List<string> selected = new List<string>();
            foreach (Fournisseur f in Query) selected.Add(f.Nom);
            selected.Sort();
            ListFournsCombo.DataSource = selected;
            listBoxFourns.Items.Clear();
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
                ListeFournTab.Columns["Modifier"].Width = 60;
                ListeFournTab.Columns["Supprimer"].Width = 80;
                ListeFournTab.Columns["Modifier"].DefaultCellStyle.Padding = new Padding(3);
                ListeFournTab.Columns["Supprimer"].DefaultCellStyle.Padding = new Padding(3);
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
            btnColumn1.Text = "Modifier";
            btnColumn1.UseColumnTextForButtonValue = true;
            btnColumn1.DefaultCellStyle.Padding = new Padding(5, 35, 5, 35);
            btnColumn1.FlatStyle = FlatStyle.Flat;
            btnColumn1.DefaultCellStyle.ForeColor = Color.FromArgb(0, 182, 244);
            if(!DG.Columns.Contains("Modifier")) DG.Columns.Add(btnColumn1);
            ///////////
            DataGridViewButtonColumn btnColumn2 = new DataGridViewButtonColumn();
            btnColumn2.Name = "Supprimer";
            btnColumn2.Text = "Supprimer";
            btnColumn2.UseColumnTextForButtonValue = true;
            btnColumn2.DefaultCellStyle.Padding = new Padding(5, 35, 5, 35);
            btnColumn2.FlatStyle = FlatStyle.Flat;
            btnColumn2.DefaultCellStyle.ForeColor = Color.FromArgb(214, 40, 40);
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
                ////////////// adding commander button ///////////
                DataGridViewButtonColumn btnColumn3 = new DataGridViewButtonColumn();
                btnColumn3.Name = "Commander";
                btnColumn3.Text = "Commander";
                btnColumn3.UseColumnTextForButtonValue = true;
                btnColumn3.DefaultCellStyle.Padding = new Padding(4,35,4,35);
                btnColumn3.FlatStyle = FlatStyle.Flat;
                btnColumn3.DefaultCellStyle.ForeColor = Color.FromArgb(255, 162, 0);
                if (!ProdDestTab.Columns.Contains("Commander")) ProdDestTab.Columns.Add(btnColumn3);
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
            if (NomProd.Text!="" && ExpirProd.Text!="" && StatusProd.Text!="" && QuantiteEnStock.Text!="" && listBoxFourns.Items.Count!=0)
            {
                Produit pr = new Produit();
                pr.Nom = NomProd.Text;
                pr.Image = Image_id;
                try
                {
                    pr.Prix = Convert.ToInt32(PrixProd.Text);
                    pr.Quantite = Convert.ToInt32(QuantiteEnStock.Text);
                    if (DateTime.Now.Date.CompareTo(ExpirProd.Value.Date) >= 0) throw new Exception();
                    else pr.Date_exp = ExpirProd.Value.Date;
                    pr.Status = StatusProd.Text;
                    ProjectDB.Produits.InsertOnSubmit(pr);
                    ProjectDB.SubmitChanges();
                    /////// ProduitFournisseur DB //////
                    int produit_id = (from p in ProjectDB.Produits
                                 where p.Nom.Trim().Equals(pr.Nom.Trim())
                                 where p.Date_exp.Value.Date.CompareTo(pr.Date_exp.Value.Date)==0
                                 where p.Quantite.Equals(pr.Quantite)
                                 select p.Id).First();
                    int[] fournisseur_ids=new int[listBoxFourns.Items.Count];
                    int i;
                    for (i = 0; i < listBoxFourns.Items.Count; i++)
                    {
                        fournisseur_ids[i] = (from f in ProjectDB.Fournisseurs
                                              where f.Nom.Equals(listBoxFourns.Items[i])
                                              select f.Id).First();
                    }
                    for (i = 0; i < fournisseur_ids.Length; i++)
                    {
                        ProduitFournisseur pf = new ProduitFournisseur();
                        pf.Produit = produit_id;
                        pf.Fournisseur = fournisseur_ids[i];
                        ProjectDB.ProduitFournisseurs.InsertOnSubmit(pf);
                    }
                    ProjectDB.SubmitChanges();
                    /////// ProduitFournisseur DB //////
                    MessageBox.Show("le produit a bien été enregisté");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Format de l'entrée est non valide");
                }
                catch (Exception)
                {
                    MessageBox.Show("Date d'expiration non valide");
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
        int prod_id=0;
        private void ModDelBackEnd(object sender , DataGridViewCellEventArgs e)
        {
            var _sender = (DataGridView)sender;
            int id=0;
            try {
                if (_sender.Rows[e.RowIndex].Cells["Id"] != null) id = (int)_sender.Rows[e.RowIndex].Cells["Id"].Value;
                _id = id;
                if (_sender.Columns[e.ColumnIndex].Name == "Modifier")
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
                        EnStockQuant.Text = ToAlter.Quantite.ToString();
                        ProdStatus.SelectedIndex = ProdStatus.FindString(ToAlter.Status.Trim());
                        ProdExpDate.Value = (DateTime)ToAlter.Date_exp;
                        ProdImageId.Text = ToAlter.Image;
                        ProdImageId.Visible = true;
                        ModProdPane.Show();

                        /*ListeFournsComboMod.Items.Clear();
                        var Query2 = from pf in ProjectDB.ProduitFournisseurs
                                     where pf.Produit.Equals(id)
                                     select pf.Fournisseur;
                        List<int> fournisseur_ids = new List<int>();
                        foreach (var indice in Query2) fournisseur_ids.Add(indice);
                        for (int i = 0; i < fournisseur_ids.Count; i++)
                        {
                            var Query3 = (from f in ProjectDB.Fournisseurs
                                          where f.Id.Equals(fournisseur_ids[i])
                                          select f).FirstOrDefault();
                            if (Query3 != null)
                            {
                                ListeFournsComboMod.Items.Add(Query3.Nom);
                                ListFourns.Items.Add(Query3.Nom);

                            }
                        }*/
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
                            var Query2 = from c in ProjectDB.Commandes
                                         where c.Produit.Equals(id)
                                         select c;
                            var Query3 = from v in ProjectDB.Ventes
                                         where v.Produit.Equals(id)
                                         select v;
                            var Query4 = from pf in ProjectDB.ProduitFournisseurs
                                         where pf.Produit.Equals(id)
                                         select pf;
                            var Query5 = from a in ProjectDB.Achats
                                         where a.Produit.Equals(id)
                                         select a;
                            if (Query2 != null)
                            {
                                List<Commande> commandes = new List<Commande>();
                                foreach (var c in Query2) commandes.Add(c);
                                for (int i = 0; i < commandes.Count; i++)
                                {
                                    ProjectDB.Commandes.DeleteOnSubmit(commandes[i]);
                                }
                            }
                            if (Query3 != null)
                            {
                                List<Vente> ventes = new List<Vente>();
                                foreach (var v in Query3) ventes.Add(v);
                                for (int i = 0; i < ventes.Count; i++)
                                {
                                    ProjectDB.Ventes.DeleteOnSubmit(ventes[i]);
                                }
                            }
                            if (Query4 != null)
                            {
                                List<ProduitFournisseur> pfs = new List<ProduitFournisseur>();
                                foreach (var pf in Query4) pfs.Add(pf);
                                for (int i = 0; i < pfs.Count; i++)
                                {
                                    ProjectDB.ProduitFournisseurs.DeleteOnSubmit(pfs[i]);
                                }
                            }
                            if (Query5 != null)
                            {
                                List<Achat> ach = new List<Achat>();
                                foreach (var a in Query5) ach.Add(a);
                                for (int i = 0; i < ach.Count; i++)
                                {
                                    ProjectDB.Achats.DeleteOnSubmit(ach[i]);
                                }
                            }
                            ProjectDB.Produits.DeleteOnSubmit(Query);
                            ProjectDB.SubmitChanges();
                            SearchProdDestB_Click(null, null);
                            SearchProdB_Click(null, null);
                        }
                        else if (_sender.Name.Equals("ListeFournTab"))
                        {
                            var Query = (from f in ProjectDB.Fournisseurs
                                         where f.Id.Equals(id)
                                         select f).First();
                            var Query2 = from c in ProjectDB.Commandes
                                         where c.Produit.Equals(id)
                                         select c;
                            var Query3 = from pf in ProjectDB.ProduitFournisseurs
                                         where pf.Fournisseur.Equals(id)
                                         select pf;
                            if (Query2 != null)
                            {
                                List<Commande> commandes = new List<Commande>();
                                foreach (var c in Query2) commandes.Add(c);
                                for (int i = 0; i < commandes.Count; i++)
                                {
                                    ProjectDB.Commandes.DeleteOnSubmit(commandes[i]);
                                }
                            }
                            if (Query3 != null)
                            {
                                List<ProduitFournisseur> pfs = new List<ProduitFournisseur>();
                                foreach (var pf in Query3) pfs.Add(pf);
                                for (int i = 0; i < pfs.Count; i++)
                                {
                                    ProjectDB.ProduitFournisseurs.DeleteOnSubmit(pfs[i]);
                                }
                            }
                            ProjectDB.Fournisseurs.DeleteOnSubmit(Query);
                            ProjectDB.SubmitChanges();
                            SearchFournB_Click(null, null);
                        }
                    }
                }
                else if (_sender.Columns[e.ColumnIndex].Name == "Commander")
                {
                    if (_sender.Name == "ProdDestTab")
                    {
                        ProDestPane.Hide();
                        Hidden_pane = ProDestPane;
                        //// produit combobox
                        ProduitsCombo.Items.Clear();
                        ProduitsCombo.Items.Add(_sender.Rows[e.RowIndex].Cells["Nom"].Value);
                        ProduitsCombo.SelectedItem = _sender.Rows[e.RowIndex].Cells["Nom"].Value;
                        prod_id = Convert.ToInt32(_sender.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                        //// founisseur combobox
                        var Query = from pf in ProjectDB.ProduitFournisseurs
                                    where pf.Produit.Equals(prod_id)
                                    join f in ProjectDB.Fournisseurs on pf.Fournisseur equals f.Id
                                    select f.Nom;
                        List<string> selected = new List<string>();
                        foreach (string nom in Query) selected.Add(nom);
                        FournsCombo.DataSource = selected;
                    }
                    NouvCommandePane.Show();
                }
            }
            catch (ArgumentOutOfRangeException) {}
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
                    Query.Quantite = Convert.ToInt32(EnStockQuant.Text);
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
            DataGridView _sender = (DataGridView)sender;
            if (_sender.Columns[e.ColumnIndex].Name == "Modifier" || _sender.Columns[e.ColumnIndex].Name == "Supprimer")
            {
                ModDelBackEnd(sender, e);
            }
            else
            {
                ListeFournsPanel.Hide();
                Hidden_pane = ListeFournsPanel;
                ///////////////////////////
                FournsCombo.Items.Clear();
                FournsCombo.Items.Add(_sender.Rows[e.RowIndex].Cells["Nom"].Value);
                FournsCombo.SelectedIndex = 0;
                var Query = from pf in ProjectDB.ProduitFournisseurs
                            where pf.Fournisseur.Equals(_sender.Rows[e.RowIndex].Cells["Id"].Value)
                            join p in ProjectDB.Produits on pf.Produit equals p.Id
                            select p.Nom;
                List<string> produits = new List<string>();
                foreach (var nom in Query) produits.Add(nom);
                ProduitsCombo.Items.Clear();
                produits.ForEach(p => ProduitsCombo.Items.Add(p));
                if(ProduitsCombo.Items.Count!=0) ProduitsCombo.SelectedIndex = 0;
                ///////////////////////////
                NouvCommandePane.Show();
            }
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

        private void guna2Button24_Click(object sender, EventArgs e)
        {
            NouvCommandePane.Hide();
            MainPanel.Show();
        }

        private void guna2ImageButton6_Click(object sender, EventArgs e)
        {
            NouvCommandePane.Hide();
            CommandeQuant.Clear();
            Hidden_pane.Show();
        }
        private void ListFournsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!listBoxFourns.Items.Contains(ListFournsCombo.SelectedItem.ToString()))
            {
                listBoxFourns.Items.Add(ListFournsCombo.SelectedItem.ToString());
                listBoxFourns.Sorted = true;
            }
        }

        private void RemoveListboxItem_Click(object sender, EventArgs e)
        {
            if(listBoxFourns.SelectedItems.Count!=0) for (int i = listBoxFourns.SelectedIndices.Count - 1; i >= 0; i--) listBoxFourns.Items.RemoveAt(listBoxFourns.SelectedIndices[i]);
            else MessageBox.Show("aucun element dans la selection");
        }

        private void listBoxFourns_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ProduitsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AjCommandeB_Click(object sender, EventArgs e)
        {
            if (CommandeQuant.Text != "")
            {
                if(DateTime.Now.Date.CompareTo(CommandeLivraisonDate.Value.Date) <= 0)
                {
                    try{
                        int fournisseur_id = (from f in ProjectDB.Fournisseurs
                                     where f.Nom.Equals(FournsCombo.SelectedItem.ToString())
                                     select f.Id).First();
                        if (prod_id == 0 && ProduitsCombo.SelectedItem != null)
                        {
                            prod_id = (from p in ProjectDB.Produits
                                       where p.Nom.Equals(ProduitsCombo.SelectedItem.ToString())
                                       select p.Id).First();
                        }
                        Commande c = new Commande()
                        {
                            Produit = prod_id,
                            Fournisseur = fournisseur_id,
                            Quant = Convert.ToInt32(CommandeQuant.Text),
                            Date_commande = DateTime.Now,
                            Date_livraison = CommandeLivraisonDate.Value,
                        };
                        if (c.Produit != 0)
                        {
                            ProjectDB.Commandes.InsertOnSubmit(c);
                            ProjectDB.SubmitChanges();
                            MessageBox.Show("La commande a bien été enregistrée");
                        }
                        else MessageBox.Show("aucune produit n'est selectionné");
                    } catch (FormatException){
                        MessageBox.Show("entrer une quantité de commande valide");
                    }
                }
                else
                {
                    MessageBox.Show("La date de livraison est non valide");
                }
            }
            else
            {
                MessageBox.Show("tous les champs doivent être remplis");
            }
        }

        private bool ToTperte_disp = false;
        private bool ToTprofit_disp = false;
        private void BilanJourB_Click(object sender, EventArgs e)
        {
            GestionProduitsPanel.Hide();
            ListeProfitTitle.Text = "Liste des profits [" + DateTime.Now.Date.ToString("dd/MM/yy") + "]";
            ProfitsTabFill(ProfitsTab, TotalProfitsLab, ref ToTprofit_disp);
            ////////////////
            ListePerteTitle.Text = "Liste des pertes [" + DateTime.Now.Date.ToString("dd/MM/yy") + "]";
            PertesTabFill(PertesTab, TotalPertesLab, ref ToTperte_disp);
            ProfitPertePanel.Show();
        }
        private void PertesTabFill(DataGridView dgv, Guna.UI2.WinForms.Guna2Button btn,ref bool B)
        {
            dgv.Visible = true;
            var Query = from p in ProjectDB.Produits
                        where DateTime.Now.Date.CompareTo(p.Date_exp.Value.Date) == 0
                        where p.Nom.Contains(ChercherPerte.Text)
                        select p;
            List<Produit> selected = new List<Produit>();
            foreach (Produit p in Query) selected.Add(p);
            if (selected.Count != 0)
            {
                dgv.DataSource = selected;
                if (!dgv.Columns.Contains("Perte")) dgv.Columns.Add("Perte", "Perte");
                double prix = 0, total = 0;
                for (int i = 0; i < selected.Count; i++)
                {
                    prix = Convert.ToInt32(dgv.Rows[i].Cells["Prix"].Value);
                    prix = (prix / (1 + 0.2)) * Convert.ToInt32(dgv.Rows[i].Cells["Quantite"].Value);
                    dgv.Rows[i].Cells["Perte"].Value = Convert.ToString(prix);//// {0.2} 20% de profit dans chaque produit
                    total += prix;
                }
                if (!B)
                {
                    btn.Text += " " + total + " DH";
                    B = true;
                }
                dgv.Columns["Image"].Visible = false;
                LoadImages(dgv, selected.Count);
            }
            else
            {
                dgv.Visible = false;
            }
        }
        private void ProfitsTabFill(DataGridView dgv, Guna.UI2.WinForms.Guna2Button btn, ref bool B)
        {
            dgv.Visible = true;
            dgv.Rows.Clear();
            var Query = from v in ProjectDB.Ventes
                        where v.Date_vente.Date.CompareTo(DateTime.Now.Date) == 0
                        join p in ProjectDB.Produits on v.Produit equals p.Id
                        where p.Nom.Contains(ChercherVent.Text)
                        select new
                        {
                            Id = v.Id,
                            Produit = p.Nom,
                            Image = p.Image,
                            Prix = p.Prix,
                            Quant = v.Quant,
                            Date = v.Date_vente,
                            Profit = v.Quant * ((p.Prix)/(1.2))*0.2,
                        };
            List < Vent_alt > selected = new List<Vent_alt>();
            foreach (var v in Query) selected.Add(new Vent_alt(v.Id,v.Prix,v.Quant,v.Profit,v.Produit,v.Image,v.Date));
            if (selected.Count != 0)
            {
                double total = 0;
                if (dgv.Columns.Contains("Id2")) dgv.Columns["Id2"].Name = "Id";
                if (dgv.Columns.Contains("Produit2")) dgv.Columns["Produit2"].Name = "Produit";
                if (dgv.Columns.Contains("Image2")) dgv.Columns["Image2"].Name = "Image";
                if (dgv.Columns.Contains("Prix2")) dgv.Columns["Prix2"].Name = "Prix";

                for (int i = 0; i < selected.Count; i++)
                {
                    dgv.Rows.Add();
                    dgv.Rows[i].Cells["Id"].Value = selected[i].Id;
                    dgv.Rows[i].Cells["Produit"].Value = selected[i].Produit;
                    dgv.Rows[i].Cells["Image"].Value = selected[i].Image;
                    dgv.Rows[i].Cells["Prix"].Value = selected[i].Prix;
                    dgv.Rows[i].Cells["Quant"].Value = selected[i].Quant;
                    dgv.Rows[i].Cells["Date"].Value = selected[i].Date;
                    dgv.Rows[i].Cells["Profit"].Value = selected[i].Profit;
                    total += selected[i].Profit;
                }
                if (!B)
                {
                    btn.Text += " " + total + " DH";
                    B = true;
                }
                dgv.Columns["Image"].Visible = false;
                LoadImages(dgv, selected.Count);
            }
            else
            {
                dgv.Visible = false;
            }
        }
        private void guna2ImageButton15_Click(object sender, EventArgs e)
        {
            PertesTabFill(PertesTab, TotalPertesLab, ref ToTperte_disp);
        }

        private void guna2Button34_Click(object sender, EventArgs e)
        {
            ProfitPertePanel.Hide();
            MainPanel.Show();
        }

        private void guna2ImageButton13_Click(object sender, EventArgs e)
        {
            ProfitPertePanel.Hide();
            GestionProduitsPanel.Show();
        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {
            ProfitPertePanel.Hide();
            MainPanel.Show();
        }

        private void guna2ImageButton11_Click(object sender, EventArgs e)
        {
            ProfitPertePanel.Hide();
            GestionProduitsPanel.Show();
        }

        private void ChercherPerte_TextChanged(object sender, EventArgs e)
        {
            PertesTabFill(PertesTab, TotalPertesLab, ref ToTperte_disp);
        }

        private void guna2ImageButton7_Click(object sender, EventArgs e)
        {
            ProfitsTabFill(ProfitsTab, TotalProfitsLab, ref ToTprofit_disp);
        }

        private void ChercherVent_TextChanged(object sender, EventArgs e)
        {
            ProfitsTabFill(ProfitsTab, TotalProfitsLab, ref ToTprofit_disp);
        }

        private void StatusProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StatusProd.SelectedIndex == 1)
            {
                QuantiteEnStock.Text = 0.ToString();
                QuantiteEnStock.Enabled = false;
            }
            else if(StatusProd.SelectedIndex == 0) QuantiteEnStock.Enabled = true;
        }

        private void ProdStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProdStatus.SelectedIndex == 1)
            {
                EnStockQuant.Text = 0.ToString();
                EnStockQuant.Enabled = false;
            }
            else if (ProdStatus.SelectedIndex == 0) EnStockQuant.Enabled = true;
        }

        private void guna2ImageButton14_Click(object sender, EventArgs e)
        {
            StatistiquesPanel.Hide();
            MainPanel.Show();
        }

        private void statistiquesB_Click(object sender, EventArgs e)
        {
            MainPanel.Hide();
            StatistiquesPanel.Show();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MainPanel.Hide();
            StatistiquesPanel.Show();
        }
        private void GenerateStats(System.Windows.Forms.DataVisualization.Charting.Chart Chart,Guna.UI2.WinForms.Guna2ComboBox StatTri,DateTime nowMinus)
        {
            Chart.Visible = false;
            gainTot.Visible = false;
            perteTot.Visible = false;
            gainTot.Text = "";
            perteTot.Text = "";
            Chart.Series.Clear();
            var Query = from v in ProjectDB.Ventes
                        where v.Date_vente.Date.CompareTo(nowMinus.Date) >= 0
                        join p in ProjectDB.Produits on v.Produit equals p.Id
                        select v.Quant * ((p.Prix)/(1.2))*0.2;
            var Query2 = from p in ProjectDB.Produits
                         where DateTime.Now.Date.CompareTo(p.Date_exp.Value.Date) > 0
                         where p.Status.Trim().Equals("disponible")
                         where p.Date_exp.Value.Date.CompareTo(nowMinus) >= 0
                         select (p.Prix)/(1.2) * p.Quantite;
            List<double> Profits = new List<double>();
            List<double> losses = new List<double>();
            foreach (var profit in Query) Profits.Add(profit);
            foreach (var loss in Query2) losses.Add(loss);
            if (Profits.Count != 0 || losses.Count != 0)
            {
                double total_gain = 0;
                double total_loss = 0;
                int i;
                Chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                Chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                System.Windows.Forms.DataVisualization.Charting.Series serie = new System.Windows.Forms.DataVisualization.Charting.Series("Profit");
                serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                serie.BorderWidth = 3;

                System.Windows.Forms.DataVisualization.Charting.Series serie2 = new System.Windows.Forms.DataVisualization.Charting.Series("Perte");
                serie2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
                serie2.BorderWidth = 3;

                Chart.Series.Add(serie);
                Chart.Series.Add(serie2);

                Chart.Series["Profit"].Color = Color.FromArgb(56, 176, 0);
                for (i = 0; i < Profits.Count; i++)
                {
                    Chart.Series["Profit"].Points.AddY(Profits[i]);
                    total_gain += Profits[i];
                }
                Chart.Series["Perte"].Color = Color.FromArgb(208, 0, 0);
                for (i = 0; i < losses.Count; i++)
                {
                    Chart.Series["Perte"].Points.AddY(losses[i]);
                    total_loss += losses[i];
                }
                gainTot.Text = "Total de profits : " + total_gain + " DH";
                perteTot.Text = "Total des pertes : " + total_loss + " DH";
                Chart.Visible = true;
                gainTot.Visible = true;
                perteTot.Visible = true;
            }
        }
        private void StatTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime nowMinus=DateTime.Now;
            if (StatTri.SelectedItem.ToString().Equals("par semaine"))
            {
                nowMinus = DateTime.Now.AddDays(-7);
            }
            else if (StatTri.SelectedItem.ToString().Equals("par mois"))
            {
                nowMinus = DateTime.Now.AddDays(-30);
            }
            else if (StatTri.SelectedItem.ToString().Equals("par année"))
            {
                nowMinus = DateTime.Now.AddDays(-365);
            }
            GenerateStats(Chart, StatTri, nowMinus);
        }

        private void AjFourn_Click(object sender, EventArgs e)
        {
            if(FournNom.Text!="" && FournContact.Text!="" && FournAdresse.Text != "")
            {
                Fournisseur f = new Fournisseur()
                {
                    Nom = FournNom.Text,
                    Contact = FournContact.Text,
                    Adresse = FournAdresse.Text
                };
                ProjectDB.Fournisseurs.InsertOnSubmit(f);
                ProjectDB.SubmitChanges();
                MessageBox.Show("Le fournisseur a bien été ajouté");
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis");
            }
        }

        private void AnnulerFourn_Click(object sender, EventArgs e)
        {
            FournNom.Clear();
            FournAdresse.Clear();
            FournContact.Clear();
        }
        private void EtatDocB_Click(object sender, EventArgs e)
        {
            int i;
            var commandes_To_achats = (from c in ProjectDB.Commandes
                                       where c.Date_livraison.Value.Date.CompareTo(DateTime.Now.Date) <= 0
                                       select c).ToList(); //// list of commands that have been delivered to be transformed into achats
            for (i = 0; i < commandes_To_achats.Count; i++)
            {
                ProjectDB.Commandes.DeleteOnSubmit(commandes_To_achats[i]);
                Achat achat = new Achat()
                {
                    Produit = commandes_To_achats[i].Produit,
                    Quant = commandes_To_achats[i].Quant,
                    Date_achat = commandes_To_achats[i].Date_livraison.Value,
                };
                ProjectDB.Achats.InsertOnSubmit(achat);
                ProjectDB.SubmitChanges();
            }
            ExcelEngine excelEng = new ExcelEngine();
            Syncfusion.XlsIO.IApplication excel = excelEng.Excel;
            Syncfusion.XlsIO.IWorkbook workbook = excel.Workbooks.Create(5);
            Syncfusion.XlsIO.IWorksheet worksheet1 = workbook.Worksheets[0];
            Syncfusion.XlsIO.IWorksheet worksheet2 = workbook.Worksheets[1];
            Syncfusion.XlsIO.IWorksheet worksheet3 = workbook.Worksheets[2];
            Syncfusion.XlsIO.IWorksheet worksheet4 = workbook.Worksheets[3];
            Syncfusion.XlsIO.IWorksheet worksheet5 = workbook.Worksheets[4];
            Syncfusion.XlsIO.IWorksheet worksheet=null;
            worksheet1.Name = "Produits";
            worksheet2.Name = "Fournisseurs";
            worksheet3.Name = "Commandes";
            worksheet4.Name = "Ventes";
            worksheet5.Name = "Achats";
            ///////////Produits //////////////
            worksheet = worksheet1;
            var Query = (from p in ProjectDB.Produits
                        select p).ToList();
            worksheet[1, 1].Text = "Id";
            worksheet[1, 2].Text = "Nom";
            worksheet[1, 3].Text = "Prix";
            worksheet[1, 4].Text = "Date_exp";
            worksheet[1, 5].Text = "Status";
            worksheet[1, 6].Text = "Quantité";
            for(i=1;i<7;i++) worksheet[1,i].CellStyle.Color = Color.FromArgb(46, 196, 182);
            for (i = 0; i < Query.Count; i++)
            {
                worksheet[i + 2, 1].Text = Query[i].Id.ToString();
                worksheet[i + 2, 2].Text = Query[i].Nom;
                worksheet.SetColumnWidth(2, 30);
                worksheet[i + 2, 3].Text = Query[i].Prix.ToString();
                worksheet[i + 2, 4].Text = Query[i].Date_exp.ToString();
                worksheet.SetColumnWidth(4, 25);
                worksheet[i + 2, 5].Text = Query[i].Status;
                worksheet.SetColumnWidth(5, 25);
                worksheet[i + 2, 6].Text = Query[i].Quantite.ToString();
            }
            /////////////////////////////
            ///////////Fournisseurs //////////////
            worksheet = worksheet2;
            var Query2 = (from f in ProjectDB.Fournisseurs
                         select f).ToList();
            worksheet[1, 1].Text = "Id";
            worksheet[1, 2].Text = "Nom";
            worksheet[1, 3].Text = "Adresse";
            worksheet[1, 4].Text = "Contact";
            for (i = 1; i < 5; i++) worksheet[1, i].CellStyle.Color = Color.FromArgb(231, 29, 54);
            for (i = 0; i < Query2.Count; i++)
            {
                worksheet[i + 2, 1].Text = Query2[i].Id.ToString();
                worksheet[i + 2, 2].Text = Query2[i].Nom;
                worksheet.SetColumnWidth(2, 25);
                worksheet[i + 2, 3].Text = Query2[i].Adresse;
                worksheet.SetColumnWidth(3, 25);
                worksheet[i + 2, 4].Text = Query2[i].Contact;
                worksheet.SetColumnWidth(4, 25);
            }
            /////////////////////////////
            ///////////Commandes //////////////
            worksheet = worksheet3;
            var Query3 = (from c in ProjectDB.Commandes
                          select c).ToList();
            worksheet[1, 1].Text = "Id";
            worksheet[1, 2].Text = "Produit";
            worksheet[1, 3].Text = "Fournisseur";
            worksheet[1, 4].Text = "Quantité";
            worksheet[1, 5].Text = "Date de commande";
            worksheet[1, 6].Text = "Date de livraison";
            for (i = 1; i < 7; i++) worksheet[1, i].CellStyle.Color = Color.FromArgb(150, 108, 86);
            for (i = 0; i < Query3.Count; i++)
            {
                worksheet[i + 2, 1].Text = Query3[i].Id.ToString();
                worksheet[i + 2, 2].Text = Query3[i].Produit.ToString();
                worksheet[i + 2, 3].Text = Query3[i].Fournisseur.ToString();
                worksheet[i + 2, 4].Text = Query3[i].Quant.ToString();
                worksheet[i + 2, 5].Text = Query3[i].Date_commande.ToString();
                worksheet.SetColumnWidth(4, 25);
                worksheet[i + 2, 6].Text = Query3[i].Date_livraison.ToString();
                worksheet.SetColumnWidth(6, 25);
            }
            /////////////////////////////
            /////////// Ventes //////////////
            worksheet = worksheet4;
            var Query4 = (from v in ProjectDB.Ventes
                          select v).ToList();
            worksheet[1, 1].Text = "Id";
            worksheet[1, 2].Text = "Produit";
            worksheet[1, 3].Text = "Quantite";
            worksheet[1, 4].Text = "Date de vente";
            for (i = 1; i < 5; i++) worksheet[1, i].CellStyle.Color = Color.FromArgb(230, 207, 0);
            for (i = 0; i < Query4.Count; i++)
            {
                worksheet[i + 2, 1].Text = Query4[i].Id.ToString();
                worksheet[i + 2, 2].Text = Query4[i].Produit.ToString();
                worksheet[i + 2, 3].Text = Query4[i].Quant.ToString();
                worksheet[i + 2, 4].Text = Query4[i].Date_vente.ToString();
                worksheet.SetColumnWidth(4, 20);
            }
            /////////////////////////////
            /////////// Achats //////////////
            worksheet = worksheet5;
            var Query5 = (from a in ProjectDB.Achats
                          select a).ToList();
            worksheet[1, 1].Text = "Id";
            worksheet[1, 2].Text = "Produit";
            worksheet[1, 3].Text = "Quantite";
            worksheet[1, 4].Text = "Date d'achat";
            for (i = 1; i < 5; i++) worksheet[1, i].CellStyle.Color = Color.FromArgb(255, 84, 0);
            for (i = 0; i < Query5.Count; i++)
            {
                worksheet[i + 2, 1].Text = Query5[i].Id.ToString();
                worksheet[i + 2, 2].Text = Query5[i].Produit.ToString();
                worksheet[i + 2, 3].Text = Query5[i].Quant.ToString();
                worksheet[i + 2, 4].Text = Query5[i].Date_achat.ToString();
                worksheet.SetColumnWidth(4, 20);
            }
            /////////////////////////////
            Retry:
            try{
                workbook.SaveAs(ProjectPath + @"\Output\EtatStock.xlsx");
                notifyIcon1.Icon = new System.Drawing.Icon(ProjectPath + @"\Img\storeLogo.ico");
                notifyIcon1.Text = "GestionStock";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Etat de stock [excel]";
                notifyIcon1.BalloonTipText = "chemin : "+ ProjectPath + @"\Output";
                notifyIcon1.ShowBalloonTip(150);
            } catch (IOException){
                DialogResult dr = MessageBox.Show("Le fichier est déja ouvert par un autre processus","Message",MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                if(dr == DialogResult.Retry) goto Retry;
            }
        }
        private void EtatDocB2_Click(object sender, EventArgs e)
        {
            EtatDocB_Click(null, null);
        }
    }
}