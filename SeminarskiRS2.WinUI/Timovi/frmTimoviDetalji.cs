﻿using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI.Timovi
{
    public partial class frmTimoviDetalji : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Timovi");
        private readonly APIService _apiServiceStadioni = new APIService("Stadioni");
        private readonly APIService _apiServiceLige = new APIService("Lige");
        private readonly ImageService _imageService = new ImageService();
        public frmTimoviDetalji(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }
        private const int WM_CLOSE = 0x0010;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLOSE)
                AutoValidate = AutoValidate.Disable;
            base.WndProc(ref m);
        }
        private async Task LoadStadioni()
        {
            var result = await _apiServiceStadioni.Get<List<Model.Stadioni>>(null);
            cbStadioni.DisplayMember = "Naziv";
            cbStadioni.ValueMember = "StadionID";
            cbStadioni.SelectedItem = null;
            cbStadioni.SelectedText = "--Odaberite--";
            cbStadioni.DataSource = result;
        }
        private async Task LoadLige()
        {
            var result = await _apiServiceLige.Get<List<Model.Lige>>(null);
            cbLige.DisplayMember = "Naziv";
            cbLige.ValueMember = "LigaID";
            cbLige.SelectedItem = null;
            cbLige.SelectedText = "--Odaberite--";
            cbLige.DataSource = result;
        }
        private async void frmTimoviDetalji_Load(object sender, EventArgs e)
        {
            await LoadStadioni();
            await LoadLige();
            if (_id.HasValue)
            {
                Model.Timovi a = await _apiService.GetById<Model.Timovi>(_id);
                txtNaziv.Text = a.Naziv;
                txtOpis.Text = a.Opis;
                cbStadioni.SelectedValue = int.Parse(a.StadionID.ToString());
                cbLige.SelectedValue = int.Parse(a.LigaID.ToString());


                if (a.Slika.Length != 0)
                {
                    var img = _imageService.BytesToImage(a.Slika);
                    Image mythumb = _imageService.ImageToThumbnail(img);
                    pictureBox1.Image = mythumb;
                }
                else
                {
                    var noimg = _imageService.GetNoImage();
                    var th = _imageService.ImageToThumbnail(noimg);
                    pictureBox1.Image = th;
                }
            }
        }
        TimoviInsertRequest res = new TimoviInsertRequest();
        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Timovi> lista = await _apiService.Get<List<Model.Timovi>>(new TimoviSearchRequest() { Naziv = txtNaziv.Text, LigaID = int.Parse(cbLige.SelectedValue.ToString()) });
                if (lista.Count == 0 || (lista.Count == 1 && lista[0].TimID == _id))
                {

                    res.Naziv = txtNaziv.Text;
                    res.Opis = txtOpis.Text;
                    res.StadionID = int.Parse(cbStadioni.SelectedValue.ToString());
                    res.LigaID = int.Parse(cbLige.SelectedValue.ToString());
                    //spremanje slike u request se radi prilikom klika na dodaj 
                    //ako nije dodao novu sliku(UPDATE), samim time nije kliknuo na dodaj, trebala bi slika ostati nepromijenjena
                    if (res.Slika == null && _id.HasValue)
                    {
                        Model.Timovi a = await _apiService.GetById<Model.Timovi>(_id);
                        res.Slika = a.Slika;
                        res.SlikaThumb = a.SlikaThumb;
                    }

                    //za slucaj da korisnik ne unese sliku
                    if (res.Slika == null && !_id.HasValue)
                    {
                        var img = _imageService.GetNoImage();
                        res.Slika = _imageService.ImageToBytes(img);
                        var th = _imageService.ImageToThumbnail(img);
                        res.SlikaThumb = _imageService.ImageToBytes(th);
                    }

                    if (_id.HasValue)
                    {
                        int i = (int)_id;
                        try
                        {
                            await _apiService.Update<dynamic>(i, res);
                            MessageBox.Show("Operacija je uspjela.");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            await _apiService.Insert<dynamic>(res);
                            MessageBox.Show("Operacija je uspjela.");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Uneseni tim za tu ligu već postoji!");
                }
            }

            else
            {
                MessageBox.Show("Operacija nije uspjela! Morate unijeti sva polja. ");
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                res.Slika = file;
                Image image = Image.FromFile(fileName);

                Image mythumb = _imageService.ImageToThumbnail(image);
                res.SlikaThumb = _imageService.ImageToBytes(mythumb);
                pictureBox1.Image = mythumb;

            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Polje naziv je obavezno. ");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtNaziv, "Dozvoljeno je koristit samo slova. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtNaziv, null);
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, "Polje opis je obavezno. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtOpis, null);
        }

        private void cbLige_Validating(object sender, CancelEventArgs e)
        {
            if (cbLige.SelectedItem == null)
            {
                errorProvider1.SetError(cbLige, "Morate odabrati ligu. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbLige, null);
        }

        private void cbStadioni_Validating(object sender, CancelEventArgs e)
        {
            if (cbStadioni.SelectedItem == null)
            {
                errorProvider1.SetError(cbStadioni, "Morate odabrati stadion. ");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(cbStadioni, null);
        }
    }
}
