using System;
using System.Data;
using System.Data.SqlClient;

namespace Week09_DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** C# Veri Tabanlı Ürün-Kategori Bilgi Sistemi *****\n");

            string tableNumber;

            Console.WriteLine("-----------------------------");
            Console.WriteLine("1-Kategoriler");
            Console.WriteLine("2-Ürünler");
            Console.WriteLine("3-Siparişler");
            Console.WriteLine("4-Çıkış Yap");
            Console.Write("Lütfen getirmek istediğiniz tablo numarasını giriniz: ");
            tableNumber = Console.ReadLine();
            Console.WriteLine("-----------------------------");

            string query = "";
            switch (tableNumber)
            {
                case "1":
                    query = "SELECT * FROM TblCategory";
                    break;
                case "2":
                    query = "SELECT ProductName,ProductPrice FROM Tbl_Product";
                    break;
                case "3":
                    query = "SELECT * FROM Tbl_Order";
                    break;
                case "4":
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen 1-4 arasında bir değer girin.");
                    return;
            }

            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-01KEKD8\\SQLEXPRESS;" +
                    "Initial Catalog=EgitimKampiDB;Integrated Security=True");
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                connection.Close();

                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veri çekme işlemi sırasında bir hata oluştu: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}
