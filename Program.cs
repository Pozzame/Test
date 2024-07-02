Random rng = new Random();
int sum = 0;
for ( int i = 0 ; i < 10 ; i++ ) sum =+ rng.Next(10);
Console.WriteLine(sum);
/*
Random rng = new Random();
int sum = 0;
for (int i = 0;i<10;i++) 
{int num =rng.Next(10);
sum += num;
    Console.WriteLine( num +" "+ sum );}
Console.WriteLine(sum);*/