using NTUtils;
class Program {
    static void Main(string[] args) {
        if (args == null || args.Length == 0) {
            Console.WriteLine("[ERROR] No command entered.");
            Environment.Exit(1);
        }

        switch(args[0]) {
            case "sieve":
                if (args.Length != 2) {
                    Console.WriteLine("[ERROR] Incorrect input format - correct format: sieve [integer]");
                } else if (!args[1].All(Char.IsDigit)) {
                    Console.WriteLine("[ERROR] Input for prime sieve must be a positive integer.");
                } else {
                    int n = Convert.ToInt32(args[1]);
                    List<int> primes = PrimeUtils.PrimeSieve(n);

                    Console.WriteLine(String.Join(", ", primes));
                }
                break;
            default:
                Console.WriteLine("[ERROR] Unrecognized command.");
                break;
        }
    }
}