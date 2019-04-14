using System;
using System.Linq;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms
{
	public class SetClass<T>
	{
		public Vector<T> Data { get; set;}

        public Vector<T> result = new Vector<T>();

        public Vector<T> powersetResult = new Vector<T>();
		public bool Membership(T element) {
			return Data.Contains(element);

		}




		public bool IsSubsetOf(SetClass<T> B) {
			for (int i = 0; i < Data.Count; i++)
			{
				if (B.Data.Contains(Data[i]) == false) return false;
			}
			return true;
		}
		public bool IsSupersetOf(SetClass<T> B) {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data.Contains(B.Data[i]) == false) return false;
            }
            return true;
        }
		public SetClass<SetClass<T>> Powerset() {
            //to get the number of elements to later apply to the (2^n) formula
            int x = Data.Count;

            //bit shifting 
            int setCount = 1 << x;

            //creating a object of setclass
            SetClass<SetClass<T>> resultSetClass = new SetClass<SetClass<T>>();

            //a loop to run x times
            for(int j=0; j< setCount; j++)
            {
                //creating an object of T
                SetClass<T> tempSet = new SetClass<T>();
                for(int i=0; i<x; i++)
                {
                    //checking whether the elements are not null set 
                    if((j & (1<<i)) > 0)
                    {
                        //the values in the tempset is then added to the vector result
                        tempSet.result.Add(Data[i]);
                       //Console.Write(Data[i]);
                    }
                    //Console.WriteLine();
                }
                resultSetClass.powersetResult.Add(tempSet);
            }
           // addresults(resultSetClass);
            return resultSetClass;
            ;}

        //a method to add values to the "result"
        public void addresults(SetClass<SetClass<T>> resultSetClass)
        {
            for(int y = 0; y < resultSetClass.result.Count; y++)
            {
                Console.Write(resultSetClass.result[y].result.ToString());
                Console.WriteLine();
            }
        }
		public SetClass<T> IntersectionWith(SetClass<T> B) {
         
            for(int i = 0; i < B.Data.Count; i++)
            {
                if (Data.Contains(B.Data[i])==true)
                {
                    result.Add(B.Data[i]);
                }
            }

            return null;
        }
		public SetClass<T> UnionWith(SetClass<T> B) {
            //first an object of a set class called union is created to add the values 
            SetClass<T> tempUnionSet = new SetClass<T>();
            for (int i = 0; i < Data.Count; i++)
            {
                //check whether the results in the temp union set contains the values already, if not then the elements of set A are added into the tempunion set result
                if (!(tempUnionSet.result.Contains(Data[i])))
                {
                    tempUnionSet.result.Add(Data[i]);
                }
            }
            //same as above but for set B
            for (int i = 0; i < B.Data.Count; i++)
            {
                if (!(tempUnionSet.result.Contains(B.Data[i])))
                {
                    tempUnionSet.result.Add(B.Data[i]);
                }
            }
            return tempUnionSet;
        }
		public SetClass<T> Difference(SetClass<T> B)
		{
            SetClass<T> tempDifferenceSet = new SetClass<T>();
            //same logic as union set. Checks whether the set A contains the same element in B and if not it is added to the result
            for (int i = 0; i < B.Data.Count; i++)
            {
                if (!Data.Contains(B.Data[i]))
                {
                    tempDifferenceSet.result.Add(B.Data[i]);
                }
            }
            return tempDifferenceSet;
        }
		public SetClass<T> SymmetricDifference(SetClass<T> B)
        {
            //symmetric difference is the union of the two sets excluding the intersection set
            //a set class for symmmetric difference
            SetClass<T> tempSymDif = new SetClass<T>();
            //an object of vector called union which will get the result of the union 
            Vector<T> union = UnionWith(B).result;
            //an object of vector called intersection to get the result of intersection
            Vector<T> intersection = IntersectionWith(B).result;

            for (int i = 0; i < Data.Count; i++)
            {
                if (!(union[i].Equals(intersection[i])))
                {
                    tempSymDif.result.Add(union[i]);
                }
            }
            return tempSymDif;
        }
		public SetClass<T> Complement(SetClass<T> U)
		{
            SetClass<T> tempComplementSet = new SetClass<T>();
            Vector<T> difference = Difference(U).result;

            for (int i = 0; i < U.Data.Count; i++)
            {
                tempComplementSet.result.Add(difference[i]);
            }
            return tempComplementSet;

        }
		public SetClass<Tuple<T, T2>> CartesianProduct<T2>(SetClass<T2> B)
		{
            //creating a vector object of type tuple
            Vector<Tuple<T, T2>> tupleVector = new Vector<Tuple<T, T2>>();

            //the first loop is to run the elements of the first set
            for(int i=0; i< Data.Count; i ++)
            {
            //a nested loop is implemented so that the same element of first set will be multiplied with all the elements in the set B
                for(int j=0; j<B.Data.Count; j++)
                {
                    //new tuple is made to get the products of elements from both the sets and then added to the tuple vector
                    Tuple<T, T2> tempTupleSet = new Tuple<T, T2>(Data[i], B.Data[j]);
                    tupleVector.Add(tempTupleSet);
                }
            }
            //then the tuple vector is added to a set class
			SetClass<Tuple<T,T2>> tupleSetClass = new SetClass<Tuple<T, T2>>(tupleVector);
            return tupleSetClass;
		}

		public SetClass(Vector<T> d)
		{
			Data = d;
		}

        public SetClass()
        {
        }

        //To String method to print values to the result
        public override string ToString()
        {
            string resultOutput = "";

            for(int i =0; i< result.Count; i++)
            {
                resultOutput = string.Format("{0}",result[i]);
            }
            return resultOutput;
        }
    }
}

