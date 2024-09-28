using PSG.DataAccessLayer.Models;
using Npgsql;

namespace PSG.DataAccessLayer
{
    public class ProductDataAccess : AppAdoBase
    {
        public bool Create(Product product)
        {
            //creating insert query
            string query = $@"INSERT into product(name,expiry_date,price,unit)
            VALUES('{product.Name}','{product.ExpiryDate.ToString("yyyy-MM-dd hh:mm:ss")}','{product.Price}','{product.Unit}')";

            //sending query to execute
            var rowAffect = ExeCuteSql(query);
            if (rowAffect > 0)
            {
                return true;
            }
            return false;
        }


        public bool Update(Product product)
        {
            string query = $@"UPDATE Product SET name='{product.Name}',expiry_date = '{product.ExpiryDate.ToString("yyyy-MM-dd HH:mm:ss")}',price='{product.Price}', unit='{product.Unit}' WHERE id='{product.Id}'";

            var rowAffect = ExeCuteSql(query);
            if (rowAffect > 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(int id)
        {
            string query = $@"DELETE FROM Product WHERE Id= '{id}'";
            var rowAffect = ExeCuteSql(query);
            if (rowAffect > 0)
            {
                return true;
            }
            return false;
        }

        //Reading and getting list of Data
        public List<Product> GetProducts()
        {
            NpgsqlConnection connection = OpenConnection();
            NpgsqlCommand command = new NpgsqlCommand();
            string sql = "SELECT * From Product";
            command.CommandText = sql;
            command.Connection = connection;
            NpgsqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(reader["id"]);
                product.Name = reader["name"].ToString();
                product.ExpiryDate = Convert.ToDateTime(reader["expiry_date"]);
                product.Price = Convert.ToDouble(reader["price"]);
                product.Unit = reader["unit"].ToString();

                products.Add(product);
            }
            return products;
        }

        // single Product reading
        public Product GetProductById(int id)
        {
            NpgsqlConnection connection = OpenConnection();

            string sql = $@"SELECT * From Product Where Id = '{id}'";

            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandText = sql;
            command.Connection = connection;

            NpgsqlDataReader reader = command.ExecuteReader();

            Product product = new Product();

            reader.Read();
            product.Id = Convert.ToInt32(reader["id"]);
            product.Name = reader["name"].ToString();
            product.ExpiryDate = Convert.ToDateTime(reader["expiry_date"]);
            product.Price = Convert.ToDouble(reader["price"]);
            product.Unit = reader["unit"].ToString();

            return product;
        }
    }
}