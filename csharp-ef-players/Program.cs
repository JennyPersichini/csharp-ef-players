// See https://aka.ms/new-console-template for more information
using csharp_ef_players;

Console.WriteLine("Hello, World!");

string connectionString = "Data Source = localhost; Initial Catalog = PlayersDB; Integrated Security = True";

bool go = true;
Console.WriteLine("------- MENU -------");
Console.WriteLine("Seleziona un'opzione:");
Console.WriteLine("1. Inserisci un nuovo giocatore: ");
Console.WriteLine("2. Cerca un giocatore per nome: ");
Console.WriteLine("3. Cerca un giocatore per id: ");
Console.WriteLine("4. Modifica un giocatore: ");
Console.WriteLine("5. Cancella un giocatore: ");
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




       /*
    case 6:
        Console.WriteLine("Grazie e arrivederci!");
        go = false;

        break;

    default:
        Console.WriteLine("Non hai inserito un'opzione valida: ritenta.");
        break;*/
}
