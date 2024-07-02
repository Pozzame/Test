/*Random rng = new Random();
int sum = 0;
for ( int i = 0 ; i < 10 ; i++ ) sum =+ rng.Next(11);
Console.WriteLine(sum);*/
/*
Random rng = new Random();
int sum = 0;
for (int i = 0;i<10;i++) 
{
    int num =rng.Next(11);
    sum += num;
    Console.WriteLine( num +" "+ sum );
}
Console.WriteLine(sum);*/

// Utilizzare un ciclo do wile per ripetere un menù di opzioni finkè l'utente non sceglie d uscire mantenendo il menù sempre nella stessa posizione
char inserimento = 'o'; //Inizializza inserimento
Console.Clear(); //Cancella consolle preventivo
Console.WriteLine("Non hai fatto ancora nessuna scenta"); //Avviso di pre selezione per mantenere posizione del menù
do
{
    Console.WriteLine("Menù di selezione\n1 - Opzione 1\n2 - Opzione 2\n3 - Opzione 3\nq per uscire"); // Stampa menù
    inserimento = Console.ReadKey(true).KeyChar; //Attente selezione
    Console.Clear(); //Cancella schermo
    if (inserimento == '1' || inserimento== '2' || inserimento == '3' || inserimento == 'q') //Verivica che la selezione sia valida
        Console.WriteLine($"Hai selezionato opzione {inserimento}"); //Stampa selezione
        else Console.WriteLine("Scelta non valida"); //Avvisa di selezione errata
    Console.Beep(); //Bippa
} while (inserimento != 'q'); //Esce con 'q'
Console.WriteLine("Arrivederci");