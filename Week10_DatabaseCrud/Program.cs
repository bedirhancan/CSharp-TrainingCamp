using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10_DatabaseCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Menü Sipariş İşlem Paneli");
            Console.WriteLine();

            Console.WriteLine("-----------------------------");

            #region Kategori Ekleme İşlemi          
            //Console.Write("Eklemek istediginiz kategori adı:");
            //string categoryName = Console.ReadLine();

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-01KEKD8\\SQLEXPRESS;" +
            //        "Initial Catalog=EgitimKampiDB;Integrated Security=True");
            //connection.Open();

            //SqlCommand command = new SqlCommand("insert into TblCategory (CategoryName) values (@p1)", connection);
            //command.Parameters.AddWithValue("@p1",categoryName);
            //command.ExecuteNonQuery();
            //connection.Close();
            //Console.Write("Kategori ekleme başarılı!");
            #endregion

            #region Ürün Ekleme İşlemi

            //string productName;
            //decimal productPrice;
            ////bool productStatus;

            //Console.Write("Ürün Adı: ");
            //productName = Console.ReadLine();
            //Console.Write("Ürün Fiyatı: ");
            //productPrice = decimal.Parse(Console.ReadLine());

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-01KEKD8\\SQLEXPRESS;" +
            //        "Initial Catalog=EgitimKampiDB;Integrated Security=True");
            //connection.Open();
            //SqlCommand command = new SqlCommand("insert into Tbl_Product (ProductName,ProductPrice,ProductStatus) values (@productName,@productPrice,@productStatus)",connection);
            //command.Parameters.AddWithValue("@productName", productName);
            //command.Parameters.AddWithValue("@productPrice",productPrice);
            //command.Parameters.AddWithValue("@productStatus", true);
            //command.ExecuteNonQuery();
            //connection.Close();
            //Console.Write("Ürün eklemesi başarılı!");

            #endregion

            #region Ürün Listeleme İşlemi

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-01KEKD8\\SQLEXPRESS; Initial Catalog=EgitimKampiDB;Integrated Security=True");
            //connection.Open();
            //SqlCommand command = new SqlCommand("Select * From Tbl_Product", connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);

            //foreach (DataRow row in dataTable.Rows)
            //{
            //    foreach (var row2 in row.ItemArray)
            //    {
            //        Console.Write(row2.ToString()+" ");
            //    }
            //    Console.WriteLine();
            //}

            //connection.Close();

            #endregion

            #region Ürün Silme İşlemi

            //Console.Write("Silinecek ürün id:");
            //int productId = int.Parse(Console.ReadLine());

            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-01KEKD8\\SQLEXPRESS; Initial Catalog=EgitimKampiDB;Integrated Security=True");
            //connection.Open();
            //SqlCommand command = new SqlCommand("Delete From Tbl_Product Where ProductID=@productID", connection);
            //command.Parameters.AddWithValue("@productID", productId);
            //command.ExecuteNonQuery();

            //connection.Close();

            //Console.WriteLine("Silme işlemi yapıldı!");

            #endregion

            #region Ürün Güncelleme

            //Console.Write("Ürün Id giriniz: ");
            //int id = int.Parse(Console.ReadLine());

            //Console.Write("Ürün adı giriniz: ");
            //string ad = Console.ReadLine();

            //Console.Write("Ürün fiyatı giriniz: ");
            //decimal price = decimal.Parse(Console.ReadLine());



            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-01KEKD8\\SQLEXPRESS; Initial Catalog=EgitimKampiDB;Integrated Security=True");
            //connection.Open();
            //SqlCommand command = new SqlCommand("Update Tbl_Product Set ProductName=@productName,ProductPrice=@productPrice Where ProductID=@productId ", connection);
            //command.Parameters.AddWithValue("@productName", ad);
            //command.Parameters.AddWithValue("@productPrice", price);
            //command.Parameters.AddWithValue("@productID", id);
            //command.ExecuteNonQuery();

            //connection.Close();
            //Console.WriteLine("Güncelleme başarılı!");



            #endregion
            
            
            Console.Read();
        }
    }
}
