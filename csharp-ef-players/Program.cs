// See https://aka.ms/new-console-template for more information
using csharp_ef_players;

Console.WriteLine("Hello, World!");

string connectionString = "Data Source = localhost; Initial Catalog = PlayersDB; Integrated Security = True";

bool go = true;
Console.WriteLine("------- MENU -------");
Console.WriteLine("Seleziona un'opzione:");
Console.WriteLine("1. Inserisci un nuovo giocatore: ");
Console.WriteLine("2. Cerca un giocatore per id: ");
Console.WriteLine("3. Cerca un giocatore per nome: ");
Console.WriteLine("4. Modifica un giocatore tramite id: ");
Console.WriteLine("5. Inserire una nuova squadra: ");
Console.WriteLine("6. Esci");

Console.WriteLine("Inserisci l'opzione desiderata: ");
int response = int.Parse(Console.ReadLine());

switch (response)
{
    case 1:
        Console.WriteLine("Inserisci il nome del giocatore: ");
        string nomeGiocatore = Console.ReadLine();

        Console.WriteLine("Inserisci il cognome del giocatore: ");
        string cognomeGiocatore = Console.ReadLine();

        using (PlayerContext db = new PlayerContext())
        {
            Random random = new Random();

            int punteggioGiocatore = random.Next(11);
            int partiteGiocatore = random.Next(1, 101);
            int partiteVinteGiocatore = random.Next(1, partiteGiocatore);

            Player player = new Player(nomeGiocatore, cognomeGiocatore, punteggioGiocatore, partiteGiocatore, partiteVinteGiocatore);

            db.Add(player);
            db.SaveChanges();            
        }

        break;

    case 2:
        Console.Write("Inserire l'id del giocatore interessato: ");
        int playerIdToSearch = int.Parse(Console.ReadLine());

        using (PlayerContext db = new PlayerContext())
        {
            Player playerFound = db.Players.Where(player => player.PlayerId == playerIdToSearch).First();
            Console.WriteLine(playerFound);
        }

        break;

    case 3:
        Console.WriteLine("Inserisci il nome del giocatore da visualizzare: ");
        string playerNomeToSearch = Console.ReadLine();

        Console.WriteLine("Inserisci il cognome del giocatore da visualizzare: ");
        string playerCognomeToSearch = Console.ReadLine();

        using (PlayerContext db = new PlayerContext())
        {
            Player playerFound = db.Players.Where(player => player.Nome == playerNomeToSearch && player.Cognome == playerCognomeToSearch).First();
            Console.WriteLine(playerFound.ToString());

        }
        break;

    case 4:
        Console.Write("Inserire id: ");
        int playerIdToModify = int.Parse(Console.ReadLine());

        using (PlayerContext db = new PlayerContext())
        {
            if (db.Players.Where(player => player.PlayerId == playerIdToModify).Any())
            {
                Player playerToModify = db.Players.Where(player => player.PlayerId == playerIdToModify).First();

                Console.Write("Inserire le partite giocate: ");
                int newPartita = int.Parse(Console.ReadLine());

                Console.Write("Inserire il punteggio: ");
                int newPunteggio = int.Parse(Console.ReadLine());

                playerToModify.PartiteGiocate = newPartita;
                playerToModify.Punteggio = newPunteggio;

                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Non è stato trovato nessun giocatore con id = " + playerIdToModify);
            }
        }

        break;

    case 5:

        Console.Write("Inserire il nome della squadra: ");
        string teamNome = Console.ReadLine();

        Console.WriteLine("Inserire la città della squadra: ");
        string citta = Console.ReadLine();

        Console.WriteLine("Inserire il nome dell'allenatore: ");
        string allenatore = Console.ReadLine();

        Console.WriteLine("Inserire i colori della squadra: ");
        string colori = Console.ReadLine();

        using (PlayerContext db = new PlayerContext())
        {
            Team newTeam = new Team(teamNome, citta, allenatore, colori);

            db.Add(newTeam);
            db.SaveChanges();
        }

        break;

     case 6:
         Console.WriteLine("Arrivederci e grazie!!!!");
         go = false;

         break;

     default:
         Console.WriteLine("Non hai inserito un'opzione valida: ritenta.");
         break;
}
