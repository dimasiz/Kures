using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kurs11_7.Model
{
    public static class Data
    {



        public static List<Deportament> dataDepartment = new List<Deportament>
        {
            new Deportament {Name = "я", ID = 0, ListClient = new List<Client>
            {new Client {
            Name = "Дима",
            SecondName = "Каждывич",
            LastName = "Иванов",
            Number = "123456789",
            PassportData = "AB1234567",
            DepartmentID = 0

            } } },
            new Deportament {Name = "Отдел маркетинга", ID = 1, ListClient = new List<Client>
            {new Client {
            Name = "Дима",
            SecondName = "Каждывич",
            LastName = "Иванов",
            Number = "123456789",
            PassportData = "AB1234567",
            DepartmentID = 1 }
            },
         },

            new Deportament {Name = "Отдел продаж", ID = 2,ListClient = new List<Client>
            {new Client{Name = "Иван",
            SecondName = "Иванович",
            LastName = "Иванов",
            Number = "123456789",
            PassportData = "AB1234567",
            DepartmentID = 2 },
            new Client{ Name = "Петр",
            SecondName = "Петрович",
            LastName = "Петров",
            Number = "987654321",
            PassportData = "CD9876543",
            DepartmentID = 2},
            new Client{Name = "Сидор",
            SecondName = "Сидорович",
            LastName = "Сидоров",
            Number = "555555555",
            PassportData = "EF5555555",
            DepartmentID = 2 } }
            }
        };

        public static List<Deportament> GetAllDeportment()
        {
            return dataDepartment;
        }

        public static  List<Client> GetAllClients()
        {
            List<Client> allClients = new List<Client>();  
            

            for(int i = 0; i < dataDepartment.Count; i++)
            {
                if (dataDepartment[i].ListClient != null)
                    for (int j = 0; j < dataDepartment[i].ListClient.Count; j++)
                    {
                        allClients.Add(dataDepartment[i].ListClient[j]);
                    }
            }
           
            return allClients;
        }

        public static List<Deportament> DataDepartment 
        {
            get 
            {
                return Data.dataDepartment;
            }
        } 
        public static  string CreateDepartment(string name, int id)
        {
            string result = "Уже существует";

            bool checkList = dataDepartment.Any(el => el.Name == name);
            if (!checkList)
            {
                List<Client> list = new List<Client>();
                Deportament newDepartment = new Deportament { Name = name, ListClient = list , ID = dataDepartment.Count };
                Client newClient = new Client();
               
                dataDepartment.Add(newDepartment);
                result = "Сделано";
            }
            return result;
        }

        public static string CreateClient(string name, string secondName, string lastName, string number, string pasport,int id)
        {
            string result = "Уже существует";

            bool checkList = dataDepartment[id].ListClient.Any(el => el.Name == name && 
            el.SecondName == secondName &&
            el.LastName == lastName &&
            el.Number == number && 
            el.PassportData == pasport 
            );
            if (!checkList)
            {
               Client newClient = new Client { Name = name, SecondName = secondName, LastName = lastName, Number = number, PassportData = pasport, DepartmentID = id };
                dataDepartment[id].ListClient.Add(newClient);
                result = "Сделано";
            }
            return result;
        }

       
        public static  string DeleteClient(Client client, int id)
        {
            dataDepartment[id].ListClient.Remove(client);
            string result = $"Клиент{client.Name} удален";
            return result;
        }

        public static  string EditClient(Client oldClient, int id, string newName, string newSecondName, string newLastName, string newNumber, string newPassport, int DepartmentID, bool accses)
        {
            string result;
            if (accses)
            {
                Client client = dataDepartment[id].ListClient.FirstOrDefault(p => p.Number == oldClient.Number);
                
                client.Name = newName;
                client.SecondName = newSecondName;
                client.LastName = newLastName;
                client.Number = newNumber;
                client.PassportData = newPassport;
                client.DepartmentID = DepartmentID;
                result = $"Клиент {client.Name} Изменен";
            }
            else
            {
                Client client = dataDepartment[id].ListClient.FirstOrDefault(p => p.Number == oldClient.Number);
                client.Number = newNumber;
                result = $"Номер {client.Name} Изменен";
            }
            return result;
        }

      


    }
}
