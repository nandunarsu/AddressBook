using System;
using System.Collections.Generic;


namespace AddContact
{
    class Mainmethod
    {
        //public string newmobilenumber { get; }
        static void Main()
        {
            Console.WriteLine("Welcome to AddressBook");

            AddressBook book = new AddressBook();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Address Book Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Delete Contact");
                Console.WriteLine("3. Display Contacts");
                Console.WriteLine("4. Edit Mobile Number");
                Console.WriteLine("5. Save Contacts to File");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            book.AddPerson();
                            break;
                        case 2:
                            Console.WriteLine("Enter the first name to delete:");
                            string firstNameToDelete = Console.ReadLine();
                            book.deletecontact(firstNameToDelete);
                            break;
                        case 3:
                            book.display();
                            break;
                        case 4:
                            Console.WriteLine("Enter the first name to edit mobile number:");
                            string firstNameToEdit = Console.ReadLine();
                            Console.WriteLine("Enter the new mobile number:");
                            string newMobileNumber = Console.ReadLine();
                            book.EditMobileNumber(firstNameToEdit, newMobileNumber);
                            break;
                        case 5:
                            Console.WriteLine("Enter the file name to save contacts:");
                            string fileName = Console.ReadLine();
                            book.SaveToFile(fileName);
                            break;
                        case 6:
                            // Save contacts to a file before exiting if needed
                            // addressBook.SaveToFile("contacts.txt");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }
    }
}