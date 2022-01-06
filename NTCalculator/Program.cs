using NTUtils;
class Program {
    public static string[] commandsHelp = {
        "[sieve n] - return prime numbers up to and including n",
        "[factor n] - return prime factorization of n",
        "[prime n] - return whether n is prime or not",
        "[fermat n] - return fermat factorization of n (odd)",
        "[euler n] - return Euler phi function of n",
        "[numdiv n] - return number of divisors of n",
        "[sumdiv n] - return sum of divisors of n",
        "[clear] - clear screen",
        "[help] - show commands",
        "[exit] - exit application"
    };

    public static  bool exit = false;

    static void Main(string[] args) {
        Console.WriteLine("** NT-CALC - command line calculator for number theory operations **");
        Console.WriteLine("** Use command [help] to view list of commands **");
        Console.WriteLine("** Use command [exit] to exit program **");

        while (!exit) {
            string? inputLine = Console.ReadLine();

            while (inputLine == null) {
                Console.WriteLine("[ERROR] No command specified.");
                inputLine = Console.ReadLine();
            }

            string[] input = inputLine.Split(" ");

            try {
                switch(input[0]) {
                    case "help":
                        if (input.Length > 1) {
                            Console.WriteLine("[ERROR] Unrecognized parameters added to [help] command.");
                        } else {
                            foreach (string c in commandsHelp) {
                                Console.WriteLine(c);
                            }
                        }
                        break;
                    case "clear":
                        if (input.Length > 1) {
                            Console.WriteLine("[ERROR] Unrecognzied parameters added to [clear] command.");
                        } else {
                            Console.Clear();
                        }
                        break;
                    case "exit":
                        if (input.Length > 1) {
                            Console.WriteLine("[ERROR] Unrecognized paramters added to [exit] command.");
                        }
                        exit = true;
                        break;
                    case "sieve":
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("[ERROR] Incorrect input format - correct format: sieve [positive integer]");
                        } else {
                            int n = Convert.ToInt32(input[1]);
                            List<int> primes = PrimeUtils.PrimeSieve(n);
                            Console.WriteLine(String.Join(", ", primes));
                        }
                        break;
                    case "factor":
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("[ERROR] Incorrect input format - correct format: factor [positive integer]");
                        } else {
                            int n = Convert.ToInt32(input[1]);
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
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("ERROR] Incorrect input format - correct format: prime [positive integer]");
                        } else {
                            int n = Convert.ToInt32(input[1]);
                            Console.WriteLine(PrimeUtils.IsPrime(n));
                        }
                        break;
                    case "fermat":
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("[ERROR] Incorrect input format - correct format: fermat [positive odd integer]");
                        } else {
                            long n = Convert.ToInt64(input[1]);
                            Tuple<long, long> factorized = PrimeUtils.FermatFactorization(n);
                            Console.WriteLine($"{factorized.Item1} * {factorized.Item2}");
                        }
                        break;
                    case "euler":
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("[ERROR] Incorrect input format - correct format: euler [positive integer]");
                        } else {
                            int n = Convert.ToInt32(input[1]);
                            Console.WriteLine($"{PrimeUtils.EulerPhi(n)}");
                        }
                        break;
                    case "numdiv":
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("[ERROR] Incorrect input format - correct format: numdiv [positive integer]");
                        } else {
                            int n = Convert.ToInt32(input[1]);
                            Console.WriteLine($"{PrimeUtils.NumOfDivisors(n)}");
                        }
                        break;
                    case "sumdiv":
                        if (input.Length != 2 || !input[1].All(Char.IsDigit)) {
                            Console.WriteLine("[ERROR] Incorrect input format - correct format: sumdiv [positive integer]");
                        } else {
                            int n = Convert.ToInt32(input[1]);
                            Console.WriteLine($"{PrimeUtils.SumOfDivisors(n)}");
                        }
                        break;
                    default:
                        Console.WriteLine("[ERROR] Unrecognized command.");
                        break;
                }
            } catch (ArgumentException e) {
                Console.WriteLine($"[ERROR] {e.Message}");
            } catch (OverflowException) {
                Console.WriteLine($"[ERROR] Input number is too large.");
            }
        }

        return;
    }
}