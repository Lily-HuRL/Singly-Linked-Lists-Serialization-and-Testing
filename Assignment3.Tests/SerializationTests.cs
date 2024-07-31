using Assignment3;


namespace Assignment3.Tests
{
    public class SerializationTests
    {
        private ILinkedListADT<User> users;
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            // Uncomment the following line
            this.users = new LinkedList<User>();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the object was serialized.
        /// </summary>
        [Test]
        public void TestSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName));
        }

        /// <summary>
        /// Tests the object was deserialized.
        /// </summary>
        [Test]
        public void TestDeSerialization()
        {
            SerializationHelper.SerializeUsers(users, testFileName);
            ILinkedListADT<User> deserializedUsers = SerializationHelper.DeserializeUsers(testFileName);

            Assert.IsTrue(users.Count() == deserializedUsers.Count());

            for (int i = 0; i < users.Count(); i++)
            {
                User expected = users.GetValue(i);
                User actual = deserializedUsers.GetValue(i);

                Assert.AreEqual(expected.Id, actual.Id);
                Assert.AreEqual(expected.Name, actual.Name);
                Assert.AreEqual(expected.Email, actual.Email);
                Assert.AreEqual(expected.Password, actual.Password);
            }
        }

        [Test]
        public void TestAdd()
        {
            User adduser = new User(5, "Add", "add@outlook.com", "add999");
            users.Add(adduser, 4);
            Assert.AreEqual(adduser, users.GetValue(4));
        }

        [Test]
        public void TestAddFirst()
        {
            User adduser = new User(5, "Add", "add@outlook.com", "add999");
            users.AddFirst(adduser);
            Assert.AreEqual(adduser, users.GetValue(0));
        }

        [Test]
        public void TestAddLast()
        {
            User addUser = new User(5, "Add", "add@outlook.com", "add999");
            users.AddLast(addUser);
            Assert.AreEqual(addUser, users.GetValue(users.Count() - 1));
        }

        [Test]
        public void TestReplace()
        {
            User replaceUser = new User(5, "Replace", "replace@outlook.com", "replace999");
            users.Replace(replaceUser, 2);
            Assert.AreEqual(replaceUser, users.GetValue(2));
        }

        [Test]
        public void TestCount()
        {
            Assert.AreEqual(4, users.Count());
        }

        [Test]
        public void TestGetValue()
        {
            var user1 = users.GetValue(0);
            var user2 = users.GetValue(1);
            var user3 = users.GetValue(2);
            var user4 = users.GetValue(3);
           
            Assert.AreEqual(1, user1.Id);
            Assert.AreEqual("Joe Blow", user1.Name);
            Assert.AreEqual("jblow@gmail.com", user1.Email);
            Assert.AreEqual("password", user1.Password);

            Assert.AreEqual(2, user2.Id);
            Assert.AreEqual("Joe Schmoe", user2.Name);
            Assert.AreEqual("joe.schmoe@outlook.com", user2.Email);
            Assert.AreEqual("abcdef", user2.Password);

            Assert.AreEqual(3, user3.Id);
            Assert.AreEqual("Colonel Sanders", user3.Name);
            Assert.AreEqual("chickenlover1890@gmail.com", user3.Email);
            Assert.AreEqual("kfc5555", user3.Password);

            Assert.AreEqual(4, user4.Id);
            Assert.AreEqual("Ronald McDonald", user4.Name);
            Assert.AreEqual("burgers4life63@outlook.com", user4.Email);
            Assert.AreEqual("mcdonalds999", user4.Password);
        }

        [Test]
        public void TestIndexOf()
        {
            var user1 = users.GetValue(0);
            var user2 = users.GetValue(1);
            var user3 = users.GetValue(2);
            var user4 = users.GetValue(3);
        
            Assert.AreEqual(0,users.IndexOf(user1));
            Assert.AreEqual(1,users.IndexOf(user2));
            Assert.AreEqual(2,users.IndexOf(user3));
            Assert.AreEqual(3,users.IndexOf(user4));
        }

        [Test]
        public void TestContains()
        {
            var user1 = users.GetValue(0);
            var user2 = users.GetValue(1);
            var user3 = users.GetValue(2);
            var user4 = users.GetValue(3);
        
            Assert.IsTrue(users.Contains(user1));
            Assert.IsTrue(users.Contains(user2));
            Assert.IsTrue(users.Contains(user3));
            Assert.IsTrue(users.Contains(user4));
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.IsFalse(users.IsEmpty());
            users.Clear();
            Assert.IsTrue(users.IsEmpty());
        }

        [Test]
        public void TestRemove()
        {
            var user1 = users.GetValue(0);
            var user2 = users.GetValue(1);
            var user3 = users.GetValue(2);
            var user4 = users.GetValue(3);
        
            users.Remove(user1);
            Assert.IsFalse(users.Contains(user1));
            users.Remove(user2);
            Assert.IsFalse(users.Contains(user2));
            users.Remove(user3);
            Assert.IsFalse(users.Contains(user3));
            users.Remove(user4);
            Assert.IsFalse(users.Contains(user4));
        }

        [Test]
        public void TestRemoveFirst()
        {
            var user1 = users.GetValue(0);
            users.RemoveFirst();
            Assert.IsFalse(users.Contains(user1));
        }

        [Test]
        public void TestRemoveLast()
        {
            var user4 = users.GetValue(3);
            users.RemoveLast();
            Assert.IsFalse(users.Contains(user4));
        }      

    }
}