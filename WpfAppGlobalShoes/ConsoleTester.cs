using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfAppGlobalShoes.Context; // Adjust according to your namespace

public class ConsoleTester
{
    public static void Run()
    {
        // Create an instance of your DbContext
        using (var context = new GSDBContext())
        {
            // Try to access the database
            try
            {
                // Perform a simple query to check the connection
                var productCount = context.Products.CountAsync().Result;
                Console.WriteLine($"Number of products in the database: {productCount}");
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., connection issues
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

     
    }
}
