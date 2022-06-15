using System;
using System.Collections.Generic;

namespace ArchitectureBuilderPattern
{

    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildPartA()
        {
            this._product.Add("PartA1");
        }

        public void BuildPartB()
        {
            this._product.Add("PartB1");
        }

        public void BuildPartC()
        {
            this._product.Add("PartC1");
        }

        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", "; 
            }

            str = str.Remove(str.Length - 2); //Removing the last ,c

            return str;
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set
            {
                _builder = value;
            }
        }

        public void BuildMinimalProduct()
        {
            _builder.BuildPartA();
        }

        public void BuildFullProduct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting program ... ");
            var director = new Director();
            var concreteBuilder = new ConcreteBuilder();
            director.Builder = concreteBuilder;

            director.BuildMinimalProduct();

            Console.WriteLine("Results : ");
            Console.WriteLine(concreteBuilder.GetProduct().ListParts());

            director.BuildFullProduct();

            Console.WriteLine("Results : ");

            Console.WriteLine(concreteBuilder.GetProduct().ListParts());
        }
    }
}
