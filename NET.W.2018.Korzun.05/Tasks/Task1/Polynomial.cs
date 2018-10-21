using System;
using System.Text;

namespace Tasks
{
    /// <summary>
    /// Develop an immutable Polynomial class (polynomial) for working with polynomials
    /// of degree from one variable of real type (use sz-array as the internal structure for storing coefficients).
    /// </summary>
    public sealed class Polynomial
    {
        private const double EPSILON = double.Epsilon;

        /// <summary>
        /// The coeffiients of polynomial
        /// </summary>
        public double[] Coefficients { get; private set; }

        /// <summary>
        /// The exponent (order) of polynomial
        /// </summary>
        public int Exponent
        {
            get
            {
                for (int i = Coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(Coefficients[i]) > EPSILON)
                    {
                        return i;
                    }
                }                    
                        
                return 0;
            }
        }

        /// <summary>
        /// Create new polynomial     
        /// </summary>
        /// <param name="coefficients">Array of polynomial coefficients</param>
        public Polynomial(double[] coefficients)
        {
            Coefficients = coefficients;
        }

        /// <summary>
        /// Returns the coefficient at given multiplier
        /// </summary>
        /// <param name="multiplier">Current multiplier</param>
        /// <returns>The coefficient at given multiplier</returns>
        public double this[int multiplier]
        {
            get
            {
                if (multiplier < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(multiplier));
                }

                if (multiplier >= Coefficients.Length)
                {
                    return 0;
                }

                return Coefficients[multiplier];
            }
        }

        #region operations

        /// <summary>
        /// Negation of result of <see cref="operator ==(Polynomial, Polynomial)"/>.
        /// </summary>
        /// <param name="pln1">The first polynomial</param>
        /// <param name="pln2">The second polynomial</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="pln1"/> == null,
        /// <paramref name="pln2"/> == null.
        /// </exception>
        /// <returns>Bool</returns>
        public static bool operator !=(Polynomial pln1, Polynomial pln2)
        {
            if (pln1 is null)
            {
                throw new ArgumentNullException(nameof(pln1));
            }

            if (pln2 is null)
            {
                throw new ArgumentNullException(nameof(pln2));
            }

            return !(pln1 == pln2);
        }

        /// <summary>
        /// Determines whether the <see cref="operator ==(Polynomial, Polynomial)"/> are equal.
        /// </summary>
        /// <param name="pln1">The first polynomial</param>
        /// <param name="pln2">The second polynomial</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="pln1"/> == null,
        /// <paramref name="pln2"/> == null.
        /// </exception>
        /// <returns>Bool</returns>
        public static bool operator ==(Polynomial pln1, Polynomial pln2)
        {
            if (pln1 is null)
            {
                throw new ArgumentNullException(nameof(pln1));
            }

            if (pln2 is null)
            {
                throw new ArgumentNullException(nameof(pln2));
            }

            return pln1.Equals(pln2);
        }

        public static Polynomial operator +(Polynomial pln1, Polynomial pln2)
        {
            int maxLength = 0;
            int minLength = 0;

            if (pln1.Exponent > pln2.Exponent)
            {
                maxLength = 1 + pln1.Exponent;
            }
            else
            {
                maxLength = 1 + pln2.Exponent;
            }

            if (pln1.Exponent < pln2.Exponent)
            {
                minLength = 1 + pln1.Exponent;
            }
            else
            {
                minLength = 1 + pln2.Exponent;
            }

            double[] resultMultipliers = new double[maxLength];
            for (int i = 0; i < minLength; i++)
            {
                resultMultipliers[i] = pln1[i] + pln2[i];
            }               

            if (pln1.Exponent > pln2.Exponent)
            {
                Array.Copy(pln1.Coefficients, minLength, resultMultipliers, minLength, maxLength - minLength);
            }
            else
            {
                Array.Copy(pln2.Coefficients, minLength, resultMultipliers, minLength, maxLength - minLength);
            }               

            return new Polynomial(resultMultipliers);
        }

        public static Polynomial operator -(Polynomial pln1, Polynomial pln2)
        {
            int maxLength = 0;
            int minLength = 0;

            if (pln1.Exponent > pln2.Exponent)
            {
                maxLength = 1 + pln1.Exponent;
            }
            else
            {
                maxLength = 1 + pln2.Exponent;
            }

            if (pln1.Exponent < pln2.Exponent)
            {
                minLength = 1 + pln1.Exponent;
            }
            else
            {
                minLength = 1 + pln2.Exponent;
            }

            double[] resultMultipliers = new double[maxLength];

            for (int i = 0; i < minLength; i++)
            {
                resultMultipliers[i] = pln1[i] - pln2[i];
            }               

            if (pln1.Exponent > pln2.Exponent)
            {
                Array.Copy(pln1.Coefficients, minLength, resultMultipliers, minLength, maxLength - minLength);
            }
            else
            {
                for (int i = minLength; i < maxLength; i++)
                {
                    resultMultipliers[i] = -pln2[i];
                }
            }

            return new Polynomial(resultMultipliers);
        }        

        public static Polynomial operator *(Polynomial pln, int multiplier)
        {
            double[] resultMultipliers = new double[pln.Exponent + 1];

            for (int i = 0; i < pln.Exponent + 1; i++)
            {
                resultMultipliers[i] = pln[i] * multiplier;
            }
               
            return new Polynomial(resultMultipliers);
        }

        public static Polynomial operator *(int multiplier, Polynomial pln)
        {
            return pln * multiplier;
        }

        public static Polynomial operator *(Polynomial pln, double multiplier)
        {
            double[] resultMultipliers = new double[pln.Exponent + 1];

            for (int i = 0; i < pln.Exponent + 1; i++)
            {
                resultMultipliers[i] = pln[i] * multiplier;
            }
               
            return new Polynomial(resultMultipliers);
        }

        public static Polynomial operator *(double multiplier, Polynomial pln)
        {
            return pln * multiplier;
        }

        public static Polynomial operator *(Polynomial pln1, Polynomial pln2)
        {
            int resultOrder = pln1.Exponent + pln2.Exponent + 1;

            double[] resultForces = new double[resultOrder];

            for (int i = 0; i <= pln1.Exponent; i++)
            {
                if (Math.Abs(pln1[i]) > EPSILON)
                {
                    for (int j = 0; j <= pln2.Exponent; j++)
                    {
                        resultForces[i + j] += pln1[i] * pln2[j];
                    }                        
                }
            }

            return new Polynomial(resultForces);
        }

        public static Polynomial operator /(Polynomial pln, int multiplier)
        {
            double[] resultMultipliers = new double[pln.Exponent + 1];

            for (int i = 0; i < pln.Exponent + 1; i++)
            {
                resultMultipliers[i] = pln[i] / multiplier;
            }
               
            return new Polynomial(resultMultipliers);
        }

        public static Polynomial operator /(int multiplier, Polynomial pln)
        {
            return pln / multiplier;
        }

        #endregion

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (i == 0 && Math.Abs(Coefficients[i]) > EPSILON)
                {
                    stringBuilder.AppendFormat($"{Coefficients[i]}");
                    continue;
                }

                if (Math.Abs(Coefficients[i]) > EPSILON)
                {
                    if (Coefficients[i] > 0 && stringBuilder.Length > 0)
                    {
                        stringBuilder.AppendFormat($" + {Coefficients[i]}*x^{i}");
                    }
                    else
                    {
                        stringBuilder.AppendFormat($" {Coefficients[i]}*x^{i}");
                    }
                }                        
            }

            return stringBuilder.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            Polynomial p = obj as Polynomial;

            if (p?.Exponent != Exponent)
            {
                return false;
            }               

            for (int i = 0; i <= Exponent; i++)
            {
                if (Math.Abs(this[i] - p[i]) > EPSILON)
                {
                    return false;
                }                    
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 1;

            foreach (var multiplier in Coefficients)
            {
                hash = hash * (int)multiplier;
                hash = hash + Exponent;
            }

            return hash;
        }
    }
}
