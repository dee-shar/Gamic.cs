# Gamic.cs
Mobile-API for [Gamic](https://gamic.app/) a decentralized messaging platform for people and communities looking to engage with Web3 products and services.

## Example
```cs
using GamicApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new Gamic();
            await api.Login("example@gmail.com", "password");
            string accountInfo = await api.GetAccountInfo();
            Console.WriteLine(accountInfo);
        }
    }
}
```
