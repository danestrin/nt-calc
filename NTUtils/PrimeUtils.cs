namespace NTUtils;
public static class PrimeUtils
{
    public static List<int> PrimeSieve(int n) {
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
}
