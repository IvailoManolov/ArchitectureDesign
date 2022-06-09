using System;

namespace AbstractFactory
{
    //The abstract factory interface declares a set of methods that return different
    // abstract products. These products are called a family and are related by a high-level
    // theme or conecept. Products of one family are usually able to collaborate among themselves.'
    // A family of products may have several variants, but the products of one variant are incompatible with products of another.

    public interface IAbstractFactory
    {
        IAbstractProductA CreateProductA();
        IAbstractProductB CreateProductB();
    }

    // Concrete Factories produce a family of products that belong to a single variant. 
    // The factory guarantees that resulting rpoducts are compatible.
    // Note that signatures of the Concrete Factory's methods return an abstract product
    // while inside the method a concrete product, is instantiated.

    class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA1();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB1();
        }
    }

    //Each concrete factory has a corresponding product variant.
    class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractProductA CreateProductA()
        {
            return new ConcreteProductA2();
        }

        public IAbstractProductB CreateProductB()
        {
            return new ConcreteProductB2();
        }
    }

    //Each distinct product of a product family should have a base interface.
    //All variants of the product must implement this interface.

    public interface IAbstractProductA
    {
        string UsefulFunctionA();
    }

    //Concrete products are created by corresponding Concrete Factories.
    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            Console.WriteLine("Very Useful ProductA1");
            return null;
        }
    }

    class ConcreteProductA2 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            Console.WriteLine("Very useful ProductA2");
            return null;
        }
    }

    public interface IAbstractProductB
    {
        string UsefulFunctionB();
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }

    class ConcreteProductB1 : IAbstractProductB
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var result = collaborator.UsefulFunctionA();
            Console.WriteLine(" Another useful from B1 with collab ");
            return null;
        }

        public string UsefulFunctionB()
        {

            Console.WriteLine("Very useful function B1");
            return null;
        }
    }

    class ConcreteProductB2 : IAbstractProductB
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            var a = collaborator.UsefulFunctionA();
            Console.WriteLine("Useful funtion with collab from B2");
            return null;
        }

        public string UsefulFunctionB()
        {
            Console.WriteLine("Useful function from B2");
            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client testing client code with first factory");
            ClientMethod(new ConcreteFactory1());
            Console.WriteLine("Client testing client code with first factory");
            ClientMethod(new ConcreteFactory2());
        }

        private static void ClientMethod(IAbstractFactory concreteFactory1)
        {
            var productA = concreteFactory1.CreateProductA();
            var productB = concreteFactory1.CreateProductB();

            productA.UsefulFunctionA();
            productB.AnotherUsefulFunctionB(productA);
        }
    }
}
