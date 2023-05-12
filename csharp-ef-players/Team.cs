using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_ef_players
{
    [Table("team")]
    public class Team
    {
        //Una squadra è caratterizzata da: id, nome, città, allenatore, colori
        public int TeamId { get; set; }
        public string Nome { get; set; }
        public string Citta { get; set; }
        public string Allenatore { get; set; }
        public string Colori { get; set; }

        public Team(string nome, string citta, string allenatore, string colori)
        {
            Nome = nome;
            Citta = citta;
            Allenatore = allenatore;
            Colori = colori;
        }

        public override string ToString()
        {
            string rapStringa = "Nome della squadra: " 
                + Nome 
                + "\n Città: " 
                + Citta 
                + "\n Allenatore: "
                + Allenatore
                + "\n Colori: "
                + Colori;

            return rapStringa;
        }

    }
}
