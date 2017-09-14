using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Response
{
    public class GetSubscriptionsResponse : ApiResponse, IList<GetSubscriptionResponse>
    {
        private List<GetSubscriptionResponse> subscriptions { get; set; }
        public GetSubscriptionsResponse():base()
        {
            subscriptions = new List<Response.GetSubscriptionResponse>();
        }
        public GetSubscriptionResponse this[int index]
        {
            get
            {
                return subscriptions[index];
            }

            set
            {
                subscriptions[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return subscriptions.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(GetSubscriptionResponse item)
        {
            this.subscriptions.Add(item);
        }

        public void Clear()
        {
            this.subscriptions.Clear();
        }

        public bool Contains(GetSubscriptionResponse item)
        {
            return this.subscriptions.Contains(item);
        }

        public void CopyTo(GetSubscriptionResponse[] array, int arrayIndex)
        {
            this.subscriptions.CopyTo(array, arrayIndex);
        }

        public IEnumerator<GetSubscriptionResponse> GetEnumerator()
        {
            return this.subscriptions.GetEnumerator();
        }

        public int IndexOf(GetSubscriptionResponse item)
        {
            return this.IndexOf(item);
        }

        public void Insert(int index, GetSubscriptionResponse item)
        {
            this.subscriptions.Insert(index, item);
        }

        public bool Remove(GetSubscriptionResponse item)
        {
            return this.subscriptions.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.subscriptions.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.subscriptions.GetEnumerator();
        }
    }
}
