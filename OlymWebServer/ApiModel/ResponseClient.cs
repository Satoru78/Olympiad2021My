using Olympiad2021My.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlymWebServer.ApiModel
{
    class ResponseClient
    {
        public ResponseClient(Client client)
        {
            this.ID = client.ID;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.Patronymic = client.Patronymic;
            this.Birthday = client.Birthday;
            this.RegistrationDate = client.RegistrationDate;
            this.Email = client.Email;
            this.Phone = client.Phone;
            this.GenderCode = client.GenderCode;


        }
        public ResponseClient() { }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GenderCode { get; set; }
    }
}
