﻿using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI.Drzave
{
    public partial class frmDrzaveDetalji : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Drzave");
        public frmDrzaveDetalji(int? id=null)
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

        private async void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                List<Model.Drzave> lista = await _apiService.Get<List<Model.Drzave>>(new DrzaveSearchRequest() { Naziv = txtNaziv.Text });
                //zbog nemogucnosti drugacije pretrage drzava dobit cemo i one koje pocinju na isto slovo
                //provjeriti cemo one koje nose isti naziv
                //kod ostalih je provjereno na service jer sve ostale salju vise parametara od samog naziva....
                lista = lista.Where(s => s.Naziv.Equals(txtNaziv.Text)).ToList();
                if (lista.Count == 0 || (lista.Count == 1 && lista[0].DrzavaID == _id))
                {
                    var req = new DrzaveInsertRequest()
                    {
                        Naziv = txtNaziv.Text
                    };
                    if (_id.HasValue)
                    {
                        int i = (int)_id;
                        try
                        {
                            await _apiService.Update<dynamic>(i, req);
                            MessageBox.Show("Operacija je uspjela!");
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
                            await _apiService.Insert<dynamic>(req);
                            MessageBox.Show("Operacija je uspjela!");
                            this.Close();
                        }
                        catch (Exception)
                        {
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Unesena država već postoji!");

                }
            }
            else
            {
                MessageBox.Show("Operacija nije uspjela!");
                this.Close();
            }
        }

        private async void frmDrzaveDetalji_Load(object sender, EventArgs e)
        {
            if (_id != null)
            {
                var a = await _apiService.GetById<dynamic>(_id);
                txtNaziv.Text = a.Naziv;
            }
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Polje naziv je obavezno. ");
                e.Cancel = true;//zaustaviti procesiranje forme
            }
            else if (!Regex.IsMatch(txtNaziv.Text, @"^[a-zA-Z ]+$"))
            {
                errorProvider1.SetError(txtNaziv, "Dozvoljeno je koristiti samo slova za naziv. ");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }
    }
}
