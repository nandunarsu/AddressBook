using System;
using System.Xml.Linq;

namespace AddContact
{
    public class Contact{

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }  
        public string City { get; set; }
        public int zipcode { get; set; }    
        public string Phone { get; set; }

        public Contact(string firstname,string lastname,string email,string address,string city,int zip,string phone)
        {
            FirstName = firstname; 
            LastName = lastname;
            Email = email;
            Address = address;
            City = city;
            zipcode = zip;
            Phone = phone;
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Email: {Email}, City: {City},Address : {Address}, Zip Code: {zipcode}, Phone Number: {Phone}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return FirstName.Equals(((Contact)obj).FirstName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
            //return HashCode.Combine(this.FirstName, this.LastName);
        }




    }
}