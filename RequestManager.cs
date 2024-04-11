using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_3___Genspil
{
    public class RequestManager
    {
        private List<CustomerRequest> requests;

        public RequestManager()
        {
            requests = new List<CustomerRequest>();
        }

        public void AddRequest(CustomerRequest request)
        {
            requests.Add(request);
        }

        public void RemoveRequest(CustomerRequest request)
        {
            requests.Remove(request);
        }

        public void PrintRequests()
        {
            Console.Clear();
            Console.WriteLine("Customer Requests:");
            foreach (var request in requests)
            {
                Console.WriteLine($"Customer Name: {request.CustomerName}, Requested Game: {request.RequestedGame}");
            }
        }
    }
}
