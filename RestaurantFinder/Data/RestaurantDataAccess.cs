using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RestaurantFinder.Data.Converters;
using RestaurantFinder.Data.Constants;
using RestaurantFinder.Data.Models;
using Serilog;

namespace RestaurantFinder.Data
{
    public class RestaurantDataAccess : IRestaurantDataAccess
    {
        private ILogger _logger;
        private String _connectionString;
        private IRestaurantDataConverter _restaurantDataConverter;

        public RestaurantDataAccess(ILogger logger, String connectionString, IRestaurantDataConverter restaurantDataConverter)
        {
            if (String.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException(nameof(connectionString));

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _connectionString = connectionString;
            _restaurantDataConverter = restaurantDataConverter ?? throw new ArgumentNullException(nameof(restaurantDataConverter));
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            String query = Queries.GetAllRestaurants;

            using (var connection = await OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    restaurants.Add(ConvertToRestaurantData(reader));
                }
            }

            return restaurants;
        }

        public async Task<List<Restaurant>> GetRestaurantsWithSimilarName(String name)
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            String query = String.Format(Queries.GetRestaurantsWithSimilarName, name);

            using (var connection = await OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    restaurants.Add(ConvertToRestaurantData(reader));
                }
            }

            return restaurants;
        }

        public async Task<Restaurant> GetRestaurant(int id)
        {
            String query = String.Format(Queries.GetRestaurant, id);

            using (var connection = await OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                await reader.ReadAsync();
                return ConvertToRestaurantData(reader);
            }
        }

        private async Task<SqlConnection> OpenSqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }

        private Restaurant ConvertToRestaurantData(SqlDataReader dataReader)
        {
            try
            {
                return _restaurantDataConverter.ConvertToRestaurantData(dataReader);
            }
            catch (ArgumentNullException ex)
            {
                _logger.Error("Null dataReader", ex);

                // TODO: Make database exception wrapper class
                throw ex;
            }
            catch (IndexOutOfRangeException ex)
            {
                _logger.Error("Index out of range", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
