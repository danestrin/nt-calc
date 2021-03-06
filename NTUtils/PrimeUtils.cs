namespace NTUtils;
public static class PrimeUtils
{
    public static List<int> PrimeSieve(int n) {
        if (n < 0) {
            throw new ArgumentException("Prime sieve can only be called on positive integers.");
        } else if (n == 0 || n == 1) {
            return new List<int>();
        }

        int[] sieve = new int[n + 1];
        sieve[0] = 1;
        sieve[1] = 1;

        for (int i = 2; i*i <= n; i++) {
            if (sieve[i] != 1) {
                int j = i + i;
                while (j <= n) {
                    sieve[j] = 1;
                    j += i;
                }
            }
        }

        var primes = new List<int>();

        for (int i = 2; i < sieve.Length; i++) {
            if (sieve[i] == 0) {
                primes.Add(i);
            }
        }

        return primes;
    }

    public static Dictionary<int, int> PrimeFactorization(int n) {
        if (n <= 0) {
            throw new ArgumentException("Prime factorization can only be called on positive integers.");
        }
        Dictionary<int, int> factors = new Dictionary<int, int>();
        List<int> potentialPrimes = PrimeUtils.PrimeSieve((int) Math.Floor(Math.Sqrt(n)));
        potentialPrimes.Add(n);

        while (n != 1) {
            foreach (int p in potentialPrimes.ToList<int>()) {
                if (n % p == 0) {
                    if (factors.ContainsKey(p)) {
                        factors[p] += 1;
                    } else {
                        factors[p] = 1;
                    }
                    n = n / p;
                    potentialPrimes.Add(n);
                }
            }
        }

        return factors;
    }

    public static bool IsPrime(int n) {
        if (n < 0) {
            throw new ArgumentException("Prime testing can only be called on positive integers.");
        }
        if (n == 0 || n == 1 || n > 2 && n % 2 == 0) {
            return false;
        }

        List<int> testPrimes = PrimeUtils.PrimeSieve((int) Math.Floor(Math.Sqrt(n)));

        foreach (int p in testPrimes.ToList<int>()) {
            if (n % p == 0) {
                return false;
            }
        }

        return true;
    }

    public static Tuple<long, long> FermatFactorization(long n) {
        if (n < 0 || n % 2 == 0) {
            throw new ArgumentException("Fermat Factorization can only be called on odd positive integers.");
        }

        long t = (long) Math.Ceiling(Math.Sqrt(n));
        long diff = t*t - n;

        while (Math.Sqrt(diff) % 1 != 0) {
            t = t + 1;
            diff = t*t - n;
        }

        long s = (long) Math.Sqrt(diff);
        return Tuple.Create(t + s, t - s);
    }

    public static int EulerPhi(int n) {
        if (n < 0) {
            throw new ArgumentException("Euler Phi function can only be called on positive integers.");
        } else if (n == 0) {
            return 0;
        } else if (n == 1) {
            return 1;
        }

        Dictionary<int, int> factors = PrimeUtils.PrimeFactorization(n);
        int product = 1;

        foreach(KeyValuePair<int, int> factor in factors) {
            int term = (int) Math.Pow(factor.Key, factor.Value - 1) * (factor.Key - 1);
            product = product * term;
        }

        return product;
    }

    public static int NumOfDivisors(int n) {
        if (n <= 0) {
            throw new ArgumentException("Number of Divisors function can only be called on positive integers.");
        } else if (n == 1) {
            return 1;
        }

        Dictionary<int, int> factors = PrimeUtils.PrimeFactorization(n);

        int product = 1;
        foreach (KeyValuePair<int, int> factor in factors) {
            int term = factor.Value + 1;
            product = product * term;
        }

        return product;
    }

    public static int SumOfDivisors(int n) {
        if (n <= 0) {
            throw new ArgumentException("Sum of Divisors function can only be called on positive integers.");
        } else if (n == 1) {
            return 1;
        }

        Dictionary<int, int> factors = PrimeUtils.PrimeFactorization(n);

        if (factors.Count == 1 && factors.First().Value == 1){
            return factors.First().Key + 1;
        }
        
        int product = 1;
        foreach (KeyValuePair<int, int> factor in factors) {
            int term = (int) (Math.Pow(factor.Key, factor.Value + 1) - 1) / (factor.Key - 1);
            product = product * term;
        }

        return product;
    }
}
