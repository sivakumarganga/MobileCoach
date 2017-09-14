using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileCoach.Client.Response
{
    public class GetMessagesResponse : ApiResponse, IList<GetMessageResponse>
    {
        private List<GetMessageResponse> messages { get; set; }
        public GetMessagesResponse():base()
        {
            messages = new List<Response.GetMessageResponse>();
        }
        public GetMessageResponse this[int index]
        {
            get
            {
              return  messages[index];
            }

            set
            {
                messages[index] = value;
            }
        }

        public int Count
        {
            get
            {
               return messages.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(GetMessageResponse item)
        {
            this.messages.Add(item);
        }

        public void Clear()
        {
            this.messages.Clear();
        }

        public bool Contains(GetMessageResponse item)
        {
            return this.messages.Contains(item);
        }

        public void CopyTo(GetMessageResponse[] array, int arrayIndex)
        {
            this.messages.CopyTo(array, arrayIndex);
        }

        public IEnumerator<GetMessageResponse> GetEnumerator()
        {
            return this.messages.GetEnumerator();
        }

        public int IndexOf(GetMessageResponse item)
        {
            return this.IndexOf(item);
        }

        public void Insert(int index, GetMessageResponse item)
        {
            this.messages.Insert(index,item);
        }

        public bool Remove(GetMessageResponse item)
        {
            return this.messages.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.messages.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.messages.GetEnumerator();
        }
    }
}
