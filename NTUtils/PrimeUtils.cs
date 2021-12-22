﻿namespace NTUtils;
public static class PrimeUtils
{
    public static List<int> PrimeSieve(int n) {
        if (n == 0 || n == 1) {
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
        if (n == 0) {
            throw new ArgumentException("Cannot do prime factorization on 0.");
        }
        Dictionary<int, int> factors = new Dictionary<int, int>() {
            {1, 1}
        };
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
}
