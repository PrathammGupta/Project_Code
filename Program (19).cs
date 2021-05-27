using System;
using System.Collections.Generic;
namespace newprogram
{

public enum menuoption
{
    Adminuser,
    Customeruser,
    create_customer_account,

    create_admin_account,
    quit
    
}
public enum adminmenu
{
    update_movie_details,
    update_product_details,
    update_railway_details,
    Quit
}
public enum order_type{
    movieticket,
    railawayticket,
    buyproduct
}
public struct movie{
    public string movie_name;
    public string movie_language;
    public string movie_slot;

}
interface validate_user
{
    bool validate_user (string name, string password);
}
interface log_error{
    void log_error(String prompt);
}
public class Person{
    private String _name;
    private int _age;
    private string _mobilenumber;
    private string _city_address;
    private string _login_password;
    public string mobilenumber{get {return _mobilenumber;}set{_mobilenumber=value;}}
    public string city_address{get {return _city_address;}set{_city_address=value;}}

    public string login_password{get {return _login_password;}set{_login_password=value;}}
    public int age{get{return _age;}set{_age=value;}}
    public string name{get{return _name;}set{_name=value;}}
    public Person(string name,int _age,string mobilenumber,string city_address, string login_password)
    {   

        this.name= name;
        this._age=age;
        this.mobilenumber=mobilenumber;
        this.city_address=city_address;
        _login_password= login_password;
    }
    
        
 

}
public class Admin:Person,validate_user, log_error
{   

    public Admin(string name, int age, string mobilenumber,string city_address,string login_password): base(name,age,mobilenumber,city_address,login_password)
    {
           
    }
    public bool validate_user(string nameuser,string _password)
    {
          if(nameuser.ToLower()== name && _password==login_password)
          {
                return true;
          }
          return false; 
    }
    public void log_error(string prompt){ 
            Console.WriteLine(prompt);
    }
    public void update_product(Company c)
    { 

    }
    public void update_movie_details(Company c)
    {
         
         
    } 
    public void update_railway_details()
    {

    }

    public void admin_menu(Company c)
    {
    
    }
    
}
public class Customer:Person,validate_user
{
    public Customer(string name, int age, string mobilenumber,string city_address,string login_password): base(name,age,mobilenumber,city_address,login_password)
    {
           
    }
    public bool validate_user(string nameuser,string _password)
    {
          if(nameuser.ToLower()== name && _password==login_password)
          {
                return true;
          }
          return false; 
    }
     public void log_error(string prompt){ 
            Console.WriteLine(prompt);
    }
    public void getproduct()
    {

    }
    public void get_movieticket()
    {

    }
    public void get_railwayticket()
    {

    }
   
}
public abstract class Order
{
    public order_type order;
    public decimal order_price;
    public abstract void print_statement();
    public abstract void ask_payment();
    
    public Order(order_type order)/*, decimal order_price)*/
    {
        this.order=order;
        //this.order_price=order_price;
    }



}
public class Movie_ticket: Order{

    movie movie_details;
    public Movie_ticket(order_type order, decimal price):base(order)//order_type.movieticket)
    {   
        order_price=price;
        order = order_type.movieticket;

      
    }
    public override void print_statement()
    {

    }
    public override void ask_payment()
    {
        
    }
}
public class Railwayticket: Order{
    public string from_station;
    public string to_station;
    public int seat_no;

    public Railwayticket(string from_station, string to_station,decimal ticket_price):base(order_type.railawayticket)
    {   
        Random random= new Random();
        this.from_station=from_station;
        this.to_station=to_station;
        this.seat_no= random.Next(1000);
        order_price= ticket_price;
    }
    public override void print_statement()
    {

    }
    public override void ask_payment()
    {
        
    }
}
public class Product: Order{
    public string product_name;
    public string product_type;
    public Product(string product_name, string product_type, decimal product_price):base(order_type.buyproduct)
    {
        this.product_name= product_name;
        this.product_type= product_type;
        order_price=product_price;
        order = order_type.buyproduct;
    }
    public override void print_statement()
    {

    }
    public override void ask_payment()
    {
        
    }
    
}
public class Company
{   
    public string companyname; 
    public Company(String companyname)
    {
       this.companyname=companyname;
       this.Add_stock();
    }
     public List<Product> product_list= new List<Product>();
     public List<movie> movies= new List<movie>();
     public List<Customer> customers=new List<Customer>();
     public List<Railwayticket> tickets= new List<Railwayticket>();
     public List<Admin> admins= new List<Admin>();
     public void show_productlist()
     {
         Console.WriteLine(" Products available in the stock are: ");
         for(int i=0; i<product_list.Count; i++)
         {
             Console.WriteLine((i+1).ToString()+" "+product_list[i].product_type+" --> "+product_list[i].product_name);

         }
     }
     public void show_movieslist()
     {   
         
         Console.WriteLine(" Movies available for booking are: ");
         for(int i=0; i<movies.Count; i++)
         {
             Console.WriteLine((i+1).ToString()+" "+movies[i].movie_language+" --> "+movies[i].movie_name);

         }
     }
     public void show_railwaylist()
     {   
         
         Console.WriteLine(" Tickets available for booking are: ");
         for(int i=0; i<movies.Count; i++)
         {
             Console.WriteLine((i+1).ToString()+" From "+tickets[i].from_station+" --> TO "+tickets[i].to_station);

         }
     }
     public void add_admin_account(Admin a)
     {
             admins.Add(a);  
     }
     public void add_customer_account(Customer c)
     {
             customers.Add(c);  
     }
     public Admin check_admin_account(string name,string password)
     {
          
                for(int i=0; i<admins.Count; i++)
                {
                    if(name.ToLower()== admins[i].name.ToLower() && password== admins[i].login_password)
                    {
                        return admins[i];
                    }
            
                }
                return null;
            
           
     }
     public movie initialize_movie(string name, string language,string slot)
     {
         movie movie;
         movie.movie_name=name;
         movie.movie_language=language;
         movie.movie_slot=slot;
         return movie;
     }
     public void Add_stock()
     {       
          Random random= new Random();
            movie m1= initialize_movie("KGF","Tamil","9am to 12pm");
            movie m2= initialize_movie("SANJU","HINDI","12pm to 3pm");
            movie m3= initialize_movie("Housefull 4","HINDI","3pm to 6pm");
            movie m4= initialize_movie("Avengers Endgame","English","9am to 12pm");
            movies.Add(m1);
            movies.Add(m2);
            movies.Add(m3);
            movies.Add(m4);
            
            Product p1= new Product("Samsung Galaxy","Mobile",random.Next(30000,40000));
            Product p2= new Product("Apple watch","Watch",random.Next(15000,25000));
            Product p3= new Product("Sony 32 inches","LED",random.Next(50000,60000));
            product_list.Add(p1);
            product_list.Add(p2);
            product_list.Add(p3);

            Railwayticket r1= new Railwayticket("Delhi", "Chandigarh",random.Next(1500,2000));
            Railwayticket r2= new Railwayticket("Jaipur", "Bengaluru",random.Next(1200,1400));
            Railwayticket r3= new Railwayticket("Mumbai", "Goa", random.Next(1000,1200));
            tickets.Add(r1);
            tickets.Add(r2);
            tickets.Add(r3);





        
     }
     public Customer check_customer_account(string name,string password)
     {       
                for(int i=0; i<customers.Count; i++)
                {
                    if(name.ToLower()== customers[i].name.ToLower() && password== customers[i].login_password)
                    {
                        return customers[i];
                    }
            
                }
            
            return null;
     }

}

   

    class Program
    {    
        public static string read_string(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }



        
           
        public static menuoption user_input()
        {
            Console.WriteLine("1.  LOGIN As a Admin");
            Console.WriteLine("2.  LOGIN As a Customer");
            Console.WriteLine("3.  Create account as Customer");
            Console.WriteLine("4.  Create account as Admin");
            Console.WriteLine("5.  QUIT");
            return(menuoption)(Convert.ToInt32(Console.ReadLine())-1);


        }
        
        static void Main(string[] args)
        {    
             Company company=new Company("Amazon");
             Console.WriteLine(" Welcome to "+company.companyname);
                 menuoption menu;
                 string name, password;
                
           do{
                
             menu= user_input();
             switch(menu)
             {   
                 
                 case menuoption.Adminuser:
                 {
                    name=read_string("Name");
                    password=read_string("Password");
                    if( company.check_admin_account(name, password)==null)
                    {
                      Console.WriteLine("Invalid Username or Password");
                    }
                    else{
                       
                         Admin ad_acc=company.check_admin_account(name, password);
                        
                         if(ad_acc.validate_user(name,password))
                         {
                             Console.WriteLine("Successfully login");
                             ad_acc.admin_menu(company);

                         }
                         else{
                             Console.WriteLine("Login failed");
                         }

                    }
                    break;

                    
                 }
                 
                 
                  case menuoption.Customeruser:
                 {
                    name=read_string("Name");
                    password=read_string("Password");
                    if( company.check_customer_account(name, password)== null)
                    {
                      Console.WriteLine("Invalid username or Password");
                    }
                    else{
                      

                        Customer cs_acc=company.check_customer_account(name, password);
                      
                        
                         if(cs_acc.validate_user(name,password))
                         {
                             Console.WriteLine("Successfully login");

                         }
                         else{
                             Console.WriteLine("Login failed");
                         }

                    }
                    break;
                 }
                 
                 case menuoption.create_admin_account:
                 {   
                      
                     Admin admin= new Admin(read_string("Name- "),Convert.ToInt32(read_string("Age- ")),read_string("Mobile number- "),read_string("City_address- "),
                     read_string("Password- "));
                    company.add_admin_account(admin);   
                    


                     break;
                 }
                 case menuoption.create_customer_account:
                 {
                      Customer c= new Customer(read_string("Name- "),Convert.ToInt32(read_string("Age- ")),read_string("Mobile number- "),read_string("City_address- "),
                      read_string("Password- "));
                      
                                                 
                      company.add_customer_account(c);


                     break;
                 }




             }
























           }while(menu != menuoption.quit);
            

























        }
    }

}
