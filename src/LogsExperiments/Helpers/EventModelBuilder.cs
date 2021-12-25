using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogsExperiments.Helpers
{
    public class EventModelBuilder
    {
        public static IList<string> AvailableUsers()
        {
            var users = new List<string>();

            for(var n = 1; n<=10; n++)
            {
                users.Add($"user_{n}");
            }

            return users;
        }

        public static IList<string> AvailableEvents()
        {
            var collection = new List<string>();

            collection.Add("document_created");
            collection.Add("document_updated");
            collection.Add("document_deleted");

            return collection;
        }

        public static IList<string> AvailableDocuments()
        {
            var collection = new List<string>();

            collection.Add("order");
            collection.Add("invoice");
            collection.Add("money_income");
            collection.Add("money_out");
            collection.Add("claim");

            return collection;
        }
    }
}
