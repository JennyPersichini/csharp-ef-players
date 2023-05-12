using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_ef_players
{
    [Table("playerList")]
    [Index(nameof(PlayerId), IsUnique = true)]
    public class Player
    {
        //Un giocatore è caratterizzato da: id, nome, cognome, punteggio, numero partite giocate, numero partite vinte
        public int PlayerId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public double Punteggio { get; set; }
        public int PartiteGiocate { get; set; }
        public int PartiteVinte { get; set; }

        public Player(string nome, string cognome, double punteggio, int partiteGiocate, int partiteVinte)
        {
            Nome = nome;
            Cognome = cognome;
            Punteggio = punteggio;
            PartiteGiocate = partiteGiocate;
            PartiteVinte = partiteVinte;
        }

        public override string ToString()
        {
            string rapStringa = "Nome giocatore: " 
                + Nome 
                + "/n Cognome giocatore: " 
                + Cognome
                + "/n Punteggio: "
                + Punteggio
                + "/n Numero partite giocate: "
                + PartiteGiocate
                + "/n Numero partite vinte: "
                + PartiteVinte;

            return rapStringa;
        }
    }
}
