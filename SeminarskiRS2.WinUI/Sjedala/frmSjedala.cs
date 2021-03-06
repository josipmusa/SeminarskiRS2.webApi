﻿using SeminarskiRS2.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeminarskiRS2.WinUI.Sjedala
{
    public partial class frmSjedala : Form
    {
        private readonly int? _id = null;
        private readonly APIService _apiService = new APIService("Sjedala");
        public frmSjedala(int? id=null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnPretrazi_Click(object sender, EventArgs e)
        {
            var search = new SjedalaSearchRequest()
            {
                Oznaka = txtPretraga.Text
            };
            var res = await _apiService.Get<dynamic>(search);
            dgvSjedala.AutoGenerateColumns = false;
            dgvSjedala.DataSource = res;
        }

        private void dgvSjedala_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvSjedala.SelectedRows[0].Cells[0].Value;
            var frm = new frmSjedalaDetalji(int.Parse(id.ToString()));
            frm.Show();
        }

        private void frmSjedala_Load(object sender, EventArgs e)
        {

        }
    }
}
