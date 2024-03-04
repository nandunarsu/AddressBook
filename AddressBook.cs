using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddContact
{
    class AddressBook
    {
        public List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }

        public void AddPerson()
        {
           
                    Console.WriteLine("Enter the first Name :");
                    string FirstName = Console.ReadLine();
                    Console.WriteLine("Enter the Last Name :");
                    string LastName = Console.ReadLine();
                    Console.WriteLine("Enter the Email Name :");
                    string Email = Console.ReadLine();
                    Console.WriteLine("Enter the Address ");
                    string Address = Console.ReadLine();
                    Console.WriteLine("Enter the City ");
                    string City = Console.ReadLine();
                    Console.WriteLine("Enter the Zipcode:");
                    int zipcode = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Phone Number");
                    string Phone = Console.ReadLine();
                    Contact c1 = new Contact(FirstName, LastName, Email, Address, City, zipcode, Phone);
            if (!contacts.Contains(c1))
            {
                if (ValidateEntry(c1))
                {
                    contacts.Add(c1);
                    Console.WriteLine($"Person added to address book: {c1.FirstName}");
                }
                else
                {
                    Console.WriteLine("Please check the input fields");
                }
            }
            else
            {
                Console.WriteLine($"Duplicate entry found for: {c1.FirstName}");
            }
        } 
        
        public void deletecontact(string firstname)
        {
            Contact removedcontact = null;
            foreach (Contact cont in contacts)
            {
                if (cont.FirstName == firstname)
                {
                    removedcontact = cont;
                    break;
                }

            }
            if (removedcontact != null)
            {
                contacts.Remove(removedcontact);
                Console.WriteLine($"Contact with first name '{firstname}'has been removed.");
            }
            else
            {
                Console.WriteLine("The data not found");
            }
        }
        public  void display()
        {
            LoadFromFile("C:\\cd\\file.txt");
            foreach (Contact cont in contacts)
            {
                Console.WriteLine();
                Console.WriteLine($"{cont.FirstName}:{cont.LastName}:{cont.Email}:{cont.Address}:{cont.City}:{cont.zipcode}:{cont.Phone}");
            }
        }
        public  void  EditMobileNumber(string firstname, string newmobileNumber)


        {
            foreach (Contact cont in contacts)
            {
                if (cont.FirstName == firstname)
                {
                    cont.Phone = newmobileNumber;
                }
            }
        }

        public bool ValidateEntry(Contact person)
        {
            Func<string, bool> isValidName = (name) => !string.IsNullOrWhiteSpace(name);
            Func<string, bool> isValidEmail = (email) => Regex.IsMatch(email, @"^[a-zA-z0-9]{4,20}@\w+\.+com$");
            Func<string, bool> isValidMobile = (mobile) => Regex.IsMatch(mobile, @"^[6789]{1}[0-9]{9}$");
            //Func<string, bool> isValidPassword = (password) => password.Length >= 8;

            return isValidName(person.FirstName) && isValidEmail(person.Email) && isValidMobile(person.Phone);
        }

        public void SaveToFile(string Filename)
        {
            using(StreamWriter sw = new StreamWriter(Filename))
            {
                foreach(Contact cont in contacts)
                {
                    sw.WriteLine($"{cont.FirstName}:{cont.LastName}:{cont.Email}:{cont.Address}:{cont.City}:{cont.zipcode}:{cont.Phone}");
                }
            }
        }
        public void LoadFromFile(string Filename)
        {
            if (!File.Exists(Filename))
            {
                Console.WriteLine("File note found");
                return;
            }
            using(StreamReader sr = new StreamReader(Filename))
            {
                string line;
                while((line = sr.ReadLine())!= null)
                {
                    string[] parts = line.Split(',');
                    if(parts.Length == 7)
                    {
                        string FirstName = parts[0];
                        string LastName = parts[1];
                        string Email = parts[2];
                        string Address = parts[3];
                        string City = parts[4];
                        int zipcode = int.Parse(parts[5]);
                        string Phone = parts[6];

                        Contact contact  = new Contact(FirstName,LastName,Email,Address,City,zipcode,Phone);
                        contacts.Add(contact);
                    }
                }
            }
        }

    }
}
