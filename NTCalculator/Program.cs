using NTUtils;
class Program {
    static void Main(string[] args) {
        if (args == null || args.Length == 0) {
            Console.WriteLine("[ERROR] No command entered.");
            Environment.Exit(1);
        }

        try {
            switch(args[0]) {
                case "sieve":
                    if (args.Length != 2 || !args[1].All(Char.IsDigit)) {
                        Console.WriteLine("[ERROR] Incorrect input format - correct format: sieve [positive integer]");
                    } else {
                        int n = Convert.ToInt32(args[1]);
                        List<int> primes = PrimeUtils.PrimeSieve(n);

                        Console.WriteLine(String.Join(", ", primes));
                    }
                    break;
                case "factor":
                    if (args.Length != 2 || !args[1].All(Char.IsDigit)) {
                        Console.WriteLine("[ERROR] Incorrect input format - correct format: factor [positive integer]");
                    } else {
                        int n = Convert.ToInt32(args[1]);
                        Dictionary<int, int> factors = PrimeUtils.PrimeFactorization(n);

                        List<string> formattedFactors = new List<string>();
                        foreach (KeyValuePair<int, int> factor in factors) {
                            if (factor.Value == 1) {
                                formattedFactors.Add(factor.Key.ToString());
                            } else {
                                formattedFactors.Add($"{factor.Key}^{factor.Value}");
                            }
                        }

                        Console.WriteLine(String.Join(" * ", formattedFactors));
                    }
                    break;
                case "prime":
                    if (args.Length != 2 || !args[1].All(Char.IsDigit)) {
                        Console.WriteLine("[ERROR] Incorrect input format - correct format: prime [positive integer]");
                    } else {
                        int n = Convert.ToInt32(args[1]);
                        Console.WriteLine(PrimeUtils.IsPrime(n));
                    }
                    break;
                case "fermat":
                    if (args.Length != 2 || !args[1].All(Char.IsDigit)) {
                        Console.WriteLine("[ERROR] Incorrect input format - correct format: fermat [positive odd integer]");
                    } else {
                        long n = Convert.ToInt64(args[1]);
                        Tuple<long, long> factorized = PrimeUtils.FermatFactorization(n);
                        Console.WriteLine($"{factorized.Item1} * {factorized.Item2}");
                    }
                    break;
                case "euler":
                    if (args.Length != 2 || !args[1].All(Char.IsDigit)) {
                        Console.WriteLine("[ERROR] Incorrect input format - correct format: euler [positive integer]");
                    } else {
                        int n = Convert.ToInt32(args[1]);
                        Console.WriteLine($"{PrimeUtils.EulerPhi(n)}");
                    }
                    break;
                default:
                    Console.WriteLine("[ERROR] Unrecognized command.");
                    break;
            }
        } catch (ArgumentException e) {
            Console.WriteLine($"[ERROR] {e.Message}");
        } catch (OverflowException) {
            Console.WriteLine("[ERROR] Input number is too large.");
        }
    }
}