using System;
using System.Collections.Generic;

class Contact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

class Program
{
    static List<Contact> contacts = new List<Contact>();

    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Contact Management System");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. List Contacts");
            Console.WriteLine("3. Search Contacts");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ListContacts();
                        break;
                    case 3:
                        SearchContacts();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    static void AddContact()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();
        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();

        Contact contact = new Contact
        {
            Name = name,
            Email = email,
            Phone = phone
        };

        contacts.Add(contact);
        Console.WriteLine("Contact added successfully.");
    }

    static void ListContacts()
    {
        Console.WriteLine("List of Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.Phone}");
        }
    }

    static void SearchContacts()
    {
        Console.Write("Enter a search term: ");
        string searchTerm = Console.ReadLine();

        var searchResults = contacts.FindAll(contact =>
            contact.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            contact.Email.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            contact.Phone.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
        );

        if (searchResults.Count > 0)
        {
            Console.WriteLine("Search Results:");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"Name: {result.Name}, Email: {result.Email}, Phone: {result.Phone}");
            }
        }
        else
        {
            Console.WriteLine("No matching contacts found.");
        }
    }
}
