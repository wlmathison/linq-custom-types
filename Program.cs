﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_custom_types
{
    // Build a collection of customers who are millionaires
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    // Define a bank
    public class Bank
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }

    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

            // Create some customers and store in a List
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            /*
                You will need to use the `Where()`
                and `Select()` methods to generate
                instances of the following class.
            */

            List<Customer> millionares = customers.Where(customer => customer.Balance >= 1000000).ToList();

            List<ReportItem> millionaireReport = millionares.OrderBy(customer => customer.Name.Split(" ")[1]).Join(banks, customer => customer.Bank, bank => bank.Symbol, (customer, bank) => new ReportItem
            {
                CustomerName = customer.Name,
                BankName = bank.Name
            }).ToList();

            foreach (var item in millionaireReport)
            {
                Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            }
        }
        /*
        TASK:
        As in the previous exercise, you're going to output the millionaires,
        but you will also display the full name of the bank. You also need
        to sort the millionaires' names, ascending by their LAST name.

        Example output:
            Tina Fey at Citibank
            Joe Landy at Wells Fargo
            Sarah Ng at First Tennessee
            Les Paul at Wells Fargo
            Peg Vale at Bank of America
        */

        // *************************************************************************8
        //     List<Customer> customers = new List<Customer>() {
        //     new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
        //     new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
        //     new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
        //     new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
        //     new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
        //     new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
        //     new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
        //     new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
        //     new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
        //     new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        // };

        //     List<Bank> banks = (from customer in customers
        //                         group customer by customer.Bank into bankGroup
        //                         select new Bank
        //                         {
        //                             Name = bankGroup.Key,
        //                             Customers = bankGroup.ToList()
        //                         }).ToList();

        //     foreach (Bank bank in banks)
        //     {
        //         Console.WriteLine($"{bank.Name} {bank.Customers.Where(customer => customer.Balance >= 1000000).Count()}");
        //     }

        // Testing with var
        // var customersByBank = from customer in customers
        //                       group customer by customer.Bank into bankGroup
        //                       select new {BankId = bankGroup.Key, BankCustomers = bankGroup.ToList()};
    }
}
/*
    Given the same customer set, display how many millionaires per bank.
    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

    Example Output:
    WF 2
    BOA 1
    FTB 1
    CITI 1
*/
// **********************************************************************
