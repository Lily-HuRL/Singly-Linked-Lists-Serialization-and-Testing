using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName"></param>
        public static void SerializeUsers(ILinkedListADT<User> users, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            //Convert the ILinkedListADT<User> to List<User>
            List<User> userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }
            using (FileStream stream = File.Create(fileName))
            {
                Console.WriteLine(fileName);
                serializer.WriteObject(stream, userList);
            }
        }

        /// <summary>
        /// Deserializes (decodes) users
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>List of users</returns>
        public static ILinkedListADT<User> DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            using (FileStream stream = File.OpenRead(fileName))
            {
                List<User> deserializedUserList = (List<User>)serializer.ReadObject(stream);
                LinkedList<User> deserializedUsers = new LinkedList<User>();
                foreach (User user in deserializedUserList)
                {
                    deserializedUsers.AddLast(user);
                }
                return deserializedUsers;       
            }
        }
    }
}
