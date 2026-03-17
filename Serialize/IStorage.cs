using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Serialize
{
    public interface IStorage
    {
        public Task SaveAsync<T>(string path, T data);
        public Task<T?> LoadAsync<T>(string path);

    }
}
