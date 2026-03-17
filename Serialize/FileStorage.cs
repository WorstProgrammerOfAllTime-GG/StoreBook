using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore.Serialize
{
    public class FileStorage : IStorage
    {
        public async Task SaveAsync<T>(string path, T data)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync(fs, data);
            }
        }

        public async Task<T?> LoadAsync<T>(string path)
        {
            if (!File.Exists(path))
            {
               return default;
            }
            using (FileStream fs = new FileStream(path,FileMode.Open))
            {
                if (fs.Length == 0)
                {
                    return default;
                }
                return await JsonSerializer.DeserializeAsync<T>(fs);              
            }
        }
    }
}
