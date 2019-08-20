using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomial
{
    public sealed class Polynomial
    {
        private int[] membersOfPolynomial;

        public Polynomial()
        {
            throw new Exception("Polynomial can't be empty, enter at least one value");
        }
        public Polynomial( params int[] members)
        {
            Array.Reverse(members);
            this.membersOfPolynomial = members;
        }

        public override string ToString()
        {
            string str = "";
            for(int i = membersOfPolynomial.Length -1; i > 0; i-- )
            {
                if (membersOfPolynomial[i] != 0)
                {
                    if(membersOfPolynomial[i] != 1)
                        str += membersOfPolynomial[i] + "x^" + i+ " + ";
                    else
                        str += "x^" + i  + " + "; 
                }
            }

            str += membersOfPolynomial[0];
            return str;
        }
        public override int GetHashCode()
        {

            double hashCode = SumPolinom();                 // SumPolinom needed in order  to 
                                                                // in order to calculate hash code and not go beyond int
            return Convert.ToInt32(Math.Ceiling(hashCode));
        }
        public override bool Equals(object obj)
        {

            if (obj == null)
                return false;
            Polynomial polinom = obj as Polynomial;
            if (object.ReferenceEquals(this, polinom))
                return true;
            else if (this.membersOfPolynomial.Length != polinom.membersOfPolynomial.Length)
                return false;
            else if (this.SumPolinom() != polinom.SumPolinom())
                return false;
            else
            {
                for(int i = 0; i < this.membersOfPolynomial.Length; i++)
                {
                    if (this.membersOfPolynomial[i] != polinom.membersOfPolynomial[i])
                        return false;
                }
            }
            return true;
            
        }
        private double SumPolinom()
        {

            //just an algorithm invented by me

            double sum = 0;
            for (int i = 0; i < membersOfPolynomial.Length; i++)
            {
                if (membersOfPolynomial[i] != 0)
                    sum += (double)membersOfPolynomial[i] * (i+1);
            }
            if (sum < Int32.MaxValue / membersOfPolynomial.Length)
                return sum;
            return sum / (membersOfPolynomial.Length*membersOfPolynomial.Length);
        }

        public static Polynomial operator * (Polynomial p1, Polynomial p2)
        {
            int[] arr3 = new int[p1.membersOfPolynomial.Length + p2.membersOfPolynomial.Length - 1];
            for(int i = 0; i < p1.membersOfPolynomial.Length; i++)
            {
                for(int j = 0; j < p2.membersOfPolynomial.Length; j++)
                {
                    arr3[i + j] += p1.membersOfPolynomial[i] * p2.membersOfPolynomial[j]; 
                }
            }
            Array.Reverse(arr3); // Reverse for better reader from ToString()
            return new Polynomial(arr3);
        }

        public static Polynomial operator - (Polynomial p1, Polynomial p2)
        {

            // two cases :
            //first: when the first polynomial is bigger second and i subtract the second from  the first  
            if ( p1.membersOfPolynomial.Length > p2.membersOfPolynomial.Length)
            {

                double check = Int32.MinValue;
                int[] arr3 = new int[p1.membersOfPolynomial.Length];
                for (int i = 0; i < p2.membersOfPolynomial.Length; i++)
                {
                    if (check > (double)p1.membersOfPolynomial[i] + (double)p2.membersOfPolynomial[i]) // check overflow
                        throw new OverflowException("number less than int.min");
                    arr3[i] = p1.membersOfPolynomial[i] - p2.membersOfPolynomial[i];
                }

                for(int i = p2.membersOfPolynomial.Length; i < p1.membersOfPolynomial.Length; i++)
                {
                    arr3[i] = p1.membersOfPolynomial[i];
                }
                Array.Reverse(arr3);
                return new Polynomial(arr3);

            }
            //opposite case
            else
            {
                double check = Int32.MinValue;
                int[] arr3 = new int[p2.membersOfPolynomial.Length];
                for (int i = 0; i < p1.membersOfPolynomial.Length; i++)
                {
                    if (check > (double)p1.membersOfPolynomial[i] + (double)p2.membersOfPolynomial[i]) // check overflow
                        throw new OverflowException("number less than int.min");
                    arr3[i] = p1.membersOfPolynomial[i] - p2.membersOfPolynomial[i];
                }

                for (int i = p1.membersOfPolynomial.Length; i < p2.membersOfPolynomial.Length; i++)
                {
                    arr3[i] = -p2.membersOfPolynomial[i];
                }
                Array.Reverse(arr3);
                return new Polynomial(arr3);
            }
            
        }
        public static Polynomial operator + (Polynomial p1, Polynomial p2)
        {
            double check = Int32.MaxValue;
            if (p1.membersOfPolynomial.Length > p2.membersOfPolynomial.Length)
            {
                int[] arr3 = new int[p1.membersOfPolynomial.Length];
                for (int i = 0; i < p2.membersOfPolynomial.Length; i++)
                {
                    if (check < (double)p1.membersOfPolynomial[i] + (double)p2.membersOfPolynomial[i]) // check overflow
                        throw new OverflowException("number greater than int.max");
                    arr3[i] = p1.membersOfPolynomial[i] + p2.membersOfPolynomial[i];
                }

                for (int i = p2.membersOfPolynomial.Length; i < p1.membersOfPolynomial.Length; i++)
                {
                    arr3[i] = p1.membersOfPolynomial[i];
                }
                Array.Reverse(arr3);
                return new Polynomial(arr3);

            }
            else
            {
                int[] arr3 = new int[p2.membersOfPolynomial.Length];
                for (int i = 0; i < p1.membersOfPolynomial.Length; i++)
                {
                    if (check < (double)p1.membersOfPolynomial[i] + (double)p2.membersOfPolynomial[i])
                        throw new OverflowException("number greater than int.max");   // check overflow
                    arr3[i] = p1.membersOfPolynomial[i] + p2.membersOfPolynomial[i];
                }

                for (int i = p1.membersOfPolynomial.Length; i < p2.membersOfPolynomial.Length; i++)
                {
                    arr3[i] = p2.membersOfPolynomial[i];
                }
                Array.Reverse(arr3);
                return new Polynomial(arr3);
            }
        }


        public static bool operator == (Polynomial p1, Polynomial p2)
        {
            
            return p1.Equals(p2);
        }
        
        public static bool operator != (Polynomial p1,  Polynomial p2)
        {
            return !p1.Equals(p2);
        }
    }

    
}
