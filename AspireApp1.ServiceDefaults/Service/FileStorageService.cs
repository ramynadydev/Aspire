using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspireApp1.ServiceDefaults.Service
{
    public class FileStorageService
    {
        private readonly string _basePath;

        public FileStorageService()
        {
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public async Task SaveAsync<T>(string fileName, List<T> data)
        {
            var filePath = Path.Combine(_basePath, fileName);
            var jsonData = System.Text.Json.JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(filePath, jsonData);
        }

        public async Task<List<T>> LoadAsync<T>(string fileName)
        {
            var filePath = Path.Combine(_basePath, fileName);
            if (!File.Exists(filePath)) return new List<T>();

            var jsonData = await File.ReadAllTextAsync(filePath);
            return System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
    }

}
