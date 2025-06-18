using EventPlatformApp.Models;
using EventPlatformApp.ServiceInterfaces;
using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Data;
using System.Data.SQLite;

namespace EventPlatformApp.Data
{
    public class DatabaseHelper
    {
        private string connString = "";
        
        public DatabaseHelper() { }

        public void CreateTicketTable(List<Event> eventData, string dbFilePath)
        {
            connString = $"Data Source={dbFilePath};Version=3;";
            try
            {
                using var connection = new SQLiteConnection(connString);
                {
                    connection.Open();

                    using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Tickets';", connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null && result.ToString() == "Tickets")
                        {
                            Console.WriteLine("Table 'Tickets' already exists.");
                            return;
                        }
                        else
                        {
                            using (var command = new SQLiteCommand(
                            "CREATE TABLE IF NOT EXISTS Tickets" +
                            "(\r\n TicketId INTEGER PRIMARY KEY AUTOINCREMENT," +   //primary key
                            "\r\n EventId TEXT NOT NULL," +  //foreign key Id from Events table
                            "\r\n EventName TEXT NOT NULL," +  //foreign key Name from Events table
                            "\r\n TicketType TEXT NOT NULL," +
                            "\r\n Price NUMERIC NOT NULL," +
                            "\r\n Sold INT NOT NULL," +
                            "\r\n CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP," +
                            "\r\n UpdatedDate DATETIME DEFAULT CURRENT_TIMESTAMP," +
                            "\r\n FOREIGN KEY (EventId) REFERENCES Events(Id)" +
                            "\r\n );", connection))
                                {
                                    command.ExecuteNonQuery();
                                }

                            PopulateAmountAndSalesData(eventData, dbFilePath);
                        }
                    }

                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not create Tickets table: ", ex.ToString());
            }
        }

        public void PopulateAmountAndSalesData(List<Event> eventData, string dbFilePath)
        {
            connString = $"Data Source={dbFilePath};Version=3;";
            try
            {
                using var connection = new SQLiteConnection(connString);
                {
                    connection.Open();

                    var ticketTypes = new[] { "General", "VIP", "Reserved" };

                    // Using transaction for faster operation
                    using var transaction = connection.BeginTransaction();

                    using var command = new SQLiteCommand(
                        "INSERT INTO Tickets (EventId, EventName, TicketType, Price, Sold) VALUES (@EventId, @EventName, @TicketType, @Price, @Sold)", connection, transaction);

                    var paramEventId = command.Parameters.Add("@EventId", DbType.String);
                    var paramEventName = command.Parameters.Add("@EventName", DbType.String);
                    var paramTicketType = command.Parameters.Add("@TicketType", DbType.String);
                    var paramPrice = command.Parameters.Add("@Price", DbType.Decimal);
                    var paramSold = command.Parameters.Add("@Sold", DbType.Int32);

                    var rand = new Random();

                    foreach (var e in eventData) // List of events
                    {
                        foreach (var ticketType in ticketTypes)
                        {
                            paramEventId.Value = e.Id;
                            paramEventName.Value = e.Name;
                            paramTicketType.Value = ticketType;
                            paramPrice.Value = Math.Round((decimal)(rand.Next(100, 500) + rand.NextDouble())); // 100.00 to 500.00
                            paramSold.Value = rand.Next(500, 2001);   // 500 to 2000

                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not populate Tickets table: ", ex.ToString());
            }
        }
    }
}
