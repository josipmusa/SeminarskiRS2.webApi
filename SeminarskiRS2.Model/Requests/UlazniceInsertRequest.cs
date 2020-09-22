﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeminarskiRS2.Model.Requests
{
    public class UlazniceInsertRequest
    {
        public int SjedaloID { get; set; }
        public int UtakmicaID { get; set; }
        public int KorisnikID { get; set; }
        public DateTime DatumKupnje { get; set; }
        public DateTime VrijemeKupnje { get; set; }

    }
}
