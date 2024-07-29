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
/*
// Utilizzare un ciclo do wile per ripetere un menù di opzioni finkè l'utente non sceglie d uscire mantenendo il menù sempre nella stessa posizione
char inserimento = 'o'; //Inizializza inserimento
Console.Clear(); //Cancella consolle preventivo
Console.WriteLine("Non hai fatto ancora nessuna scenta"); //Avviso di pre selezione per mantenere posizione del menù
do
{
    Console.WriteLine("Menù di selezione\n1 - Opzione 1\n2 - Opzione 2\n3 - Opzione 3\nq per uscire"); // Stampa menù
    inserimento = Console.ReadKey(true).KeyChar; //Attende selezione
    Console.Clear(); //Cancella schermo
    if (inserimento == '1' || inserimento== '2' || inserimento == '3' || inserimento == 'q') //Verivica che la selezione sia valida
        Console.WriteLine($"Hai selezionato opzione {inserimento}"); //Stampa selezione
        else Console.WriteLine("Scelta non valida"); //Avvisa di selezione errata
    Console.Beep(); //Bippa
} while (inserimento != 'q'); //Esce con 'q'
Console.WriteLine("Arrivederci");*/
/*
﻿try
{
    int zero = 0;
    int numero = 1 / zero; // il programma si blocca perché non si può dividere per zero
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    Console.WriteLine(e.Data); // stampa il dizionario di dati associato all'eccezione
    return;
}
finally
{
    Console.WriteLine("Fine del programma");
}*/
/*

DateTime date1 = new DateTime(2023, 1, 2);
DateTime date2 = new DateTime(2024, 1, 1);
DateTime date3 = DateTime.Today;

int result = date1.CompareTo(date2);
int result1 = DateTime.Compare(date1, date2);

TimeSpan difference = date3-date1;
Console.WriteLine(difference.ToString());
Console.WriteLine(difference.Days);
Console.WriteLine(difference.Hours);
Console.WriteLine(difference.TotalHours);


DateTime date4 = date3.Add(difference);

Console.WriteLine(date4);
Console.WriteLine(date4.ToString());
long pp = date1.Ticks;

Console.ReadLine();*/

/*
int.TryParse(Console.ReadLine(), out int risultato);

Console.WriteLine(somma(3, 4, out risultato) +" "+ risultato + " " );




static int somma(int a, int b, out int risultato)
{
    return risultato = a+b;
}*/



using Spectre.Console;
using Newtonsoft.Json;
using System.Collections;
using System.Runtime.InteropServices;

class Program{
    const string CSVPATH = @".\data\csvFiles";
    //const string CATPATH = @"C:\Users\francesco\Documents\workspace\firstPersonalProject\PcHArdwareInventory\data\productsCategories"; 
    //const string CSVPATH = @".\data\csvFiles";
    const string CATPATH = @"C:\\Users\\Pozzame\\Documents\\Corso_2024\\test\\data\\productscategories"; 
    const string PROPERTIESFILE = "data.json"; // File di configurazione per ogni tipologia di prodotto proprietà/tipo di dato 
    const string FILENAMEFILE = "fileName.txt";
    static string selection = new string("");
    static List<string> categories = CategoryList(); // Lista delle categorie di prodotti che viene letta dalle sottocartelle all'interno di .\data\productsCategories
    
    

    static void Main(string[] args){
        while(true){
            Console.Clear();
            selection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\n[red]MANAGE WAREHOUSE[/]")
                .PageSize(14)
                .MoreChoicesText("[grey](Move up and down to make your choice)[/]")
                .AddChoices(new string[] {
                    "View Products", "Add Product", "Remove Product", "Exit",}));   // Voci del menu principale
            switch(selection){
                case "View Products":
                    break;

                case "Add Product":
                    selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\nProduct isertion")
                        .PageSize(14)
                        .MoreChoicesText("[grey](Move up and down to make your choice)[/]")
                        .AddChoices(new string[] {"Insert manually", "Insert from .csv file", "Back",}));  // Sottomenu di Add product
                    switch(selection){
                        case "Insert manually":
                            if(categories.Count > 0){
                                categories.Add("Back");
                                selection = AnsiConsole.Prompt(
                                    new SelectionPrompt<string>()
                                    .Title("\nSelect Product Category")
                                    .PageSize(14)
                                    .MoreChoicesText("[grey](Move up and down to make your choice)[/]")
                                    .AddChoices(categories));           // Quando seleziono l'inserimento manuale di un prodotto mi viene richiesto che tipologia voglio inserire
                                switch(selection){
                                    case "Back":
                                        break;
                                    default:
                                        InsertProductManually(PropertiesList(selection), selection);
                                        break;
                                }
                            }else{
                                Console.WriteLine("You have to add a Product Category\n\nPress a key...");
                                Console.ReadKey();
                            }
                            categories.Remove("Back");
                            break; 
                        case "Insert from .csv file":
                            break; 
                        case "Back":
                            break; 
                    }
                    break;

                case "Remove Product":
                    break;

                case "Exit":
                    return;
            }
        }
    }
    private static List<string> CsvFilesList(){ // Funzione che ritorna i nomi dei file .csv (senza percorso) presenti in una cartella
        List<string> csvFilesFromFolder = new List<string>(Directory.GetFiles(CSVPATH)); 

        if(csvFilesFromFolder.Count > 0){
            for(int i = 0; i < csvFilesFromFolder.Count; i++){
                csvFilesFromFolder[i] = Path.GetFileName(csvFilesFromFolder[i]);
            }
            return csvFilesFromFolder;
        }else
            return new List<string>();
    }
    private static List<string> CategoryList(){ // Funzione che ritorna la lista delle categorie di prodotti per popolare il sottomenu di "Add Product" 
        List<string> productsCategories = new List<string>(Directory.GetDirectories(CATPATH)); 

        if(productsCategories.Count > 0){
            for(int i = 0; i < productsCategories.Count; i++){
                productsCategories[i] = productsCategories[i].Remove(0, CATPATH.Length+1);
            }
            return productsCategories;
        }else
            return new List<string>();
    }
    private static string[][] PropertiesList(string category){  // funzione che restituisce per ogni linea in un file 
        List<string> propertiesList = new List<string>();       // di configurazione in lettura la proprietà e il tipo di dato
        string[][] properties;                                  // che la rappresenta
        string line;
            
        using(StreamReader sr = new StreamReader(Path.Combine(CATPATH, category, PROPERTIESFILE))){
            while((line = sr.ReadLine()!) != null){
                propertiesList.Add(line);
            }

            properties = new string[propertiesList.Count][];

            for(int i = 0; i < propertiesList.Count; i++){
                properties[i] = propertiesList[i].Split(",");
            }
        }
        return properties;
    }

    private static void InsertProductManually(string[][] properties, string item){      // Funzione che prende la lista delle proprietà del prodotto e la categoria 
        bool success = false;                                                           // e permette l'inserimento dei campi e salva un nuovo file .json nella cartella
        string stringProperty;         
        string file = "0";

        string path = Path.Combine(CATPATH, item, file + ".json");

        File.Create(path).Close();

        for(int i = 0;i < properties.Length; i++){
            success = false;
            do{
                Console.Clear();
                Console.WriteLine($"Insert a value for the {properties[i][0]} property: \n");
                Console.Write($"{properties[i][0]} --> ");
                stringProperty = Console.ReadLine()!;

                

                if(properties[i][1] != "int"){
                    if(stringProperty != ""){
                        properties[i][1] = stringProperty;/*
                        if(i == 0)
                            File.AppendAllText(path, "{\n"+"\""+properties[i][0] + ": " + stringProperty + ",\n"); 
                        else if(i == (properties.Length-1))
                            File.AppendAllText(path, properties[i][0] + ": " + stringProperty + "\n}");
                        else
                            File.AppendAllText(path, properties[i][0] + ": "+stringProperty + ",\n");
                        */success = true;
                    }
                    else{
                        Console.WriteLine($"The value for the {properties[i][0]} property can't be empty!\nPress a key...");
                        Console.ReadKey();
                    }    
                }else{
                    if(int.TryParse(stringProperty, out int result)){
                        properties[i][1] = stringProperty;/*
                        if(i == 0)
                            File.AppendAllText(path, "{\n"+properties[i][0]+": "+result+",\n");
                        else if(i == (properties.Length-1))
                            File.AppendAllText(path, properties[i][0]+": "+result + "\n}");
                        else
                            File.AppendAllText(path, properties[i][0] + ": " + result + ",\n");
                        */success = true;
                    }else{
                        Console.WriteLine($"The value for the {properties[i][0]} property must be a valid number!\nPress a key...");
                        Console.ReadKey();
                    }

                }

            }while(!success);
            
        }


        using (StreamWriter sw = new StreamWriter(path)){                           // creazione del file .json e generazione di un nome file
            sw.Write(JsonConvert.SerializeObject(properties, Formatting.Indented));   // numerico progressivo e univoco
        }

        //File.WriteAllText(Path.Combine(CATPATH, item, "fileName.txt"), (cpuFileName+1).ToString());

            
        
    }
}