using System;

namespace Events
{
   public  class Program
    {
       public static void Main(string[] args)
        { 
          var dealer = new CarDealer();
        
        var michael = new Consumer("Michael");
        // attach a listener to and event - use the += notation
        dealer.NewCarEvent += michael.NewCarIsHere;
        dealer.NewCar("Ferrari");
        dealer.NewCarEvent -= michael.NewCarIsHere;

        var nick = new Consumer("Sebastian");
        dealer.NewCarEvent += nick.NewCarIsHere;
        dealer.NewCar("Mercedes");
        dealer.NewCarEvent -= nick.NewCarIsHere;
        dealer.NewCar("Red Bull Racing");
    }
}

public class Consumer
{
    private string name;
    public Consumer(string name)
    {
        this.name = name;
    }

    public void NewCarIsHere(object sender, CarInfoEventArgs e)
    {
        Console.WriteLine("{0}: car {1} is new", name, e.Car);
    }
}

public class CarInfoEventArgs : EventArgs
{
    public CarInfoEventArgs(string car)
    {
        this.Car = car;
    }

    public string Car { get; private set; }
}

public delegate void CarEvent(object sender, CarInfoEventArgs e);

public class CarDealer
{
    public event CarEvent NewCarEvent;
    public void NewCar(string car)
    {
        Console.WriteLine("CarDealer got a new car {0}", car);
        RaiseNewCarEvent(car);
    }
    protected virtual void RaiseNewCarEvent(string car)
    {
        if (NewCarEvent != null)
        {
            NewCarEvent(this, new CarInfoEventArgs(car));
        }
    }
}