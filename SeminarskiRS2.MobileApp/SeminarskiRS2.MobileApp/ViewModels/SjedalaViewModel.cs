﻿using SeminarskiRS2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeminarskiRS2.MobileApp.ViewModels
{
    public class SjedalaViewModel : BaseViewModel
    {
        private APIService _apiServiceSjedala = new APIService("Sjedala");
        private APIService _apiServiceKorisnici = new APIService("Korisnici");


        public SjedalaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Sjedala> SjedalaList { get; set; } = new ObservableCollection<Sjedala>();
        public Sektori sektor { get; set; }
        public Utakmice utakmica { get; set; }
        public Korisnik Korisnik { get; set; }

        public int BrojSjedala { get; set; }
        public int BrojRedova { get; set; }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            IsBusy = true;
            var korisnicko = APIService.KorisnickoIme;
            List<Korisnik> listKorisnici = await _apiServiceKorisnici.Get<List<Korisnik>>(null);
            foreach (var korisnik in listKorisnici)
            {
                if (korisnik.KorisnickoIme == korisnicko)
                {
                    Korisnik = korisnik;
                    break;
                }
            }

            var list = await _apiServiceSjedala.Get<List<Sjedala>>(null);
            BrojSjedala = 0;
            SjedalaList.Clear();
            foreach (var sjedalo in list)
            {
                if (sjedalo.SektorID == sektor.SektorID && sjedalo.Status == false)
                {
                    SjedalaList.Add(sjedalo);
                    BrojSjedala++;
                }
            }
            if (BrojSjedala > 20)
                BrojRedova = BrojSjedala / 20;
            else
                BrojRedova = 1;
        }

    }
}
