using NTUtils;
class Program {
    static void Main(string[] args) {
        Console.WriteLine("Find prime numbers up to and including n.");

        Console.WriteLine("Enter n.");
        int n = Convert.ToInt32(Console.ReadLine());

        List<int> primes = PrimeUtils.PrimeSieve(n);

        Console.WriteLine($"Prime numbers up to and including {n}:");
        Console.WriteLine(String.Join(", ", primes));

        Console.Write("Press any key to exit.");
        Console.ReadKey();
    }
}